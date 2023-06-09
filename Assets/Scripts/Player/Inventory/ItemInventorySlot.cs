using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemInventorySlot : MonoBehaviour
{
    
    PlayerInventory playerInventory;
    UIManager uIManager;
    PlayerStats playerStats;
    EquipmentWindowUI equipmentWindowUI;

    public Image icon;
    public Item item;
    public Transform origParent = null;

    private void Awake() {
        equipmentWindowUI = FindObjectOfType<EquipmentWindowUI>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        uIManager = FindObjectOfType<UIManager>();
        playerStats = FindObjectOfType<PlayerStats>();
    }

    public void AddItem(Item newItem) {
        item = newItem;
        icon.sprite = item.itemIcon;
        icon.enabled = true;
        gameObject.SetActive(true);
        icon.color = new Color(1, 1, 1, 1);

    }

    public void ClearInventorySlot() {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        if(item != null)
        {
            switch (item.GetType().ToString())
            {
                case "WeaponItem": EquipItem();
                    break;
                case "Consumable": Consume((Consumable)this.item);
                    break;
                case "Helmet": EquipItem();
                    break;
                case "Chest": EquipItem();
                    break;
                case "Legs": EquipItem();
                    break;
                case "Feet": EquipItem();
                    break;
                case "Hands": EquipItem();
                    break;
                default: Debug.Log("Slot empty" + item.GetType().ToString());
                    break;
            }
        }
    }

    public void EquipItem() {
        if(item.GetType() == typeof(WeaponItem))
        {
            //Debug.Log(this.item);
            equipmentWindowUI.PutInSlot(this.item);
            ClearInventorySlot();
        }
        else if(item.GetType() == typeof(Helmet) || item.GetType() == typeof(Chest) || item.GetType() == typeof(Legs) || item.GetType() == typeof(Feet) || item.GetType() == typeof(Hands))
        {
            equipmentWindowUI.PutInSlot(this.item);
            ClearInventorySlot();
        }
    }

    public void Consume(Consumable consumable)
    {
        playerStats.Heal(consumable.restorationValue);
        playerInventory.mainInventory.Remove(consumable);
        ClearInventorySlot();
    }
}
