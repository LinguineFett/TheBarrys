using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter(Collision other)
    {
        if (other.gameObject == player)
        {
            SceneManager.LoadScene("LevelWonScreen");
        }
    }
}
