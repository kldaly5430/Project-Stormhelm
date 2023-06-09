using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkToNPC : Interactable
{
    public Dialog dialog;
    public override void Talk(PlayerManager playerManager)
    {
        base.Talk(playerManager);
        TalkWith(playerManager);
    }
    
    private void TalkWith(PlayerManager playerManager)
    {
        PlayerMovement playerMovement;
        
        FindObjectOfType<DialogManager>().FirstEncounter(dialog);
        playerMovement = playerManager.GetComponent<PlayerMovement>();
        playerMovement.characterController.velocity.Set(0,0,0);;
        playerManager.isTalking = true;
    }
}
