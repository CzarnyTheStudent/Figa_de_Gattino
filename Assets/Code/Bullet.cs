using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Health>())
        {
            Health health = other.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}