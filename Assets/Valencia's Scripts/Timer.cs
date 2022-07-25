using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    bool timerActive = false;
    public float currentTime;
    public float startMinutes;
    public TextMeshProUGUI currrentTimeText;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startMinutes * 60;
        StartTime();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive == true)
        {
            currentTime = currentTime - Time.deltaTime;
            if (currentTime <= 0)
            {
                timerActive = false;
            }
        }
        TimeSpan time = TimeSpan.FromSeconds(currentTime);
        if (time.Minutes < 10)
        {
            currrentTimeText.text = "0" +time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }

        if (time.Seconds < 10)
        {
            currrentTimeText.text = time.Minutes.ToString() + ":" + "0" +time.Seconds.ToString();

        }
        if (time.Minutes < 10 && time.Seconds < 10)
        {
            currrentTimeText.text = "0" + time.Minutes.ToString() + ":" + "0" + time.Seconds.ToString();
        }

        if (time.Minutes > 10 && time.Seconds > 10)
        {
            currrentTimeText.text = time.Minutes.ToString() + ":" + time.Seconds.ToString();
        }


    }

    public void StartTime()
    {
        timerActive = true;
    }
}
