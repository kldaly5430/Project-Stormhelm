using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bard : NPC
{
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Play Lute");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}