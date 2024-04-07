using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public int health;

    public TextMeshProUGUI gameOverTimerTxt;
    public PanelControl panel;

    public TimerScript timer;

    public RectTransform bar;

    private void Update()
    {
        if (health < 0)
        {
            panel.ShowPanel();
            Destroy(gameObject);
            
            // tutaj dać you died
            gameOverTimerTxt.text = "Your Time: " + timer.currentTime.ToString();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        float healthPercentage = health / 100f;
        bar.localScale = new Vector3(healthPercentage, 1f, 1f);
    }
}
