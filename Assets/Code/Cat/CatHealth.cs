using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour
{
    public int catMaxHealth = 9; // Maksymalna liczba serduszek
    public int catCurrentHealth = 9; // Aktualne zdrowie
    public Image[] hearts; // Tablica obrazk�w serduszek

    void Start()
    {
        // Inicjalizacja stanu serduszek
        catCurrentHealth = catMaxHealth;
        UpdateUI();
    }

    // Funkcja do odejmowania zdrowia
    public void TakeDamage(int damage)
    {
        catCurrentHealth -= damage;

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
