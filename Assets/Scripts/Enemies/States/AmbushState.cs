using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbushState : State
{

    public bool isSleeping;
    public float detectionRadius;
    public string sleepAnimation;
    public string awakeAnimation;

    public LayerMask detectionLayer;

    public PursueTargetState purseState;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        if (isSleeping && enemyManager.isInteracting == false)
        {
            enemyAnimatorManager.PlayTargetAnimation(sleepAnimation, true);
        }

        #region Detection Radius
        Collider[] colliders = Physics.OverlapSphere(enemyManager.transform.position, detectionRadius, detectionLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();

            if (characterStats != null)
            {
                Vector3 targetsDirection = characterStats.transform.position - enemyManager.transform.position;
                float viewableAngle = Vector3.Angle(targetsDirection, enemyManager.transform.forward);

                if(viewableAngle > enemyManager.minimumDetectionAngle && viewableAngle < enemyManager.maximumDetectionAngle)
                {
                    enemyManager.currentTarget = characterStats;
                    isSleeping = false;
                    enemyAnimatorManager.PlayTargetAnimation(awakeAnimation, true);
                }
            }
        }
        #endregion
        #region State Change
        if (enemyManager.currentTarget != null)
        {
            return purseState;
            // return this;
        }
        else
        {
            return this;
        }
        #endregion
    }
}
