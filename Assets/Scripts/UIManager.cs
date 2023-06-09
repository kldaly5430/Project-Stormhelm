using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

public class UIManager : MonoBehaviour
{

    // public PlayerInventory playerInventory;
    
    [Header("Windows")]
    public GameObject hudWindow;
    public GameObject uiWindows;
    public GameObject inventoryWindow;

    public GameObject DialogWindow;
    public GameObject dialogName;
    public GameObject dialogContinue;

    [Header("Inventory")]
    public GameObject inventorySlotPrefab;
    public Transform inventorySlotParent;
    public List<GameObject> slots = new List<GameObject>();

    private void Start() {
        foreach (GameObject slot in GameObject.FindGameObjectsWithTag("Slot"))
        {
            slots.Add(slot);
        }
        uiWindows.SetActive(false);
    }

    public void OpenInventory() {
        uiWindows.SetActive(true);
        inventoryWindow.SetActive(true);
    }

    public void CloseInventory() {
        uiWindows.SetActive(false);
        inventoryWindow.SetActive(false);
    }

    public void OpenDialogWindow()
    {
        DialogWindow.SetActive(true);
    }

    public void CloseDialogWindow()
    {
        DialogWindow.SetActive(false);
    }

    public void ShowContinueDialog()
    {
        dialogContinue.SetActive(true);
    }

    public void HideContinueDialog()
    {
        dialogContinue.SetActive(false);
    }

}