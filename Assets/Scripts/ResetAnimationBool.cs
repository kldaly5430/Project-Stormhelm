﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAnimationBool : StateMachineBehaviour
{
    public string isInteractingBool = "isInteracting";
    public bool isInteractingStatus = false;

    public string isRotatingWithRootMotion = "isRotatingWithRootMotion";
    public bool isRotatingWithRootMotionStatus = false;

    public string canRotateBool = "canRotate";
    public bool canRotateStatus = true;

    public string canCombo = "canCombo";
    public bool canComboStatus = false;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(isInteractingBool, isInteractingStatus);
        animator.SetBool(isRotatingWithRootMotion, isRotatingWithRootMotionStatus);
        animator.SetBool(canRotateBool, canRotateStatus);
        animator.SetBool(canCombo, canComboStatus);
    }
}
