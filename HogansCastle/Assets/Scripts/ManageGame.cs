using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageGame : MonoBehaviour
{
    public GameObject finishUI;
    public GameObject panelUI;

    public void CompleteLevel()
    {
        finishUI.SetActive(true);
        panelUI.SetActive(true);
        Invoke("StopLevel", 5.0f);
    }

    void StopLevel()
    {
        //yield return new WaitForSeconds(time); 
        //Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false; 
    }
}
