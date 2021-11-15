using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkBehaviour : MonoBehaviour
{
    public delegate void PlayerFoundEvent();
    public event PlayerFoundEvent OnPlayerFoundEvent;

    public float moveSpeed = 2f;
    public float angularSpeed = 270f;

    [SerializeField]
    private Vector3 m_CurrentWaypoint;
    private List<Vector3> m_Waypoints;
    private NavMeshAgent m_Agent;
    private SeePlayer m_Vision;

    private void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Vision = GetComponent<SeePlayer>();

        m_Waypoints = new List<Vector3>();
        SetupWaypoints();
    }

    private void OnEnable()
    {
        m_Agent.speed = moveSpeed;
        m_Agent.angularSpeed = angularSpeed;

        SelectRandomWaypoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Agent.remainingDistance < 1f)
        {
            SelectRandomWaypoint();
        }

        // If player is found, trigger the event!
        bool isPlayerFound = m_Vision.IsPlayerInVision();
        if (isPlayerFound)
        {
            OnPlayerFoundEvent?.Invoke();
        }
    }

    private void SetupWaypoints()
    {
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        foreach (var wp in waypoints)
        {
            m_Waypoints.Add(wp.transform.position);
        }
    }

    private void SelectRandomWaypoint()
    {
        int randomIndex = Random.Range(0, m_Waypoints.Count);
        m_CurrentWaypoint = m_Waypoints[randomIndex];
        m_Agent.SetDestination(m_CurrentWaypoint);
    }
}
