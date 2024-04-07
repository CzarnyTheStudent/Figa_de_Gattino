using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour
{
    public int catMaxHealth = 9; // Maksymalna liczba serduszek
    public int catCurrentHealth = 9; // Aktualne zdrowie
    public Image[] hearts; // Tablica obrazk�w serduszek
    public PostProcessVolume postProcessVolume;

    void Start()
    {
        // Inicjalizacja stanu serduszek
        catCurrentHealth = catMaxHealth;
        UpdateUI();
    }

    private void Update()
    {
        if (catCurrentHealth <= 0)
        {
            StartCoroutine(Regenerate());
        }
    }

    IEnumerator Regenerate()
    {
        CatMove moveCat = GetComponent<CatMove>();
        postProcessVolume.enabled = true;
        moveCat.enabled = false;
        yield return new WaitForSeconds(9f);
        postProcessVolume.enabled = false;
        moveCat.enabled = true;
        catCurrentHealth = 9;
        for (int i = 0; i < catMaxHealth; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }

    // Funkcja do odejmowania zdrowia
    public void TakeDamage()
    {
        catCurrentHealth -= 1;

        // Ograniczenie zdrowia do warto�ci od 0 do maxHealth
        catCurrentHealth = Mathf.Clamp(catCurrentHealth, 0, catMaxHealth);

        UpdateUI();
    }

    // Funkcja do aktualizacji UI serduszek
    void UpdateUI()
    {
        // Dezaktywacja kolejnych serduszek, zaczynaj�c od ko�ca
        for (int i = catMaxHealth - 1; i >= catCurrentHealth; i--)
        {
            hearts[i].gameObject.SetActive(false);
        }
    }
}
