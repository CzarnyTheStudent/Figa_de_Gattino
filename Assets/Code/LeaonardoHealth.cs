using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaonardoHealth : MonoBehaviour
{
    public int Health;

    private void Update()
    {
        if (Health == 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        Health -= damageAmount;
    }
}
