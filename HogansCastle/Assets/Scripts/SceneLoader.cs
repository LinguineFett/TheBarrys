using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Loads a level based on the build index.
    public void LoadScene(int level) {
        SceneManager.LoadScene(level);
    }

}
