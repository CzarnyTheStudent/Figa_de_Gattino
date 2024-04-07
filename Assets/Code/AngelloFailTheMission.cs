using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngelloFailTheMission : MonoBehaviour
{
    public EnemyHealth AngelloHealth;
    public GameObject winGame;

    private void Update()
    {
        if (AngelloHealth.botHealth <= 0)
        {
            winGame.SetActive(true);
            Destroy(gameObject);
        }
    }
}
