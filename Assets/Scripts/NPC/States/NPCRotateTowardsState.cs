using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRotateTowardsState : NPCState
{
    public override NPCState Tick(NPCManager npcManager, NPCAnimationHandler npcAnimationHandler)
    {
        npcAnimationHandler.animator.SetFloat("Vertical",0);
        npcAnimationHandler.animator.SetFloat("Hortizontal",0);

        if(npcManager.isInteracting)
            return this;

        Vector3 targetDirection = npcManager.currentTarget.transform.position - npcManager.transform.position;
        float viewableAngle = Vector3.SignedAngle(targetDirection, npcManager.transform.forward,Vector3.up);
        if(viewableAngle <= -45 && viewableAngle >= -100 && !npcManager.isInteracting)
        {
            npcAnimationHandler.PlayTargetAnimationWithRootAnimation("Right Turn",true);
            return this;
        }
        else if(viewableAngle >= 45 && viewableAngle <= 100 && !npcManager.isInteracting)
        {
            npcAnimationHandler.PlayTargetAnimationWithRootAnimation("Left Turn",true);
            return this;
        }

        return this;
    }
}
