using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    PlayerManager playerManager;
    
    public float horizontal;
    public float vertical;
    public float moveAmount;
    public float mouseX;
    public float mouseY;

    public bool shift_Input;
    public bool jump_Input;
    public bool action_Input;
    public bool inventory_Input;
    public bool lmb_input;
    public bool rmb_input;

    public bool sprintFlag;
    public bool comboFlag;

    public bool inventoryFlag;
    public bool shouldContinue;
    public bool hasStarted;

    public PlayerControls movementActions;
    InteractionControls interactionActions;
    AnimationHandler animationHandler;
    PlayerAttack playerAttack;
    PlayerInventory playerInventory;
    UIManager uIManager;
    CameraManager cameraManager;

    public Vector2 movementInput;
    Vector2 cameraInput;

    public void OnEnable() {
        if(movementActions == null){
            movementActions = new PlayerControls();
            movementActions.Player.Movement.performed += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            movementActions.Player.Movement.canceled += inputActions => movementInput = inputActions.ReadValue<Vector2>();
            movementActions.Player.MouseLook.performed += i => cameraInput = i.ReadValue<Vector2>();
            movementActions.Player.Sprint.performed += i => shift_Input = true;
            movementActions.Player.Sprint.canceled += i => shift_Input = false;
            movementActions.Player.Jump.performed += i => jump_Input = true;
        }
        if(interactionActions == null){
            interactionActions = new InteractionControls();
            interactionActions.Interaction.LMB.performed += i => lmb_input = true;
            interactionActions.Interaction.RMB.performed += i => rmb_input = true;
            interactionActions.Interaction.RMB.canceled += i => rmb_input = false;
            interactionActions.Interaction.Dialog.performed += i => jump_Input = true;
            interactionActions.Interaction.Interact.performed += i => action_Input = true;
            interactionActions.Interaction.Inventory.performed += inputActions => inventory_Input = true;
        }

        movementActions.Enable();
        interactionActions.Enable();
    }

    public void OnDisable() {
        movementActions.Disable();
    }

    public void DisableControls()
    {
        movementActions.Disable();
        movementActions.Player.Movement.canceled += inputActions => movementInput = new Vector2(0,0);
        interactionActions.Disable();
        interactionActions.Interaction.Dialog.Enable();
    }

    private void Awake() {
        playerManager = GetComponent<PlayerManager>();
        animationHandler = GetComponent<AnimationHandler>();
        playerAttack = GetComponent<PlayerAttack>();
        playerInventory = GetComponent<PlayerInventory>();
        uIManager = FindObjectOfType<UIManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void TickInput(float delta){
        MoveInput(delta);
        HandleSprint(delta);
        HandleLMBInput(delta);
        HandleRMBInput(delta);
        HandleInventoryInput();
        // Debug.Log(movementInput.y);
    }

    public void MoveInput(float delta){
        horizontal = movementInput.x;
        vertical = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontal) + Mathf.Abs(vertical));
        mouseX = cameraInput.x;
        mouseY = cameraInput.y;
    }

    private void HandleSprint(float delta){
        // shift_Input = inputActions.Player.Sprint.phase == UnityEngine.InputSystem.InputActionPhase.Started;


        if(animationHandler.animator.GetBool("isInteracting"))
            return;

        sprintFlag = shift_Input;

        if(shift_Input)
        {
            playerManager.isSprinting = true;
        }
        else
        {
            playerManager.isSprinting = false;
        }
    }

    private void HandleLMBInput(float delta) {
        if (lmb_input)
        {
            if (inventoryFlag)
                return;

            if (playerInventory.rightWeapon)
            {
                
                if(playerManager.canDoCombo)
                {
                    comboFlag = true;
                    animationHandler.animator.SetBool("isUsingRightHand", true);
                    playerAttack.HandleWeaponCombo(playerInventory.rightWeapon);
                    comboFlag = false;
                }
                else
                {
                    animationHandler.animator.SetBool("isUsingRightHand", true);
                    playerAttack.HandleLightAttack(playerInventory.rightWeapon);
                }
            }
            else if (!playerInventory.rightWeapon)
            {
                Debug.Log("Punching animation plays");
            }
        }
    }

    private void HandleRMBInput(float delta) { 
        if(rmb_input)
        {
            if (playerManager.isInteracting || inventoryFlag)
                return;

            if (playerInventory.leftWeapon.isMelee)
            {
                animationHandler.animator.SetBool("isUsingLeftHand", true);
                playerAttack.HandleHeavyAttack(playerInventory.leftWeapon);
            }
            else if (playerInventory.leftWeapon.isShield)
            {
                playerAttack.HanldeBlockAction();
            }
            else if(!playerInventory.leftWeapon)
            {
                Debug.Log("Punching animation plays");
            }
            
        }
        else
        {
            playerManager.isBlocking = false;
        }
    }



    private void HandleInventoryInput() {
        if(inventory_Input)
        {
            inventoryFlag = !inventoryFlag;

            if(inventoryFlag)
            {
                OnDisable();
                uIManager.OpenInventory();
                uIManager.hudWindow.SetActive(false);
                cameraManager.SwitchCamera();
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                OnEnable();
                uIManager.CloseInventory();
                uIManager.hudWindow.SetActive(true);
                cameraManager.SwitchCamera();
                Cursor.lockState = CursorLockMode.Locked;  
            }
        }
    }

}
