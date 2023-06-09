using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flex : NPC
{
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Flex");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
