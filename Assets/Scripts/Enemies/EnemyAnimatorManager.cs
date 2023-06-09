﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorManager : AnimatorManager
{

    EnemyManager enemyManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        enemyManager = GetComponent<EnemyManager>();
    }

    private void OnAnimatorMove()
    {
        float delta = Time.deltaTime;
        enemyManager.enemyRigidBody.drag = 0;
        Vector3 deltaPosition = animator.deltaPosition;
        deltaPosition.y = 0;
        Vector3 velocity = deltaPosition / delta;
        enemyManager.enemyRigidBody.velocity = velocity;
        //enemyMovement.enemyCharacterController.SimpleMove(velocity);

        if(enemyManager.isRotatingWithRootMotion)
        {
            enemyManager.transform.rotation *= animator.deltaRotation;
        }
    }

}
