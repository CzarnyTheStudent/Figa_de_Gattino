using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    public List<AudioClip> sounds = new List<AudioClip>(); // Lista dźwięków
    public float minTimeBetweenSounds = 2f; // Minimalny czas pomiędzy odtwarzaniem dźwięków
    public float maxTimeBetweenSounds = 5f; // Maksymalny czas pomiędzy odtwarzaniem dźwięków

    [SerializeField]private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        // Rozpocznij odtwarzanie dźwięków w pętli
        StartCoroutine(PlayRandomSound());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Wybierz losowy dźwięk z listy
            AudioClip randomSound = sounds[Random.Range(0, sounds.Count)];

            // Odtwórz wybrany dźwięk przy użyciu AudioSource
            audioSource.PlayOneShot(randomSound);
        }
    }

    IEnumerator PlayRandomSound()
    {
        // Sprawdź, czy lista dźwięków nie jest pusta
        if (sounds.Count == 0)
        {
            Debug.LogWarning("Lista dźwięków jest pusta!");
            yield break;
        }

        // Pętla nieskończona
        while (true)
        {
            // Poczekaj losowy czas przed odtworzeniem następnego dźwięku
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSounds, maxTimeBetweenSounds));

            // Wybierz losowy dźwięk z listy
            AudioClip randomSound = sounds[Random.Range(0, sounds.Count)];

            // Odtwórz wybrany dźwięk przy użyciu AudioSource
            audioSource.PlayOneShot(randomSound);
        }
    }
}