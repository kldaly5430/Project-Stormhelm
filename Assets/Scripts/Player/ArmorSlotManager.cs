using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorSlotManager : MonoBehaviour
{
    // PlayerManager playerManager;
    //PlayerStats playerStats;
    BaseCharacterModel baseCharacterModel;

    // public ArmorHolderSlot headSlot;


    private void Awake()
    {
        baseCharacterModel = GetComponent<BaseCharacterModel>();
    }
    public void LoadHelmetSlot(string name)
    {
        baseCharacterModel.SetHeadModel(name);
    }

    public void LoadChestSlot(string name,string rightUpperArm,string leftUpperArm)
    {
        baseCharacterModel.SetChestModel(name,rightUpperArm,leftUpperArm);
    }

    public void LoadLegSlot(string name)
    {
        baseCharacterModel.SetLegModel(name);
    }

    public void LoadFeetSlot(string name,string leftName)
    {
        baseCharacterModel.SetFeetModel(name,leftName);
    }

    public void LoadHandsSlot(string name,string offHand,string lowerArm, string offHandLowerArm)
    {
        baseCharacterModel.SetHandsModel(name,offHand,lowerArm,offHandLowerArm);
    }

    public void LoadCharacterHeadDefault()
    {
        baseCharacterModel.UnEquipHeadModel();
    }

    public void LoadCharacterChestDefault()
    {
        baseCharacterModel.UnEquipChestModel();
    }

    public void LoadCharacterLegsDefault()
    {
        baseCharacterModel.UnEquipLegsModel();
    }

    public void LoadCharacterFeetDefault()
    {
        baseCharacterModel.UnEquipFeetModel();
    }

    public void LoadCharacterHandsDefault()
    {
        baseCharacterModel.UnEquipHandsModel();
    }
}
