using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    NPCManager npcManager;
    NPCAnimationHandler npcAnimationHandler;

    private void Awake()
    {
        npcManager = GetComponent<NPCManager>();
        npcAnimationHandler = GetComponent<NPCAnimationHandler>();
    }
}
