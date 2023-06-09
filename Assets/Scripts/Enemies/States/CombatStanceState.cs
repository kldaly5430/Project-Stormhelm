using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatStanceState : State
{

    public AttackState attackState;
    public EnemyAttackAction[] enemyAttacks;
    public PursueTargetState purseState;
    bool randomDestinationSet = false;
    float verticalMovementValue;
    float horizontalMovementValue;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        // Check for attack range
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        enemyAnimatorManager.animator.SetFloat("Vertical",verticalMovementValue, 0.2f, Time.deltaTime);
        enemyAnimatorManager.animator.SetFloat("Horizontal",horizontalMovementValue, 0.2f, Time.deltaTime);
        attackState.hasPerformedAttack = false;
        // Potentially circle player

        if(enemyManager.isInteracting)
        {
            enemyAnimatorManager.animator.SetFloat("Vertical",0);
            enemyAnimatorManager.animator.SetFloat("Horizontal",0);
            return this;
        }

        if(distanceFromTarget > enemyManager.maxAggroRadius)
        {
            return purseState;
        }

        if(!randomDestinationSet)
        {
            randomDestinationSet = true;
            DecideCirclingAction(enemyAnimatorManager);
        }

        HandleRotateTowardTarget(enemyManager);

        if (enemyManager.currentRecoveryTime <= 0 && attackState.currentAttack != null)
        {
            randomDestinationSet = false;
            return attackState;
        }
        else
        {
            GetNewAttack(enemyManager);
        }

        return this;
    }

    private void HandleRotateTowardTarget(EnemyManager enemyManager)
    {
        // Rotate manually
        if (!enemyManager.isPerformingAction)
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
        // Navmesh Rotation
        else
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(enemyManager.navMeshAgent.desiredVelocity);
            Vector3 targetVelocity = enemyManager.enemyRigidBody.velocity;

            enemyManager.navMeshAgent.enabled = true;
            enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
            enemyManager.enemyRigidBody.velocity = targetVelocity;
            enemyManager.transform.rotation = Quaternion.Slerp(enemyManager.transform.rotation, enemyManager.navMeshAgent.transform.rotation, enemyManager.rotationSpeed / Time.deltaTime);
        }
    }

    private void DecideCirclingAction(EnemyAnimatorManager enemyAnimatorManager)
    {
        // Circle with forward vertical movement
        // circle with running
        walkAroundTarget(enemyAnimatorManager);
    }

    private void GetNewAttack(EnemyManager enemyManager)
    {
        Vector3 targetsDirection = enemyManager.currentTarget.transform.position - transform.position;
        float viewableAngle = Vector3.Angle(targetsDirection, transform.forward);
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, transform.position);

        int maxScore = 0;
        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];

            if (distanceFromTarget <= enemyAttackAction.maximumAttackDistance && distanceFromTarget >= enemyAttackAction.minimumAttackDistance)
            {
                if (viewableAngle <= enemyAttackAction.maximumAngle && viewableAngle >= enemyAttackAction.minimumAngle)
                {
                    maxScore += enemyAttackAction.attackScore;
                }
            }
        }

        int randomValue = Random.Range(0, maxScore);
        int tempScore = 0;

        for (int i = 0; i < enemyAttacks.Length; i++)
        {
            EnemyAttackAction enemyAttackAction = enemyAttacks[i];

            if (distanceFromTarget <= enemyAttackAction.maximumAttackDistance && distanceFromTarget >= enemyAttackAction.minimumAttackDistance)
            {
                if (viewableAngle <= enemyAttackAction.maximumAngle && viewableAngle >= enemyAttackAction.minimumAngle)
                {
                    if (attackState.currentAttack != null)
                        return;

                    tempScore += enemyAttackAction.attackScore;

                    if (tempScore > randomValue)
                    {
                        attackState.currentAttack = enemyAttackAction;
                    }
                }
            }
        }
    }

    private void walkAroundTarget(EnemyAnimatorManager enemyAnimatorManager)
    {
        verticalMovementValue = Random.Range(0,1);

        if(verticalMovementValue <= 1 && verticalMovementValue > 0)
        {
            verticalMovementValue = 0.5f;
        }
        else if(verticalMovementValue >= 0 && verticalMovementValue < 0)
        {
            verticalMovementValue = 0.5f;
        }

        horizontalMovementValue = Random.Range(-1,1);

        if(horizontalMovementValue <= 1 && horizontalMovementValue >= 0)
        {
            horizontalMovementValue = 0.5f;
        }
        else if(horizontalMovementValue >= 1 && horizontalMovementValue < 0)
        {
            horizontalMovementValue = -0.5f;
        }
    }
}
