using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    PlayerManager playerManager;
    Transform cameraObject;
    InputManager inputManager;
    public Vector3 moveDirection;

    [HideInInspector]
    public Transform myTransform;
    [HideInInspector]
    public AnimationHandler animationHandler;

    public CharacterController characterController;

    [Header("Ground & Air Detection")]
    [SerializeField]
    float fallingVelocity = 1f;
    // float groundDetectionRayStart = 0.5f;
    [SerializeField]
    float rayCastHeightOffset = -0.18f;
    // float minFallDistance = 1f;
    // [SerializeField]
    // float groundDirRayDistance = 0.2f;
    public LayerMask ignoreForGroundCheck;
    public float inAirTimer;

    public Vector3 offset;

    [Header("Movement Stats")]
    [SerializeField]
    private float movementSpeed = 2;

    public float setSpeed
    {
        set{ movementSpeed = value;}
    }
    [SerializeField]
    float sprintSpeed = 3;
    [SerializeField]
    float rotationSpeed = 10;
    [SerializeField]
    float fallSpeed = 5;

    

    void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        inputManager = GetComponent<InputManager>();
        characterController = GetComponent<CharacterController>();
        animationHandler = GetComponentInChildren<AnimationHandler>();
        cameraObject = Camera.main.transform;
        myTransform = transform;
        animationHandler.Initialize();

        playerManager.isGrounded = true;
    }

    #region Movement
    Vector3 normalVector;
    Vector3 targetPosition;
    
    public void HandleMovement(float delta){
        if(playerManager.isInteracting)
        {
            return;
        }
            
        
        moveDirection = cameraObject.forward * inputManager.vertical;
        moveDirection += cameraObject.right * inputManager.horizontal;
        moveDirection.Normalize();
        moveDirection.y = 0;
    
        float speed = movementSpeed;

        if(inputManager.sprintFlag && inputManager.moveAmount > 0.5f)
        {
            speed = sprintSpeed;
            playerManager.isSprinting = true;
            moveDirection *= speed;
        }
        else 
        {
            moveDirection *= speed;
            playerManager.isSprinting = false;
        }

        Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
        characterController.SimpleMove(projectedVelocity * delta);

        animationHandler.UpdateAnimatorValues(inputManager.moveAmount, 0, playerManager.isSprinting);

        if(animationHandler.canRotate){
            HandleRotation(delta);
        }
    }

    public void HandleRotation(float delta){
        Vector3 targetDir = Vector3.zero;
        float moveOverride = inputManager.moveAmount;

        targetDir = cameraObject.forward * inputManager.vertical;
        targetDir += cameraObject.right * inputManager.horizontal;

        targetDir.Normalize();
        targetDir.y = 0;

        if(targetDir == Vector3.zero){
            targetDir = myTransform.forward;
        }

        float rs = rotationSpeed;

        Quaternion tr = Quaternion.LookRotation(targetDir);
        Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);

        myTransform.rotation = targetRotation;
    }

    public void HandleFalling(float delta, Vector3 moveDirection){
        RaycastHit hit;
        Vector3 rayCastOrigin = myTransform.position;
        rayCastOrigin.y = rayCastOrigin.y + rayCastHeightOffset;

        if(!playerManager.isGrounded)
        {
            if(!playerManager.isInteracting)
                // animationHandler.PlayTargetAnimation("Falling", true);

            inAirTimer = inAirTimer + delta;
            characterController.SimpleMove(transform.forward * fallingVelocity);
            characterController.SimpleMove(-Vector3.up * fallSpeed * inAirTimer);
        }

        if(Physics.SphereCast(rayCastOrigin, 0.2f, -Vector3.up, out hit, ignoreForGroundCheck))
        {
            if(!playerManager.isGrounded) //&& !playerManager.isInteracting)
            {
                animationHandler.PlayTargetAnimation("Landing", true);
            }

            inAirTimer = 0;
            playerManager.isGrounded = true;
        }
        else
        {
            playerManager.isGrounded = false;
        }
    }

    public void HandleJumping(){
        if(playerManager.isInteracting || playerManager.isTalking)
            return;

        if(inputManager.jump_Input)
        {
            if(inputManager.jump_Input)
            {
                moveDirection = cameraObject.forward * inputManager.vertical;
                moveDirection += cameraObject.right * inputManager.horizontal;
                animationHandler.PlayTargetAnimation("Jump", true);
                moveDirection.y = 0;
                Quaternion jumpRotation = Quaternion.LookRotation(moveDirection);
                myTransform.rotation = jumpRotation;
            }
        }
    }

    #endregion
}
