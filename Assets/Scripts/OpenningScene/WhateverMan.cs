using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhateverMan : NPC
{
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Sit");
        animator.CrossFade("Sit and Drink",0.2f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
