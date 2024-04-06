using System.Collections;
using UnityEngine;

public class ColiDamage : MonoBehaviour
{
    public int damageAmount = 2;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyHealth>())
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }
        }
    }
}