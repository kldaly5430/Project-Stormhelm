using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{

    public RotateTowardsEnemyState rotateTowardsEnemyState;
    public CombatStanceState stanceState;
    public PursueTargetState pursueTargetState;
    public IdleState idleState;

    public EnemyAttackAction[] enemyAttacks;
    public EnemyAttackAction currentAttack;

    public RaycastHit hit;

    public bool hasPerformedAttack = false;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);

        if(Physics.SphereCast(new Vector3(transform.position.x, transform.position.y, transform.position.z), 0.5f, transform.forward, out hit))
        {
            var colliderHit = hit.collider.gameObject.tag;
            if(colliderHit == "Enemy")
            {
                MoveAwayFromAlly(enemyManager, hit);
            }
        }

        if(distanceFromTarget > enemyManager.maxAggroRadius)
        {
            return pursueTargetState;
        }

        //if can do combo

        if(!hasPerformedAttack)
        {
            AttackTarget(enemyAnimatorManager);
        }

        return rotateTowardsEnemyState;
    }

    private void AttackTarget(EnemyAnimatorManager enemyAnimatorManager)
    {
        enemyAnimatorManager.PlayTargetAnimation(currentAttack.actionAnimation, true);
        hasPerformedAttack = true;
    }

    private void HandleRotateTowardTarget(EnemyManager enemyManager)
    {
        // Rotate manually
        if (!enemyManager.canRotate && enemyManager.isInteracting)
        {
            Vector3 direction = enemyManager.currentTarget.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            if (direction == Vector3.zero)
            {
                direction = transform.forward;
            }

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            enemyManager.transform.rotation = Quaternion.Slerp(enemyManager.transform.rotation, targetRotation, enemyManager.rotationSpeed / Time.deltaTime);
        }
    }

    private void MoveAwayFromAlly(EnemyManager enemyManager, RaycastHit hit)
    {
        
    }
}
