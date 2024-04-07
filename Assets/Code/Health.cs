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
    public PanelControl deadthScreen;

    public TimerScript timer;

    public RectTransform healthBar;

    private void Update()
    {
        if (health < 0)
        {
            deadthScreen.ShowPanel();
            Destroy(gameObject);
            
            // tutaj dać you died
            gameOverTimerTxt.text = "Your Time: " + timer.timerTxt.text;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CatGoldMenagement>())
        {
            CatGoldMenagement healMe = other.gameObject.GetComponent<CatGoldMenagement>(); 
            healMe.catPotionAmount = 0;
            health += 50;
            if (health > 100)
            {
                health = 100;
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;

        float healthPercentage = health / 100f;
        healthBar.localScale = new Vector3(healthPercentage, 1f, 1f);
    }
}
