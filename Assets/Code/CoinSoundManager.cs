using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinSoundManager : MonoBehaviour
{
    public List<AudioClip> coinSounds = new List<AudioClip>(); // Lista dźwięków

    [SerializeField]private AudioSource coinPickUp;
    [SerializeField]private AudioSource giveCoin;
    

    public IEnumerator PlayCoinSoundPickUp()
    {
        // Sprawdź, czy lista dźwięków nie jest pusta
        if (coinSounds.Count == 0)
        {
            Debug.LogWarning("Lista dźwięków jest pusta!");
            yield break;
        }
        
            // Wybierz losowy dźwięk z listy
            AudioClip randomSound = coinSounds[Random.Range(0, coinSounds.Count)];

            // Odtwórz wybrany dźwięk przy użyciu AudioSource
            coinPickUp.PlayOneShot(randomSound);
        
    }
}