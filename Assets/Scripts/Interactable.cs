using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float radius = 0.6f;
    public string interactableText;

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public virtual void Interact(PlayerManager playerManager) {
        //Called when player interacts
        Debug.Log("Interacted with weapon");
    }

    public virtual void Talk(PlayerManager playerManager)
    {
        Debug.Log("Talking with NPC");
    }

}
