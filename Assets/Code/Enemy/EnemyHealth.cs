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
    public float knockbackDistance = 1.0f;
    public float knockbackDuration = 0.2f; // Czas trwania odrzutu

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
        StartCoroutine(SmoothKickCoroutine());
    }

    IEnumerator SmoothKickCoroutine()
    {
        Vector3 targetPosition = transform.position + -transform.forward * knockbackDistance;
        Vector3 startPosition = transform.position;
        float startTime = Time.time;

        while (Time.time < startTime + knockbackDuration)
        {
            float t = (Time.time - startTime) / knockbackDuration;
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }
    }
}