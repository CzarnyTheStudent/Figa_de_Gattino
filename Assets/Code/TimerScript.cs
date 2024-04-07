using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Dodaj to, aby korzystaæ z TextMeshPro

public class TimerScript : MonoBehaviour
{
    public float currentTime;
    public bool timerOn = false;

    public TextMeshProUGUI timerTxt; // U¿ywamy TextMeshProUGUI dla TextMeshPro

    void Start()
    {
        timerOn = true;
    }

    void Update()
    {
        if (timerOn)
        {
            currentTime += Time.deltaTime;
            UpdateTimer(currentTime);
        }
    }

    void UpdateTimer(float currentTime)
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerTxt.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
