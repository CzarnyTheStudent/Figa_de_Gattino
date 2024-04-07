using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int botHealth;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject potionPref;
    private Transform _transformMe;
    
    private void Update()
    {
        _transformMe = transform;
        if (botHealth < 0)
        {
            GameObject coinInst = Instantiate(coinPrefab, _transformMe.position, Quaternion.identity); // spawn of coin
            coinInst.transform.position = _transformMe.position;
            if (UnityEngine.Random.Range(5, 10) == 5)
            {
                GameObject potionInst = Instantiate(potionPref, _transformMe.position, Quaternion.identity); // spawn of coin
            }
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        botHealth -= damageAmount;
    }
}
