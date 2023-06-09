using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject playerCam;
    public GameObject uiCam;
    public GameObject sceneCamera;

    InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
    }

    public void SwitchCamera() {
        if(inputManager.inventoryFlag)
        {
            playerCam.SetActive(false);
            uiCam.SetActive(true);
        }
        else
        {
            playerCam.SetActive(true);
            uiCam.SetActive(false);
        }
    }

    public void SwitchToSceneCamera(int camera) {
        switch(camera) {
            case 1: playerCam.SetActive(false);
                sceneCamera.SetActive(true);
                break;
            default: playerCam.SetActive(true);
                sceneCamera.SetActive(false);
                break;
        }
    }
}
