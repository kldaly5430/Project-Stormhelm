using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    WeaponSlotManager WeaponSlotManager;

    public WeaponItem rightWeapon;
    public WeaponItem leftWeapon;
    public ArmorItem headArmor;

    // public List<WeaponItem> weaponsInventory;
    public List<Item> mainInventory;
    public List<Item> equippedItems;

    UIManager uiManager;
    public ItemInventorySlot[] itemInventorySlot;

    private void Awake() {
        WeaponSlotManager = GetComponentInChildren<WeaponSlotManager>();
        uiManager = FindObjectOfType<UIManager>();
        itemInventorySlot = uiManager.inventorySlotParent.GetComponentsInChildren<ItemInventorySlot>();
    }

    private void Start() {
        // WeaponSlotManager.LoadWeaponOnSlot(rightWeapon, false);
        // WeaponSlotManager.LoadWeaponOnSlot(leftWeapon, true);
    }

    public void AddToInventory(Item newItem)
    {
        int slot = CheckForEmptySlots();
        if (slot != -1)
        {
            
            mainInventory.Add(newItem);
            itemInventorySlot[slot].AddItem(newItem);
        }
    }

    public int CheckForEmptySlots()
    {
        for (int i = 0; i < itemInventorySlot.Length; i++)
        {
            if(itemInventorySlot[i].item == null)
            {
                return i;
            }
        }
        return -1;
    }
}
