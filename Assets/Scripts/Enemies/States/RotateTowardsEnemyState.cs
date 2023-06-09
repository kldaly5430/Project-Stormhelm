using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardsEnemyState : State
{
    public CombatStanceState combatStanceState;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        enemyAnimatorManager.animator.SetFloat("Vertical",0);
        enemyAnimatorManager.animator.SetFloat("Horizontal",0);

        if(enemyManager.isInteracting)
            return this;

        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        float viewableAngle = Vector3.SignedAngle(targetDirection, enemyManager.transform.forward, Vector3.up);
        // Debug.Log(viewableAngle);
        if(viewableAngle <= -45 && viewableAngle >= -100 && !enemyManager.isInteracting)
        {
            enemyAnimatorManager.PlayTargetAnimationWithRootAnimation("Right Turn", true);
            Debug.Log("Played right anim");
            return combatStanceState;
        }
        else if(viewableAngle >= 45 && viewableAngle <= 100 && !enemyManager.isInteracting)
        {
            Debug.Log("Played left anim");
            enemyAnimatorManager.PlayTargetAnimationWithRootAnimation("Left Turn", true);
            return combatStanceState;
        }

        return combatStanceState;
    }
}
