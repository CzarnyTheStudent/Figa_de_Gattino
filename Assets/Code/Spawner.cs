using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] objectsToRespawn; // Lista obiektów do respawnu
    public float respawnTime = 5f; // Czas respawnu
    public float distanceFromObject = 2f; // Odległość punktów respawnu od obiektu
    private List<Transform> spawnPoints = new List<Transform>(); // Punkty respawnu

    void Start()
    {
        // Inicjalizacja punktów respawnu
        InitializeSpawnPoints();
        StartCoroutine(RespawnObject());
    }

    void Update()
    {
        // Aktualizacja odległości punktów respawnu od obiektu
        UpdateSpawnPoints();
    }

    void InitializeSpawnPoints()
    {
        // Obliczanie pozycji punktów respawnu na okręgu
        int numPoints = 6; // Liczba punktów respawnu
        float angleStep = 360f / numPoints;

        for (int i = 0; i < numPoints; i++)
        {
            float angle = i * angleStep;
            Vector3 spawnPointPosition = transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * distanceFromObject;
            GameObject spawnPointObject = new GameObject("SpawnPoint" + i);
            spawnPointObject.transform.position = spawnPointPosition;
            spawnPoints.Add(spawnPointObject.transform);
        }
    }

    void UpdateSpawnPoints()
    {
        // Aktualizacja pozycji punktów respawnu na okręgu, aby podążały za obiektem
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            float angle = (360f / spawnPoints.Count) * i;
            Vector3 spawnPointPosition = transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * distanceFromObject;
            spawnPoints[i].position = spawnPointPosition;
        }
    }

    IEnumerator RespawnObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);

            // Wybierz losowy obiekt do zrespawnowania
            int objectIndex = Random.Range(0, objectsToRespawn.Length);

            // Wybierz losowy punkt respawnu
            int spawnIndex = Random.Range(0, spawnPoints.Count);

            // Zrespawnowanie obiektu
            Instantiate(objectsToRespawn[objectIndex], spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }

    void OnDrawGizmos()
    {
        // Rysowanie Gizmosów dla punktów respawnu
        Gizmos.color = Color.green;
        foreach (Transform point in spawnPoints)
        {
            Gizmos.DrawSphere(point.position, 0.2f);
        }
    }
}
