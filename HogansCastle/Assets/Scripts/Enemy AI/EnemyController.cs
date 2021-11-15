using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Acts as a controller for the enemy
/// </summary>
public class EnemyController : MonoBehaviour
{
    private WalkBehaviour behavior;
    private ChasePlayer chaseBehaviour;

    private void Awake()
    {
        behavior = GetComponent<WalkBehaviour>();
        chaseBehaviour = GetComponent<ChasePlayer>();
        SwitchToWalkMode();
    }

    private void OnEnable()
    {
        behavior.OnPlayerFoundEvent += PlayerFound;
        chaseBehaviour.OnPlayerLostEvent += PlayerLost;
    }

    private void OnDisable()
    {
        behavior.OnPlayerFoundEvent -= PlayerFound;
        chaseBehaviour.OnPlayerLostEvent -= PlayerLost;
    }

    public void PlayerFound()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var obj in enemies)
        {
            EnemyController controller = obj.GetComponent<EnemyController>();
            controller.SwitchToChaseMode();
        }
    }

    public void PlayerLost()
    {
         GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (var obj in enemies)
        {
            EnemyController controller = obj.GetComponent<EnemyController>();
            controller.SwitchToWalkMode();
        }
    }

    public void SwitchToChaseMode()
    {
        behavior.enabled = false;
        chaseBehaviour.enabled = true;
    }

    public void SwitchToWalkMode()
    {
        behavior.enabled = true;
        chaseBehaviour.enabled = false;
    }
}
