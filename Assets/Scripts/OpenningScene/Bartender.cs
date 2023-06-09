using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bartender : NPC
{
    public GameObject handMugs;
    public GameObject barMugs;
    public GameObject wineBottle;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Bartending");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetCups()
    {
        handMugs.SetActive(true);
    }

    public void SwitchCups()
    {
        handMugs.SetActive(false);
        barMugs.SetActive(true);
    }

    public void GetBottle()
    {
        wineBottle.SetActive(true);
    }
}
