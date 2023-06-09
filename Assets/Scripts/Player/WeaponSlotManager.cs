using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlotManager : MonoBehaviour
{

    PlayerManager playerManager;
    //PlayerStats playerStats;
    
    WeaponHolderSlot leftSlot;
    WeaponHolderSlot rightSlot;

    DamageCollider leftHandDamageCollider;
    DamageCollider rightHandDamageCollider;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerManager = GetComponentInParent<PlayerManager>();
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if(weaponSlot.isLeftHandSlot)
            {
                leftSlot = weaponSlot;
            }
            else if(weaponSlot.isRightHandSlot)
            {
                rightSlot = weaponSlot;
            }
        }
    }

    public void LoadWeaponOnSlot(WeaponItem weaponItem, bool isLeft) 
    {
        if(isLeft)
        {
            leftSlot.LoadWeaponModel(weaponItem);
            LoadLeftHandDamageCollider();

            #region Left Weapon Idle Animation
            if(weaponItem != null)
            {
                animator.CrossFade(weaponItem.leftHandIdle, 0.2f);
            }
            else
            {
                animator.CrossFade("Left Arm Empty", 0.2f);
            }
            #endregion
        } 
        else
        {
            rightSlot.LoadWeaponModel(weaponItem);
            LoadRightHandDamageCollider();

            #region Right Weapon Idle Animation
            if(weaponItem != null)
            {
                animator.CrossFade(weaponItem.rightHandIdle, 0.2f);
            }
            else
            {
                animator.CrossFade("Right Arm Empty", 0.2f);
            }
            #endregion
        }
    }

    #region Handle Weapon Damage
    private void LoadLeftHandDamageCollider()
    {
        leftHandDamageCollider = leftSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    private void LoadRightHandDamageCollider()
    {
        rightHandDamageCollider = rightSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
    }

    public void OpenDamageCollider()
    {
            rightHandDamageCollider.EnableDamageCollider();
            // leftHandDamageCollider.EnableDamageCollider();
    }

    public void CloseDamageCollider()
    {
            rightHandDamageCollider.DisableDamageCollider();
            // leftHandDamageCollider.DisableDamageCollider();
    }
    #endregion
}
