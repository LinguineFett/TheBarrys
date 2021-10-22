using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttach : MonoBehaviour
{

    public GameObject player;
    public GameObject fullPlayer;

    private void Awake()
    {

        player = GameObject.Find("Player (Humanoid)");
        fullPlayer = GameObject.Find("Player");
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            Debug.Log("HasCollided");
            fullPlayer.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            fullPlayer.transform.parent = null;
        }
    }
}
