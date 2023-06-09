using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Interactable
{
    
    // public WeaponItem weapon;
    public Item item;

    public override void Interact(PlayerManager playerManager)
    {
        base.Interact(playerManager);
        //pickup and add to inventory
        PickupItem(playerManager);
    }

    private void PickupItem(PlayerManager playerManager) {
        PlayerInventory playerInventory;
        PlayerMovement playerMovement;
        AnimationHandler animationHandler;

        playerInventory = playerManager.GetComponent<PlayerInventory>();
        playerMovement = playerManager.GetComponent<PlayerMovement>();
        animationHandler = playerManager.GetComponentInChildren<AnimationHandler>();

        playerMovement.characterController.velocity.Set(0,0,0);
        // animationHandler.PlayTargetAnimation("Pickup", true);
        playerInventory.AddToInventory(item);
        Destroy(gameObject);
    }

}
