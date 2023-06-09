using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Weapon")]

public class WeaponItem : Item
{
    // public GameObject modelPrefab;
    public bool unarmed;
    public bool offHand;

    [Header("Damage")]
    public int baseDamage;

    [Header("Idle Animations")]
    public string rightHandIdle;
    public string leftHandIdle;

    [Header("One Handed Attack Animation")]
    public string OH_Attack_Light_01;
    public string OH_Attack_Light_02;
    public string OH_Attack_Heavy_01;

    [Header("Weapon Type")]
    public bool isMelee;
    public bool isShield;

    private void Awake() {
        type = ItemType.Weapon;
    }
}
