using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngelloFailTheMission : MonoBehaviour
{
    public EnemyHealth AngelloHealth;
    public GameObject winGame;

    public GameObject healthBar;
    public GameObject lvlBar;
    public GameObject lvlDisplay;
    public GameObject imieLeonardo;
    public GameObject imieFigi;
    public GameObject potionBackground;
    public GameObject hearth1;
    public GameObject hearth2;
    public GameObject hearth3;
    public GameObject hearth4;
    public GameObject hearth5;
    public GameObject hearth6;
    public GameObject hearth7;
    public GameObject hearth8;
    public GameObject hearth9;

    private void Update()
    {
        if (AngelloHealth.botHealth <= 0)
        {
            winGame.SetActive(true);

            healthBar.SetActive(false);
            lvlBar.SetActive(false);
            lvlDisplay.SetActive(false);
            imieLeonardo.SetActive(false);
            imieFigi.SetActive(false);
            potionBackground.SetActive(false);
            hearth1.SetActive(false);
            hearth2.SetActive(false);
            hearth3.SetActive(false);
            hearth4.SetActive(false);
            hearth5.SetActive(false);
            hearth6.SetActive(false);
            hearth7.SetActive(false);
            hearth8.SetActive(false);
            hearth9.SetActive(false);


            Destroy(gameObject);
        }
    }
}


