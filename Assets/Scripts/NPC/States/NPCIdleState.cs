using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIdleState : NPCState
{
    public LayerMask detectionLayer;

    public override NPCState Tick(NPCManager npcManager, NPCAnimationHandler npcAnimationHandler)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, npcManager.interactionRange, detectionLayer);

        for (int i = 0; i < colliders.Length; i++)
        {
            CharacterStats characterStats = colliders[i].transform.GetComponent<CharacterStats>();
            if(characterStats != null)
            {
                Vector3 targetDirection = characterStats.transform.position - transform.position;
                float viewableAngle = Vector3.Angle(targetDirection, transform.forward);

                return this;
            }
        }

        return this;
    }
}
