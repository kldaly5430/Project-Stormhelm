using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PursueTargetState : State
{

    public CombatStanceState stanceState;
    public RotateTowardsEnemyState rotateTowardsEnemyState;

    public override State Tick(EnemyManager enemyManager, EnemyStats enemyStats, EnemyAnimatorManager enemyAnimatorManager)
    {
        // Chase target
        // if (enemyManager.isPerformingAction)
        // {
        //     enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
        //     return this;
        // }

        Vector3 targetDirection = enemyManager.currentTarget.transform.position - enemyManager.transform.position;
        float distanceFromTarget = Vector3.Distance(enemyManager.currentTarget.transform.position, enemyManager.transform.position);
        float viewableAngle = Vector3.SignedAngle(targetDirection,enemyManager.transform.forward,Vector3.up);

        HandleRotateTowardTarget(enemyManager);

        if(enemyManager.navMeshAgent.enabled == false)
        {
            if(viewableAngle > 35 || viewableAngle < -65)
            return rotateTowardsEnemyState;
        }

        if(enemyManager.isInteracting)
            return this;

        Debug.Log(enemyManager.navMeshAgent.enabled);
        if(enemyManager.navMeshAgent.enabled == true)
        {
            enemyAnimatorManager.animator.applyRootMotion = false;
            enemyAnimatorManager.animator.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);
        }
        if (distanceFromTarget > enemyManager.maxAggroRadius)
        {
            enemyAnimatorManager.animator.SetFloat("Vertical", 1, 0.1f, Time.deltaTime);

        }
        //else if (distanceFromTarget <= enemyManager.maxAggroRadius)
        //{
        //    Debug.Log("im suppose to stop");
        //    enemyAnimatorManager.animator.SetFloat("Vertical", 0, 0.1f, Time.deltaTime);
        //}

        HandleRotateTowardTarget(enemyManager);

        // enemyManager.navMeshAgent.transform.localPosition = Vector3.zero;
        // enemyManager.navMeshAgent.transform.localRotation = Quaternion.identity;

        if(distanceFromTarget <= enemyManager.maxAggroRadius)
        {
            enemyManager.navMeshAgent.enabled = false;
            enemyAnimatorManager.animator.applyRootMotion = true;
            return stanceState;
        }
        else
        {
            return this;
        }
        
    }

    private void HandleRotateTowardTarget(EnemyManager enemyManager)
    {
        // Rotate manually
        if (!enemyManager.isPerformingAction && enemyManager.navMeshAgent.enabled == false)
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
        // else
        // {
        //     Vector3 relativeDirection = transform.InverseTransformDirection(enemyManager.navMeshAgent.desiredVelocity);
        //     Vector3 targetVelocity = enemyManager.enemyRigidBody.velocity;

        //     enemyManager.navMeshAgent.enabled = true;
        //     enemyManager.navMeshAgent.SetDestination(enemyManager.currentTarget.transform.position);
        //     enemyManager.enemyRigidBody.velocity = targetVelocity;
        //     enemyManager.transform.rotation = Quaternion.Slerp(enemyManager.transform.rotation, enemyManager.navMeshAgent.transform.rotation, enemyManager.rotationSpeed / Time.deltaTime);
        // }
    }
}
