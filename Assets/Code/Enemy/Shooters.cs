using System.Collections;
using UnityEngine;

public class Shooters : MonoBehaviour
{
    public BotMoveLogic botMove;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed;
    public float fireRate = 1f; // Częstotliwość strzałów (strzały na sekundę)
    
    private float nextFireTime;

    private void Start()
    {
        botMove = GetComponent<BotMoveLogic>();
        nextFireTime = Time.time; // Inicjalizacja czasu następnego strzału
    }

    private void Update()
    {
        if (!botMove.isMoving && Time.time >= nextFireTime)
        {
            // Strzelanie tylko jeśli postać się porusza i minął czas do kolejnego strzału
            Shoot();
            nextFireTime = Time.time + 1f / fireRate; // Aktualizacja czasu następnego strzału
        }
    }

    void Shoot()
    {
        // Stworzenie nowego obiektu pocisku na pozycji bulletSpawnPoint
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    
        // Pobranie komponentu Rigidbody z pocisku
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Sprawdzenie, czy pobrano komponent Rigidbody
        if (bulletRigidbody != null)
        {
            // Ustawienie prędkości pocisku w kierunku osi znormalizowanego wektora kierunku, 
            bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
        }

        // Opcjonalnie można dodać tutaj logikę ustawiania prędkości pocisku, jeśli jest to potrzebne
        if (bullet != null)
        {
            Destroy(bullet, 3f); // Pocisk zniknie po 3 sekundach (można dostosować czas)
        }
    }

}