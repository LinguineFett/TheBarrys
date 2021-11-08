using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timer;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float timeCounter;
    float startTime;
    public static int score;
    public static bool isCounting;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        isCounting = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isCounting == false)
        {
            StopTimer();
        }
        else
        {
            timeCounter = Time.time - startTime;
            int min = ((int)(timeCounter / 60));
            int sec = ((int)(timeCounter % 60));

            timer.text = "Time: " + string.Format("{00:00}:{1:00}", min, sec);

        }
        scoreText.text = "Score: " + score;
    }

    float StopTimer()
    {
        isCounting = false;
        return timeCounter;
    }
}
