using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : CharacterManager
{
    
    InputManager inputManager;
    Animator animator;
    PlayerMovement playerMovement;

    InteractableUI interactableUI;
    DialogManager dialogManager;
    public Interactable interactableObject;
    public GameObject interactableUIGameObject;

    public TalkToNPC dialogGameObject;
    public GameObject dialogUIGameObject;

    public bool isInteracting;
    public bool isInteractable;
    public bool isTalkable;
    public bool isTalking;

    [Header("Player Flags")]
    public bool isSprinting;
    public bool isInAir;
    public bool isGrounded;
    public bool isUsingRightHand;
    public bool isUsingLeftHand;
    public bool isBlocking;
    public bool canDoCombo;

    void Start()
    {
        inputManager = GetComponent<InputManager>();
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
        interactableUI = FindObjectOfType<InteractableUI>();
        dialogManager = FindObjectOfType<DialogManager>();
        interactableUIGameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime;
        isInteracting = animator.GetBool("isInteracting");
        canDoCombo = animator.GetBool("canCombo");
        animator.SetBool("isInAir", isInAir);
        animator.SetBool("isBlocking", isBlocking);

        isUsingRightHand = animator.GetBool("isUsingRightHand");
        isUsingLeftHand = animator.GetBool("isUsingLeftHand");


        isSprinting = inputManager.shift_Input;
        inputManager.TickInput(delta);
        playerMovement.HandleMovement(delta);
        playerMovement.HandleRotation(delta);
        playerMovement.HandleFalling(delta, playerMovement.moveDirection);
        playerMovement.HandleJumping();

        if(isInteractable)
            if(isTalkable)
            {
                TalkWith(interactableObject);
            }
            else
            {
                InteractWith(interactableObject);
            }

        if(isTalking)
        {
            if(inputManager.jump_Input)
                dialogManager.DisplayNextSentence();
        }
        // CheckForInteractableObject();
    }

    private void LateUpdate() {
        inputManager.lmb_input = false;
        inputManager.rmb_input = false;
        inputManager.jump_Input = false;
        inputManager.action_Input = false;
        inputManager.inventory_Input = false;

        if(isInAir)
        {
            playerMovement.inAirTimer = playerMovement.inAirTimer + Time.deltaTime;
        }
        
        
    }

    public void InteractWith(Interactable interactableObject) {
        if(inputManager.action_Input)
        {
            interactableObject.GetComponent<Interactable>().Interact(this);
            interactableUIGameObject.SetActive(false);
            isInteractable = false;
            interactableObject = null;
        }
    }

    public void TalkWith(Interactable interactableObject)
    {
        if(inputManager.action_Input)
        {
            interactableObject.GetComponent<Interactable>().Talk(this);
            interactableUIGameObject.SetActive(false);
            isInteractable = false;
            isTalkable = false;
            interactableObject = null;
        }
    }

    // public void CheckForInteractableObject() {
    //     RaycastHit hit;
    //     Vector3 rayOrigin = transform.position;
    //     rayOrigin.y = rayOrigin.y + 2f;
        
    //     if(Physics.SphereCast(transform.position, 0.3f, transform.forward, out hit, 1f))
    //     {
    //         if(hit.collider.tag == "Interactable")
    //         {
    //             Interactable interactableObject = hit.collider.GetComponent<Interactable>();

    //             if(interactableObject != null)
    //             {
    //                 string interactableText = interactableObject.interactableText;
    //                 interactableUI.interactableText.text = interactableText;
    //                 interactableUIGameObject.SetActive(true);

    //                 if(inputManager.action_Input)
    //                 {
    //                     hit.collider.GetComponent<Interactable>().Interact(this);
    //                 }
    //             }
    //         }
    //     }
    //     else
    //     {
    //         if(interactableUIGameObject != null)
    //         {
    //             interactableUIGameObject.SetActive(false);
    //         }
    //     }
    // }

    public void OnTriggerEnter(Collider collider) {
        if(collider.tag == "Interactable")
        {
            interactableObject = collider.GetComponent<Interactable>();

            if(interactableObject != null)
            {
                string interactableText = interactableObject.interactableText;
                interactableUI.interactableText.text = interactableText;
                interactableUIGameObject.SetActive(true);
                isInteractable = true;
            }
        }
        else if(collider.tag == "NPC")
        {
            interactableObject = collider.GetComponent<Interactable>();
            dialogGameObject = collider.GetComponent<TalkToNPC>();
            if(interactableObject != null)
            {
                string interactableText = interactableObject.interactableText;
                interactableUI.interactableText.text = interactableText;
                interactableUIGameObject.SetActive(true);
                isInteractable = true;
                isTalkable = true;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        interactableUIGameObject.SetActive(false);
        dialogGameObject = null;
        dialogUIGameObject.SetActive(false); // Set later to not be able to move if talking
        isInteractable = false;
        isTalkable = false;
        interactableObject = null;
    }

}
