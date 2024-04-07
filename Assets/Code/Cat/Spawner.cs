using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float distanceFromObject = 2f; // Odległość punktów respawnu od obiektu
    public ObjectToSpawn[] objectsToSpawn;
    private List<Transform> spawnPoints = new List<Transform>(); // Punkty respawnu
    public GameObject leonardoRef;
    public Collider respawnArea1;
    public Collider respawnArea2;

    void Start()
    {
        // Inicjalizacja punktów respawnu
        InitializeSpawnPoints();

        // Rozpocznij osobną coroutine dla każdego obiektu do zrespawnowania
        foreach (var objectToSpawn in objectsToSpawn)
        {
            StartCoroutine(RespawnObject(objectToSpawn));
        }
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

    IEnumerator RespawnObject(ObjectToSpawn objectToSpawn)
    {
        while (true)
        {
            yield return new WaitForSeconds(objectToSpawn.respawnTime);
            int spawnIndex = Random.Range(0, spawnPoints.Count);

            // Sprawdzenie, czy punkt respawnu znajduje się w jednym z obszarów
            if (respawnArea1.bounds.Contains(spawnPoints[spawnIndex].position) || respawnArea2.bounds.Contains(spawnPoints[spawnIndex].position))
            {
                // Zrespawnowanie obiektu
                var enemy = Instantiate(objectToSpawn.objectToRespawn, spawnPoints[spawnIndex].position, Quaternion.identity);
                BotMoveLogic movementEne = enemy.GetComponent<BotMoveLogic>();
                if (leonardoRef != null)
                {
                    movementEne.target = leonardoRef.transform;
                }
            }
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

[Serializable]
public class ObjectToSpawn
{
    public GameObject objectToRespawn; // Obiekt do respawnu
    public float respawnTime; // Czas respawnu dla tego obiektu
}
