using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ArmorItem : Item
{
    public enum armorType {head,neck,chest,legs,hand,feet};
    public armorType armorPiece;
    public string model;

    [Header("Defence")]
    public int baseDefence;

    private void Awake() {
        type = ItemType.Helmet;
    }
}
