using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeoMove : MonoBehaviour
{
    public string targetTag = "Enemy"; // Tag celu
    public float movementSpeed = 5f; // Szybkość poruszania
    public float rotationSpeed = 5f; // Szybkość obrotu
    public float stoppingDistance = 1f; // Odległość, przy której zatrzymuje się obok celu

    private GameObject target; // Referencja do aktualnego celu
    private bool isMoving = false; // Czy obiekt się porusza

    void Start()
    {
        FindNearestTarget(); // Szuka najbliższego celu na początku
    }

    void Update()
    {
        
        FindNearestTarget();
        if (target != null)
        {
            // Oblicza kierunek do celu
            Vector3 direction = target.transform.position - transform.position;

            // Sprawdza, czy obiekt jest wystarczająco blisko do celu
            if (direction.magnitude > stoppingDistance)
            {
                isMoving = true;
                // Porusza obiekt w kierunku celu z odpowiednią szybkością
                transform.Translate(direction.normalized * movementSpeed * Time.deltaTime, Space.World);

                // Obraca obiekt w kierunku celu
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
            else
            {
                isMoving = false;
            }
        }
        else
        {
            isMoving = false;
        }
    }

    // Szuka najbliższego celu z tagiem "Enemy"
    void FindNearestTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);
        float closestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }

        target = closestEnemy;
    }

    // Jeśli cel zniknie, szuka nowego najbliższego celu
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == targetTag)
        {
            FindNearestTarget();
        }
    }

    // Zatrzymuje obiekt, jeśli przeszkoda się zbliży
    void OnCollisionEnter(Collision collision)
    {
        if (isMoving)
        {
            isMoving = false;
        }
    }
}
