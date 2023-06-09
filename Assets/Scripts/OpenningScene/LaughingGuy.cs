using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughingGuy : NPC
{
    AudioSource audioSource;
    public AudioClip laugh;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = laugh;
        animator = GetComponent<Animator>();
        animator.Play("Sit");
        animator.CrossFade("Sit and Point",0.2f);
        // animator.SetBool("Laugh", true);
    }

    public void Laugh()
    {
        // animator.CrossFade("Sit",0.2f);
        animator.CrossFade("Laughing1",0.2f);
        audioSource.Play();
    }
}
