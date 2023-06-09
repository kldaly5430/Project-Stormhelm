using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.AI;

public class GoblinAttack : MonoBehaviour
{
    public InputManager inputManager;
    public EnemyManager enemyManager;
    public Animator animator;
    public PursueTargetState pursueTargetState;

    public CharacterStats player;
    public GameObject[] cameras = new GameObject[3];
    public Transform lookAtTarget;
    public Transform dollyCart;
    public CinemachineDollyCart cinemachineDollyCart;

    public GameObject goblinPrefab;
    public GameObject[] goblinSpawn = new GameObject[2];
    public List<GameObject> goblins = new List<GameObject>();


    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        inputManager = FindObjectOfType<InputManager>();
        cinemachineDollyCart = GetComponent<CinemachineDollyCart>();
        enemyManager = FindObjectOfType<EnemyManager>();
        for(int i = 0; i < goblinSpawn.Length; i++)
        {
            goblins.Add(Instantiate(goblinPrefab, goblinSpawn[i].transform.position, goblinSpawn[i].transform.rotation));
            // goblins[i] =  GameObject.FindGameObjectWithTag("Enemy");
        }

    }
    private void OnTriggerEnter(Collider other) {
        inputManager.DisableControls();
        animator.SetFloat(Animator.StringToHash("Vertical"), 0, 0f, Time.deltaTime);
        // inputManager.DisableControls();
        cameras[0].SetActive(false);
        cameras[1].SetActive(false);
        cameras[2].SetActive(true);
        StartCoroutine(WaitSeconds());
        // cinemachineDollyCart.m_Path.
    }

    IEnumerator WaitSeconds()
    {
        yield return new WaitForSeconds(3);
        cameras[2].transform.SetParent(dollyCart);
        cameras[2].GetComponent<Cinemachine.CinemachineVirtualCamera>().LookAt = lookAtTarget;
        dollyCart.GetComponent<CinemachineDollyCart>().m_Speed = 1;
        
        StartCoroutine(ReturnToPlayer());
    }

    IEnumerator ReturnToPlayer()
    {
        yield return new WaitForSeconds(2);
        
        if(dollyCart.GetComponent<CinemachineDollyCart>().m_Position == 2)
        {
            for(int i = 0; i < goblins.Count; i++)
            {
                goblins[i].GetComponent<NavMeshAgent>().enabled = true;
                goblins[i].GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
                goblins[i].GetComponent<EnemyManager>().currentTarget = player;
            }            
        }
        yield return new WaitForSeconds(3);
        inputManager.OnEnable();
        cameras[0].SetActive(true);
        cameras[1].SetActive(true);
        cameras[2].SetActive(false);
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
}
