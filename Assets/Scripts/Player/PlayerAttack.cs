using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    AnimationHandler animationHandler;
    InputManager inputManager;
    public PlayerManager playerManager;
    public string lastAttack;

    private void Awake() {
        animationHandler = GetComponentInChildren<AnimationHandler>();
        inputManager = GetComponent<InputManager>();
        playerManager = GetComponent<PlayerManager>();
    }

    public void HandleWeaponCombo(WeaponItem weapon)
    {
        if(inputManager.comboFlag)
        {
            animationHandler.animator.SetBool("canCombo", false);
            Debug.Log("Handled combo");
            if(lastAttack == weapon.OH_Attack_Light_01)
            {
                animationHandler.PlayTargetAnimation(weapon.OH_Attack_Light_02, true);
            }
        }
    }

    public void HandleLightAttack(WeaponItem weapon){
        animationHandler.PlayTargetAnimation(weapon.OH_Attack_Light_01, true);
        lastAttack = weapon.OH_Attack_Light_01;
    }

    public void HandleHeavyAttack(WeaponItem weapon){
        animationHandler.PlayTargetAnimation(weapon.OH_Attack_Heavy_01, true);
    }

    public void HanldeBlockAction()
    {
        if (playerManager.isInteracting)
            return;
        
        if (playerManager.isBlocking)
            return;

        animationHandler.PlayTargetAnimation("Start Block", false);
        playerManager.isBlocking = true;
        Debug.Log(playerManager.isBlocking);

    }
}
