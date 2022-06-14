using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RA_Manager : MonoBehaviour
{
    public RAState gameState;

    #region Variables Patrolling
    NavMeshAgent agent;

    [Header("Patrolling Settings")]
    public Transform[] waypoints;
    [SerializeField] private float speed;
    int waypointIndex;
    [SerializeField]  private float distance;
    private Vector3 target;
    #endregion

    #region Variables SearchPlayer
    private bool isPerformingAction;
    SearchPlayer searchPlayer;

    [Header("Search Settings")]
    public float detectionRadius;
    public float minimumDAngle = -50;
    public float maximumDAngle = 50;
    #endregion

    void Awake()
    {
        searchPlayer = GetComponent<SearchPlayer>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        waypointIndex = 0;
        agent.speed = speed;
        Patrol();
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, target);
        HandleCurrentAction();

        if (distance < 1f)
        {
            IncreaseWaypointIndex();
            Debug.Log(waypointIndex);
            
        }
        Patrol();
        
    }

    #region Functions Patrolling
    public void Patrol()
    {
        target = waypoints[waypointIndex].position;
        transform.LookAt(target);
        agent.SetDestination(target);
         
    }

    public void IncreaseWaypointIndex()
    {
        waypointIndex++;
        Patrol();
        if (waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
    #endregion

    #region Functions SearchPlayer
    private void HandleCurrentAction()
    {
        if(searchPlayer.mainTarget == null)
        {
            searchPlayer.HandleDetection();
        }
    }
    #endregion
}
