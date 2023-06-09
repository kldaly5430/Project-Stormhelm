using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Helmet,
    Chest,
    Legs,
    Feet,
    Hands,
    Neck,
    Back,
    Consumable
    /*
        Head
        Neck
        Body
        Legs
        Boots
        Ring 1
        Ring 2
        Back
        Hands
    */
}
public class Item : ScriptableObject
{

    public int ID;

    public GameObject prefab;
    public ItemType type;

    [Header("Item Information")]
    public Sprite itemIcon;
    public string itemName;
    [TextArea(10, 20)]
    public string description;
}
