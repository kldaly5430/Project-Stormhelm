using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : CharacterManager
{
    EnemyMovement enemyMovement;
    EnemyAnimatorManager enemyAnimatorManager;
    EnemyStats enemyStats;
    public NavMeshAgent navMeshAgent;
    public Rigidbody enemyRigidBody;

    public State currentState;

    public bool isPerformingAction;
    public bool isInteracting;
    public float maxAggroRadius = 1.5f;
    public float rotationSpeed = 25f;

    public CharacterStats currentTarget;

    [Header("AI Settings")]
    public float detectionRadius = 20;
    // The higher, and lower respectively these angle are, the greater detection FOV(In terms a circle)
    public float maximumDetectionAngle = 50;
    public float minimumDetectionAngle = -50;

    public float currentRecoveryTime = 0;

    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemyAnimatorManager = GetComponent<EnemyAnimatorManager>();
        enemyStats = GetComponent<EnemyStats>();
        enemyRigidBody = GetComponent<Rigidbody>();
        navMeshAgent = GetComponentInChildren<NavMeshAgent>();
        navMeshAgent.enabled = false;

        // OnDrawGizmos();
    }

    // Update is called once per frame
    void Update()
    {
        HandleRecoveryTime();

        isRotatingWithRootMotion = enemyAnimatorManager.animator.GetBool("isRotatingWithRootMotion");
        isInteracting = enemyAnimatorManager.animator.GetBool("isInteracting");
        canRotate = enemyAnimatorManager.animator.GetBool("canRotate");
    }

    private void FixedUpdate()
    {
        HandleStateMachine();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position+new Vector3(0,1,0), 1.0f);
    }

    private void HandleStateMachine()
    {
        if(currentState != null)
        {
            State nextState = currentState.Tick(this, enemyStats, enemyAnimatorManager);

            if(nextState != null)
            {
                SwitchToNextState(nextState);
            }
        }
    }

    public void SwitchToNextState(State state)
    {
        currentState = state;
    }

    #region Attack


    private void HandleRecoveryTime()
    {
        if(currentRecoveryTime > 0)
        {
            currentRecoveryTime -= Time.deltaTime;
        }

        if (isPerformingAction)
        {
            if(currentRecoveryTime <= 0)
            {
                isPerformingAction = false;
            }
        }
    }
    #endregion
}
