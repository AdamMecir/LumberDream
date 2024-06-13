using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 90;
    public TextMeshProUGUI timerDisplay;
    public bool hasEnded;


    private void Update()
    {
        if (timeValue > 0)
            timeValue -= Time.deltaTime;

        else
        {
            timeValue = 0;
            hasEnded = true;
        }

        DisplayTime(timeValue);
    }

    public void ResetTimer(float time)
    {
        hasEnded = false;
        timeValue += time;
    }

    void DisplayTime(float time)
    {
        if (time < 0)
        {
            time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
