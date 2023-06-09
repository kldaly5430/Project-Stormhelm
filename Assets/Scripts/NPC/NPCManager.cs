using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCManager : CharacterManager
{
    public NavMeshAgent navMeshAgent;
    public Rigidbody npcRigidbody;
    public State state;
    public bool isInteracting;
    public float rotationSpeed = 25f;
    public float interactionRange;

    public CharacterStats currentTarget;


    // Start is called before the first frame update
    void Start()
    {
        npcRigidbody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        navMeshAgent.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
