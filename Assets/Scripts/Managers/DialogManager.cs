using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogManager : MonoBehaviour
{
    
    public UIManager uiManager;
    public PlayerManager playerManager;
    public TMP_Text nameText;
    public TMP_Text dialogText;
    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        sentences = new Queue<string>();
    }

    public void FirstEncounter(Dialog dialog)
    {
        Debug.Log("Called");
        sentences.Clear();
        uiManager.OpenDialogWindow();
        uiManager.ShowContinueDialog();
        nameText.text = dialog.name;

        foreach (string script in dialog.sentences)
        {
            sentences.Enqueue(script);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentence = sentences.Dequeue();
        // dialogText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }

    public void EndDialog()
    {
        uiManager.CloseDialogWindow();
        uiManager.HideContinueDialog();
        playerManager.isTalking = false;
    }
}
