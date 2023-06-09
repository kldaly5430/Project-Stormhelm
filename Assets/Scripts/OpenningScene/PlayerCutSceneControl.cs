using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerCutSceneControl : MonoBehaviour
{
    private InputManager inputManager;
    private Animator animator;
    private DialogManager dialogManager;
    private TalkToNPC talkToNPC;
    private PlayerManager playerManager;
    private CinemachineDollyCart cinemachineDollyCart;
    private CinemachineStoryboard cinemachineStoryboard;
    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<InputManager>();
        playerManager = GetComponent<PlayerManager>();
        animator = GetComponent<Animator>();
        dialogManager = FindObjectOfType<DialogManager>();
        cinemachineDollyCart = FindObjectOfType<CinemachineDollyCart>();
        cinemachineStoryboard = FindObjectOfType<CinemachineStoryboard>();
        talkToNPC = FindObjectOfType<TalkToNPC>();
        inputManager.DisableControls();
        playerManager.isTalking = true;
        animator.Play("Finger Rolling");
        dialogManager.FirstEncounter(talkToNPC.dialog);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerManager.isTalking == false && cinemachineDollyCart.m_Position == 3)
        {
            StartCoroutine(FadeToBlack());
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }

    IEnumerator FadeToBlack()
    {
        while(cinemachineStoryboard.m_Alpha < 1)
        {
            yield return new WaitForSeconds(.3f);
            cinemachineStoryboard.m_Alpha += .001f;
        }
        yield return null;
    }
}
