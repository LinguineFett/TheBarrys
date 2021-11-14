using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePlayer : MonoBehaviour
{
    public float viewDistance;
    public float viewAngle;
    public LayerMask layerMask;

    private Transform playerTransform;

    void Start()
    {
        GameObject knight = GameObject.FindGameObjectWithTag("Player");
        playerTransform = knight.transform;
    }

    public bool IsPlayerInVision()
    {
        Vector3 toPlayerVector = playerTransform.position - transform.position;
        float distanceFromPlayer = toPlayerVector.magnitude;

        if (distanceFromPlayer < viewDistance)
        {
            float angle = Vector3.Angle(transform.forward, toPlayerVector);

            if (angle < (viewAngle / 2))
            {
                RaycastHit hitInfo;

                if (Physics.Raycast(transform.position, toPlayerVector, out hitInfo, viewDistance, layerMask))
                {
                    if (hitInfo.collider.tag == "Player")
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }
}
