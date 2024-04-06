using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int health;

    public TextMeshProUGUI gameOverTimerTxt;
    public TimerScript timer;

    private void Update()
    {
        if (health < 0)
        {
            Destroy(gameObject);
            // tutaj daæ you died
            gameOverTimerTxt.text = "Your Time: " + timer.currentTime.ToString();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }
}
