using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorManager : MonoBehaviour
{
    public  PlayerStats playerStats;

    public int armorReduction;
    private int headArmor;
    private int chestArmor;
    private int legArmor;
    private int feetArmor;
    private int handsArmor;
    private int neckArmor;
    private int backArmor;

    public int strengthBonus;
    public int vitalityBonus;

    public void AddArmorBonus(int armorBonus,string slot)
    {
        armorReduction = armorReduction + armorBonus;
        switch(slot)
        {
            case "Head":
                headArmor = armorBonus;
                break;
            case "Chest":
                chestArmor = armorBonus;
                break;
            case "Legs":
                legArmor = armorBonus;
                break;
            case "Feet":
                feetArmor = armorBonus;
                break;
            case "Hands":
                handsArmor = armorBonus;
                break;
            case "Neck":
                neckArmor = armorBonus;
                break;
            case "Back":
                backArmor = armorBonus;
                break;
            default:
                break;
        }
        playerStats.armor = armorReduction;
    }

    public void ReduceArmorBonus(string slot)
    {
        switch(slot)
        {
            case "Head":
                armorReduction =- headArmor;
                headArmor = 0;
                break;
            case "Chest":
                armorReduction =- chestArmor;
                chestArmor = 0;
                break;
            case "Legs":
                armorReduction =- legArmor;
                legArmor = 0;
                break;
            case "Feet":
                armorReduction =- feetArmor;
                feetArmor = 0;
                break;
            case "Hands":
                armorReduction =- handsArmor;
                handsArmor = 0;
                break;
            case "Neck":
                armorReduction =- neckArmor;
                neckArmor = 0;
                break;
            case "Back":
                armorReduction =- backArmor;
                backArmor = 0;
                break;
            default:
                break;
        }
    }

    public void AddStatBonus(string stat,int bonus)
    {

    }

    public void ReduceStatBonus(string stat,int bonus)
    {

    }
}
