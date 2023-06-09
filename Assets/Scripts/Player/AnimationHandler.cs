using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationHandler : AnimatorManager
{
    
    PlayerManager playerManager;
    InputManager inputManager;
    PlayerMovement playerMovement;
    int vertical;
    int horizontal;
    // public bool canRotate;

    public void Initialize(){
        playerManager = GetComponentInParent<PlayerManager>();
        animator = GetComponent<Animator>();
        inputManager = GetComponentInParent<InputManager>();
        playerMovement = GetComponentInParent<PlayerMovement>();
        vertical = Animator.StringToHash("Vertical");
        horizontal = Animator.StringToHash("Horizontal");
    }

    public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement, bool isSprinting) {
        #region Vertical
        float v = 0;

        if(verticalMovement > 0 && verticalMovement < 0.55f)
        {
            v = 0.5f;
        }
        else if(verticalMovement > 0.55f)
        {
            v = 1;
        }
        else if(verticalMovement < 0 && verticalMovement > -0.55f)
        {
            v = -0.5f;
        }
        else if(verticalMovement < -0.55f)
        {
            v = -1;
        }
        else
        {
            v = 0;
        }
        #endregion

        #region Horizontal
        float h = 0;

        if(horizontalMovement > 0 && horizontalMovement < 0.55f)
        {
            h= 0.5f;
        }
        else if(horizontalMovement > 0.55f)
        {
            h = 1;
        }
        else if(horizontalMovement < 0 && horizontalMovement > -0.55f)
        {
            h = -0.5f;
        }
        else if(horizontalMovement < -0.55f)
        {
            h = -1;
        }
        else
        {
            h = 0;
        }
        #endregion

        if(isSprinting)
        {
            v = 2;
            h = horizontalMovement;
        }
        
        animator.SetFloat(vertical, v, 0.1f, Time.deltaTime);
        animator.SetFloat(horizontal, h, 0.1f, Time.deltaTime);
    }



    public void CanBeRotated() {
        canRotate = true;
    }

    public void StopRotation() {
        canRotate = false;
    }

    public void EnableCombo()
    {
        animator.SetBool("canCombo", true);
    }

    public void DisableCombo()
    {
        animator.SetBool("canCombo", false);
    }

}
