using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Rigidbody))]
public class ChasePlayer : MonoBehaviour
{
    public float attackDistance = 3f;
    public float movementSpeed = 4f;

    public float npcDamage = 5;
    public float attackRate = 0.5f;

    public Transform player;
    NavMeshAgent agent;
    float nextAttackTime = 0;
    Rigidbody r;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = attackDistance;
        agent.speed = movementSpeed;
        r = GetComponent<Rigidbody>();
        r.useGravity = false;
        r.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance - attackDistance < 0.01f)
        {
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + attackRate;

                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.forward, out hit, attackDistance))
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        Debug.Log("TOUCH!!!!");
                    }
                }
            }
        }

        agent.destination = player.position;
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.position.z));
        r.velocity *= 0.99f;
    }
}