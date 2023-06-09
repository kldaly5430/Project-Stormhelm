using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadGuy : NPC
{
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Stand and Yell");
        // animator.CrossFade("Stand and Point",0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
