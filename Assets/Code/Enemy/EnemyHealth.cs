using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int botHealth;

    private void Update()
    {
        if (botHealth == 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        botHealth -= damageAmount;
    }
}
