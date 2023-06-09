using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{

    WeaponSlotManager weaponSlotManager;
    ArmorSlotManager armorSlotManager;
    PlayerInventory playerInventory;
    ArmorManager armorManager;
    //UIManager uiManager;

    public Item item;
    public Image icon;

    public bool isEquipped;

    private void Awake()
    {
        weaponSlotManager = FindObjectOfType<WeaponSlotManager>();
        playerInventory = FindObjectOfType<PlayerInventory>();
        armorSlotManager = FindObjectOfType<ArmorSlotManager>();
        armorManager = FindObjectOfType<ArmorManager>();
        //uiManager = FindObjectOfType<UIManager>();
    }

    public void AddWeapon(WeaponItem weapon)
    {
        if (!weapon.offHand)
        {
            if (isEquipped)
            {
                UnequipRightWeapon();
                icon.enabled = true;
                item = weapon;
                icon.sprite = weapon.itemIcon;
                weaponSlotManager.LoadWeaponOnSlot(weapon, false);
                isEquipped = true;
            }
            else
            {
                item = weapon;
                icon.enabled = true;
                icon.sprite = weapon.itemIcon;
                weaponSlotManager.LoadWeaponOnSlot(weapon, false);
                isEquipped = true;
            }
            
        }
        else if (weapon.offHand)
        {
            if(isEquipped)
            {
                UnequipLeftWeapon();
                item = weapon;
                icon.enabled = true;
                icon.sprite = weapon.itemIcon;
                weaponSlotManager.LoadWeaponOnSlot(weapon, true);
                isEquipped = true;
            }
            else
            {
                item = weapon;
                icon.enabled = true;
                icon.sprite = weapon.itemIcon;
                weaponSlotManager.LoadWeaponOnSlot(weapon, true);
                isEquipped = true;
            }
            
        }
    }

    public void EquipHead(Helmet armor)
    {
        if(isEquipped)
        {
            UnEquipHeadSlot();
            icon.enabled = true;
            icon.sprite = armor.itemIcon;
            item = armor;
            armorSlotManager.LoadHelmetSlot(armor.model);
            armorManager.AddArmorBonus(armor.baseDefence,armor.armorPiece.ToString());
            isEquipped = true;
        }
        else
        {
            icon.enabled = true;
            icon.sprite = armor.itemIcon;
            item = armor;
            armorSlotManager.LoadHelmetSlot(armor.model);
            armorManager.AddArmorBonus(armor.baseDefence,armor.armorPiece.ToString());
            isEquipped = true;
        }
        
    }
    public void EquipChest(Chest armor)
    {
        if(isEquipped)
        {
            UnEquipChestSlot();
            icon.enabled = true;
            icon.sprite = armor.itemIcon;
            item = armor;
            armorSlotManager.LoadChestSlot(armor.model,armor.rightUpperArm,armor.leftUpperArm);
            armorManager.AddArmorBonus(armor.baseDefence,armor.armorPiece.ToString());
            isEquipped = true;
        }
        else
        {
            icon.enabled = true;
            icon.sprite = armor.itemIcon;
            item = armor;
            armorSlotManager.LoadChestSlot(armor.model,armor.rightUpperArm,armor.leftUpperArm);
            armorManager.AddArmorBonus(armor.baseDefence,armor.armorPiece.ToString());
            isEquipped = true;
        }
    }
    public void EquipLegs(Legs armor)
    {
        if(isEquipped)
        {
            UnEquipLegsSlot();
            icon.enabled = true;
            icon.sprite = armor.itemIcon;
            item = armor;
            armorSlotManager.LoadLegSlot(armor.model);
            armorManager.AddArmorBonus(armor.baseDefence,armor.armorPiece.ToString());
            isEquipped = true;
        }
        else
        {
            icon.enabled = true;
            icon.sprite = armor.itemIcon;
            item = armor;
            armorSlotManager.LoadLegSlot(armor.model);
            armorManager.AddArmorBonus(armor.baseDefence,armor.armorPiece.ToString());
            isEquipped = true;
        }
    }

    public void EquipHands(Hands armor)
    {
        if(isEquipped)
        {
            UnEquipHandsSlot();
            icon.enabled = true;
            icon.sprite = armor.itemIcon;
            item = armor;
            armorSlotManager.LoadHandsSlot(armor.model,armor.offHand,armor.LowerArm,armor.offHandLowerArm);
            armorManager.AddArmorBonus(armor.baseDefence,armor.armorPiece.ToString());
            isEquipped = true;
        }
        else
        {
            icon.enabled = true;
            icon.sprite = armor.itemIcon;
            item = armor;
            armorSlotManager.LoadHandsSlot(armor.model,armor.offHand,armor.LowerArm,armor.offHandLowerArm);
            armorManager.AddArmorBonus(armor.baseDefence,armor.armorPiece.ToString());
            isEquipped = true;
        }
    }

    public void EquipFeet(Feet armor)
    {
        if(isEquipped)
        {
            UnEquipFeetSlot();
            icon.enabled = true;
            icon.sprite = armor.itemIcon;
            item = armor;
            armorSlotManager.LoadFeetSlot(armor.model, armor.leftFoot);
            armorManager.AddArmorBonus(armor.baseDefence,armor.armorPiece.ToString());
            isEquipped = true;
        }
        else
        {
            icon.enabled = true;
            icon.sprite = armor.itemIcon;
            item = armor;
            armorSlotManager.LoadFeetSlot(armor.model, armor.leftFoot);
            armorManager.AddArmorBonus(armor.baseDefence,armor.armorPiece.ToString());
            isEquipped = true;
        }
    }

    public void EquipNeck(Neck armor)
    {
        if(isEquipped)
        {

        }
        else
        {
            
        }
    }

    public void EquipBack(Back armor)
    {
        if(isEquipped)
        {

        }
        else
        {
            
        }
    }

    public void UnequipRightWeapon()
    {
        playerInventory.AddToInventory(item);
        item = null;
        icon.enabled = false;
        icon.sprite = null;
        weaponSlotManager.LoadWeaponOnSlot(null, false);
        isEquipped = false;
    }

    public void UnequipLeftWeapon()
    {
        playerInventory.AddToInventory(item);
        item = null;
        icon.enabled = false;
        icon.sprite = null;
        weaponSlotManager.LoadWeaponOnSlot(null, true);
        isEquipped = false;
    }

    public void UnEquipHeadSlot()
    {
        playerInventory.AddToInventory(item);
        item = null;
        icon.enabled = false;
        icon.sprite = null;
        armorSlotManager.LoadCharacterHeadDefault();
        armorManager.ReduceArmorBonus("Head");
        isEquipped = false;
    }

    public void UnEquipChestSlot()
    {
        playerInventory.AddToInventory(item);
        item = null;
        icon.enabled = false;
        icon.sprite = null;
        armorSlotManager.LoadCharacterChestDefault();
        armorManager.ReduceArmorBonus("Chest");
        isEquipped = false;
    }

    public void UnEquipLegsSlot()
    {
        playerInventory.AddToInventory(item);
        item = null;
        icon.enabled = false;
        icon.sprite = null;
        armorSlotManager.LoadCharacterLegsDefault();
        armorManager.ReduceArmorBonus("Legs");
        isEquipped = false;
    }

    public void UnEquipFeetSlot()
    {
        playerInventory.AddToInventory(item);
        item = null;
        icon.enabled = false;
        icon.sprite = null;
        armorSlotManager.LoadCharacterFeetDefault();
        armorManager.ReduceArmorBonus("Feet");
        
        isEquipped = false;
    }

    public void UnEquipHandsSlot()
    {
        playerInventory.AddToInventory(item);
        item = null;
        icon.enabled = false;
        icon.sprite = null;
        armorSlotManager.LoadCharacterHandsDefault();
        armorManager.ReduceArmorBonus("Hands");
        isEquipped = false;
    }

    public void UnEquipNeckSlot()
    {

    }

    public void UnEquipBackSlot()
    {

    }

}
