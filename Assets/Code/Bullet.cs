using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    public bool destrMe = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Health>())
        {
            Health health = other.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);
            if (destrMe)
            {
                Destroy(gameObject);
            }
        }
        
        if (other.gameObject.GetComponent<CatHealth>())
        {
            CatHealth catHealth = other.gameObject.GetComponent<CatHealth>();
            catHealth.TakeDamage();
            if (destrMe)
            {
                Destroy(gameObject);
            }
        }
    }
}