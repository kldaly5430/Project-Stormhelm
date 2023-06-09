using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationHandler : AnimationHandler
{

    NPCManager npcManager;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        npcManager = GetComponent<NPCManager>();
    }

    private void OnAnimatorMove() {
        float delta = Time.deltaTime;
        npcManager.npcRigidbody.drag = 0;
        Vector3 deltaPosition = animator.deltaPosition;
        deltaPosition.y = 0;
        Vector3 velocity = deltaPosition / delta;
        npcManager.npcRigidbody.velocity = velocity;

        if(npcManager.isRotatingWithRootMotion)
        {
            npcManager.transform.rotation *= animator.deltaRotation;
        }
    }
}
