using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseCharacterModel : MonoBehaviour
{
    public GameObject baseHair;
    public GameObject baseHead;
    public GameObject baseFacialHair;
    public GameObject baseEyeBrows;
    public GameObject baseTorso;
    public GameObject baseLegs;
    public GameObject baseRightFoot;
    public GameObject baseLeftFoot;

    
    private GameObject currentHair;
    private GameObject currentHead;
    private GameObject currentFacialHair;
    private GameObject currentEyeBrows;
    private GameObject currentTorso;
    private GameObject currentLegs;
    private GameObject currentRightFoot;
    private GameObject currentLeftFoot;
    private GameObject currentUpperRightArm;
    private GameObject currentUpperLeftArm;
    private GameObject currentLowerRightArm;
    private GameObject currentLowerLeftArm;
    private GameObject currentRightHand;
    private GameObject currentLeftHand;

    private void Awake() {
        baseHair = GetHair();
        baseHead = GetHead();
        baseEyeBrows = GetEyebrows();
        baseFacialHair = GetFacialHair();
        baseTorso = GetTorso();
        baseLegs = GetLegs();
        baseRightFoot = GetRightfoot();
        baseLeftFoot = GetLeftfoot();
    }

    public void SetHeadModel(string head)
    {
        if(currentHead != null)
        {
            UnEquipHeadModel();
        }
        if(baseHair != null)
        {
            baseHair.SetActive(false);
        }
        baseEyeBrows.SetActive(false);
        baseFacialHair.SetActive(false);
        currentHead = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_00_Head/Male_Head_No_Elements/"+head);
        currentHead.SetActive(true);
    }

    public void SetChestModel(string chest,string rightUpperArm,string leftUpperArm)
    {
        if(currentTorso != null)
        {
            UnEquipChestModel();
        }
        try
        {
            baseTorso.SetActive(false);
            currentTorso = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_03_Torso/"+chest);
            currentUpperRightArm = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_04_Arm_Upper_Right/"+rightUpperArm);
            currentUpperLeftArm =GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_05_Arm_Upper_Left/"+leftUpperArm);
            currentTorso.SetActive(true);
            currentUpperRightArm.SetActive(true);
            currentUpperLeftArm.SetActive(true);
        }
        catch(Exception ex)
        {
            Debug.Log(ex);
            baseTorso.SetActive(true);
        }
    }

    public void SetLegModel(string leg)
    {
        if(currentLegs != null)
        {
            UnEquipLegsModel();
        }
        baseLegs.SetActive(false);
        currentLegs = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_10_Hips/"+leg);
        currentLegs.SetActive(true);
    }

    public void SetFeetModel(string feet,string leftFoot)
    {
        if(currentRightFoot != null || currentLeftFoot != null)
        {
            UnEquipFeetModel();
        }
        baseRightFoot.SetActive(false);
        baseLeftFoot.SetActive(false);
        currentRightFoot = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_11_Leg_Right/"+feet);
        currentLeftFoot = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_12_Leg_Left/"+leftFoot);
        currentRightFoot.SetActive(true);
        currentLeftFoot.SetActive(true);
    }

    public void SetHandsModel(string hand,string offHand,string lowerArm,string offHandLowerArm)
    {
        if(currentRightHand != null || currentLeftHand != null)
        {
            UnEquipHandsModel();
        }
        currentLowerRightArm = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_06_Arm_Lower_Right/"+lowerArm);
        currentLowerLeftArm = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_07_Arm_Lower_Left/"+offHandLowerArm);
        currentRightHand = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_08_Hand_Right/"+hand);
        currentLeftHand = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_09_Hand_Left/"+offHand);
        currentLowerRightArm.SetActive(true);
        currentLowerLeftArm.SetActive(true);
        currentRightHand.SetActive(true);
        currentLeftHand.SetActive(true);

    }
    public void UnEquipHeadModel()
    {
        if(baseHair != null)
        {
            baseHair.SetActive(true);
        }
        baseEyeBrows.SetActive(true);
        baseFacialHair.SetActive(true);
        currentHead.SetActive(false);
        currentHead = null;
    }

    public void UnEquipChestModel()
    {
        currentTorso.SetActive(false);
        currentUpperRightArm.SetActive(false);
        currentUpperLeftArm.SetActive(false);
        currentTorso = null;
        currentUpperRightArm = null;
        currentUpperLeftArm = null;
        baseTorso.SetActive(true);
        //base upper arms set active
    }

    public void UnEquipLegsModel()
    {
        currentLegs.SetActive(false);
        currentLegs = null;
        baseLegs.SetActive(true);
    }

    public void UnEquipFeetModel()
    {
        currentRightFoot.SetActive(false);
        currentLeftFoot.SetActive(false);
        currentRightFoot = null;
        currentLeftFoot = null;
        baseRightFoot.SetActive(true);
        baseLeftFoot.SetActive(true);
    }

    public void UnEquipHandsModel()
    {
        currentLowerRightArm.SetActive(false);
        currentLowerLeftArm.SetActive(false);
        currentRightHand.SetActive(false);
        currentLeftHand.SetActive(false);
        currentLowerRightArm = null;
        currentLowerLeftArm = null;
        currentRightHand = null;
        currentLeftHand = null;
    }

    public GameObject GetHair()
    {
        GameObject hair = GameObject.Find("All_01_Hair");
        GameObject activeHair = null;
        for(int i = 0; i < hair.transform.childCount; i++)
        {
            if(hair.transform.GetChild(i).gameObject.activeSelf == true)
            {
                activeHair = hair.transform.GetChild(i).gameObject;
            }
        }
        if(activeHair == null)
        {
            activeHair = GameObject.Find("Chr_Hair_01");
        }
        return activeHair;
    }
    public GameObject GetHead()
    {
        GameObject head = GameObject.Find("Chr_Head_Male_00");
        GameObject activeHead = null;
        for(int i = 0; i < head.transform.childCount; i++)
        {
            if(head.transform.GetChild(i).gameObject.activeSelf == true)
            {
                activeHead = head.transform.GetChild(i).gameObject;
            }
        }
        if(activeHead == null)
        {
            activeHead = GameObject.Find("Chr_Head_Male_00");
        }
        return activeHead;
    }
    public GameObject GetFacialHair()
    {
        GameObject facialHair = GameObject.Find("Male_02_FacialHair");
        GameObject activeFacialHair = null;
        for(int i = 0; i < facialHair.transform.childCount; i++)
        {
            if(facialHair.transform.GetChild(i).gameObject.activeSelf == true)
            {
                activeFacialHair = facialHair.transform.GetChild(i).gameObject;
            }
        }
        if(activeFacialHair == null)
        {
            activeFacialHair = GameObject.Find("Chr_FacialHair_Male_01");
        }
        return activeFacialHair;
    }
    public GameObject GetEyebrows()
    {
        GameObject eyebrows = GameObject.Find("Male_01_Eyebrows");
        GameObject activeEyebrows = null;
        for(int i = 0; i < eyebrows.transform.childCount; i++)
        {
            if(eyebrows.transform.GetChild(i).gameObject.activeSelf == true)
            {
                activeEyebrows = eyebrows.transform.GetChild(i).gameObject;
            }
        }
        if(activeEyebrows == null)
        {
            activeEyebrows = GameObject.Find("Chr_Eyebrow_Male_01");
        }
        return activeEyebrows;
    }
    public GameObject GetTorso()
    {
        GameObject torso = GameObject.Find("Male_03_Torso");
        GameObject activeTorso = null;
        for(int i = 0; i < torso.transform.childCount; i++)
        {
            if(torso.transform.GetChild(i).gameObject.activeSelf == true)
            {
                activeTorso = torso.transform.GetChild(i).gameObject;
            }
        }
        if(activeTorso == null)
        {
            activeTorso = GameObject.Find("Chr_Torso_Male_00");
        }
        return activeTorso;
    }
    public GameObject GetLegs()
    {
        GameObject legs = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_10_Hips");
        GameObject activeLegs = null;
        for(int i = 0; i < legs.transform.childCount; i++)
        {
            if(legs.transform.GetChild(i).gameObject.activeSelf == true)
            {
                activeLegs = legs.transform.GetChild(i).gameObject;
            }
        }
        if(activeLegs == null)
        {
            activeLegs = GameObject.Find("Chr_Hips_Male_00");
        }
        return activeLegs;
    }

    public GameObject GetRightfoot()
    {
        GameObject rightFoot = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_11_Leg_Right");
        GameObject activeRightFoot = null;
        for(int i = 0; i < rightFoot.transform.childCount; i++)
        {
            if(rightFoot.transform.GetChild(i).gameObject.activeSelf == true)
            {
                activeRightFoot = rightFoot.transform.GetChild(i).gameObject;
            }
        }
        if(activeRightFoot == null)
        {
            activeRightFoot = GameObject.Find("Chr_LegRight_Male_00");
        }
        return activeRightFoot;
    }
        public GameObject GetLeftfoot()
    {
        GameObject LeftFoot = GameObject.Find("Player/ModularCharacters/Modular_Characters/Male_Parts/Male_12_Leg_Left");
        GameObject activeLeftFoot = null;
        for(int i = 0; i < LeftFoot.transform.childCount; i++)
        {
            if(LeftFoot.transform.GetChild(i).gameObject.activeSelf == true)
            {
                activeLeftFoot = LeftFoot.transform.GetChild(i).gameObject;
            }
        }
        if(activeLeftFoot == null)
        {
            activeLeftFoot = GameObject.Find("Chr_LegLeft_Male_00");
        }
        return activeLeftFoot;
    }
}
