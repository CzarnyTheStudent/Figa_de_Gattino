using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int botHealth;

    [SerializeField] private GameObject coinPrefab;

    private void Update()
    {
        if (botHealth == 0)
        {
            Transform objectTransform = transform;
            Destroy(gameObject);

            GameObject coinInst = Instantiate(coinPrefab, objectTransform.position, Quaternion.identity); // spawn of coin
            if (UnityEngine.Random.Range(1, 10) == 1)
            {
                GameObject coinInst2 = Instantiate(coinPrefab, objectTransform.position, Quaternion.identity); // LATER spawm of potion
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        botHealth -= damageAmount;
    }
}
