using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentWindowUI : MonoBehaviour
{

    EquipmentSlot equipmentSlot;
    ItemInventorySlot itemInventorySlot;
    PlayerInventory playerInventory;
    WeaponSlotManager weaponSlotManager;
    ArmorSlotManager armorSlotManager;

    public EquipmentSlot rightWeaponSlot;
    public EquipmentSlot leftWeaponSlot;
    public EquipmentSlot headSlot;
    public EquipmentSlot chestSlot;
    public EquipmentSlot legsSlot;
    public EquipmentSlot feetSlot;
    public EquipmentSlot neckSlot;
    public EquipmentSlot handsSlot;
    public EquipmentSlot backSlot;

    private void Awake()
    {
        weaponSlotManager = FindObjectOfType<WeaponSlotManager>();
        armorSlotManager = FindObjectOfType<ArmorSlotManager>();
        itemInventorySlot = FindObjectOfType<ItemInventorySlot>();
        playerInventory = FindObjectOfType<PlayerInventory>();
    }

    public void PutInSlot(Item equipment)
    {
        switch(equipment.GetType().ToString())
        {
            case "WeaponItem":
                AddToWeaponSlot((WeaponItem)equipment);
                break;
            case "Helmet":
                AddToHeadSlot((Helmet)equipment);
                break;
            case "Chest":
                AddToChestSlot((Chest)equipment);
                break;
            case "Legs":
                AddToLegsSlot((Legs)equipment);
                break;
            case "Feet":
                AddToFeetSlot((Feet)equipment);
                break;
            case "Neck":
                AddToNeckSlot((Neck)equipment);
                break;
            case "Hands":
                AddToHandsSlot((Hands)equipment);
                break;
            case "Back":
                AddToBackSlot((Back)equipment);
                break;
            default:
                Debug.Log(equipment.GetType().ToString());
                break;
        }
    }

    public void AddToWeaponSlot(WeaponItem weapon)
    {
        if (!weapon.offHand)
        {
            rightWeaponSlot.AddWeapon(weapon);
            playerInventory.mainInventory.Remove(weapon);
            playerInventory.rightWeapon = weapon;
        }
        else if(weapon.offHand)
        {
            leftWeaponSlot.AddWeapon(weapon);
            playerInventory.mainInventory.Remove(weapon);
            playerInventory.leftWeapon = weapon;
        }
    }
    public void AddToHeadSlot(Helmet armor)
    {
        headSlot.EquipHead(armor);
        playerInventory.mainInventory.Remove(armor);
        playerInventory.headArmor = armor;
        
    }
    public void AddToChestSlot(Chest armor)
    {
        chestSlot.EquipChest(armor);
        playerInventory.mainInventory.Remove(armor);
        playerInventory.headArmor = armor;
    }

    public void AddToLegsSlot(Legs armor)
    {
        legsSlot.EquipLegs(armor);
        playerInventory.mainInventory.Remove(armor);
        playerInventory.headArmor = armor;
    }

    public void AddToFeetSlot(Feet armor)
    {
        feetSlot.EquipFeet(armor);
        playerInventory.mainInventory.Remove(armor);
        playerInventory.headArmor = armor;
    }

    public void AddToNeckSlot(Neck armor)
    {
        neckSlot.EquipNeck(armor);
        playerInventory.mainInventory.Remove(armor);
        playerInventory.headArmor = armor;
    }

    public void AddToHandsSlot(Hands armor)
    {
        handsSlot.EquipHands(armor);
        playerInventory.mainInventory.Remove(armor);
        playerInventory.headArmor = armor;
    }

    public void AddToBackSlot(Back armor)
    {
        backSlot.EquipBack(armor);
        playerInventory.mainInventory.Remove(armor);
        playerInventory.headArmor = armor;
    }

}
