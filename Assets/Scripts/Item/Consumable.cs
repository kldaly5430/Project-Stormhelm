using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Consumable")]
public class Consumable : Item
{

    // public GameObject modelPrefab;
    public int restorationValue;

    private void Awake() {
        type = ItemType.Consumable;
    }
}
