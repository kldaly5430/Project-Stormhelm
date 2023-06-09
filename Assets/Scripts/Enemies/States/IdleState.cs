using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{

    public PursueTargetState purseState;
    public LayerMask detectionLayer;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        // Look for target
        #region Enemy Target Detect
        Collider[] colliders = Physics.OverlapSphere(transform.position, enemyManager.detectionRadius, detectionLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

            if (characterStats != null)
            {
                // Check for team ID
                Vector3 targetDirection = characterStats.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                if (viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
                {
                    enemyManager.currentTarget = characterStats;
                    return purseState;
                }
            }
        }
        #endregion
        // Switch to pursuing target
        #region Switching to next state
        if (enemyManager.currentTarget != null)
        {
            return purseState;
        }
        else
        {
            return this;
        }
        #endregion
    }
}
