using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollowPathState : NPCState
{
    public NPCRotateTowardsState npcRotateTowardsState;
    public override NPCState Tick(NPCManager npcManager, NPCAnimationHandler npcAnimationHandler)
    {
        Vector3 targetDirection = npcManager.currentTarget.transform.position - npcManager.transform.position;
        float distanceFromTarget = Vector3.Distance(npcManager.currentTarget.transform.position,npcManager.transform.position);
        float viewableAngle = Vector3.SignedAngle(targetDirection,npcManager.transform.forward,Vector3.up);

        if(viewableAngle > 35 || viewableAngle < -65)
            return npcRotateTowardsState;

        if(npcManager.isInteracting)
            return this;

        if(distanceFromTarget > npcManager.interactionRange)
        {
            npcAnimationHandler.animator.SetFloat("Vertical",1,0.1f,Time.deltaTime);
        }

        HandleRotateTowardTarget(npcManager);

        return this;


    }
    private void HandleRotateTowardTarget(NPCManager npcManager)
    {
        if(!npcManager.isInteracting)
        {
            Vector3 direction = npcManager.currentTarget.transform.position - transform.position;
            direction.y = 0;
            direction.Normalize();

            if(direction == Vector3.zero)
            {
                direction = transform.forward;
            }

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            npcManager.transform.rotation = Quaternion.Slerp(npcManager.transform.rotation, npcManager.navMeshAgent.transform.rotation, npcManager.rotationSpeed/Time.deltaTime);
        }
        else
        {
            Vector3 relativeDirection = transform.InverseTransformDirection(npcManager.navMeshAgent.desiredVelocity);
            Vector3 targetVelocity = npcManager.npcRigidbody.velocity;

            npcManager.navMeshAgent.enabled = true;
            npcManager.navMeshAgent.SetDestination(npcManager.currentTarget.transform.position);
            npcManager.npcRigidbody.velocity = targetVelocity;
            npcManager.transform.rotation = Quaternion.Slerp(npcManager.transform.rotation, npcManager.navMeshAgent.transform.rotation, npcManager.rotationSpeed/Time.deltaTime);
        }
    }
}
