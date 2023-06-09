using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waitress : NPC
{
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(PlayAnimation());
    }

    private IEnumerator PlayAnimation()
    {
        animator.Play("Carrying Object");
        yield return new WaitForSeconds(6f);
        this.gameObject.SetActive(false);
    }
}
