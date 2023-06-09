using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheer : NPC
{
    AudioSource audioSource;
    public AudioClip cheer;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animator.Play("Sit and Cheer");
        audioSource.clip = cheer;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
