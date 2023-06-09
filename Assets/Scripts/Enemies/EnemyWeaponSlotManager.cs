using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponSlotManager : MonoBehaviour
{

    public WeaponItem rightHandWeapon;
    public WeaponItem leftHandWeapon;

    WeaponHolderSlot rightSlot;
    WeaponHolderSlot leftSlot;

    DamageCollider rightCollider;
    DamageCollider leftCollider;

    private void Awake()
    {
        WeaponHolderSlot[] weaponHolderSlots = GetComponentsInChildren<WeaponHolderSlot>();
        foreach (WeaponHolderSlot weaponSlot in weaponHolderSlots)
        {
            if (weaponSlot.isLeftHandSlot)
            {
                leftSlot = weaponSlot;
            }
            else if (weaponSlot.isRightHandSlot)
            {
                rightSlot = weaponSlot;
            }
        }
    }

    private void Start()
    {
        LoadWeaponInHands();
    }

    public void LoadWeaponOnSlot(WeaponItem weapon, bool isLeft)
    {
        if (isLeft)
        {
            leftSlot.currentWeapon = weapon;
            leftSlot.LoadWeaponModel(weapon);
            //load weapon damage collider
        }
        else
        {
            rightSlot.currentWeapon = weapon;
            rightSlot.LoadWeaponModel(weapon);
            LoadWeaponsDamageCollider(false);
        }
    }

    public void LoadWeaponInHands()
    {
        if (rightHandWeapon != null)
        {
            LoadWeaponOnSlot(rightHandWeapon, false);
        }
        if (leftHandWeapon != null)
        {
            LoadWeaponOnSlot(leftHandWeapon, true);
        }
    }

    public void LoadWeaponsDamageCollider(bool isLeft)
    {
        if (isLeft)
        {
            leftCollider = leftSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }
        else
        {
            Debug.Log("is loaded");
            rightCollider = rightSlot.currentWeaponModel.GetComponentInChildren<DamageCollider>();
        }
    }

    public void OpenDamageCollider()
    {
        rightCollider.EnableDamageCollider();
    }

    public void CloseDamageCollider()
    {
        rightCollider.DisableDamageCollider();
    }

}
