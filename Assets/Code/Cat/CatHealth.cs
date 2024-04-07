using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatHealth : MonoBehaviour
{
    public int catMaxHealth = 9; // Maksymalna liczba serduszek
    public int catCurrentHealth = 9; // Aktualne zdrowie
    public Image[] hearts; // Tablica obrazków serduszek

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

        // Ograniczenie zdrowia do wartoœci od 0 do maxHealth
        catCurrentHealth = Mathf.Clamp(catCurrentHealth, 0, catMaxHealth);

        UpdateUI();
    }

    // Funkcja do aktualizacji UI serduszek
    void UpdateUI()
    {
        // Dezaktywacja kolejnych serduszek, zaczynaj¹c od koñca
        for (int i = catMaxHealth - 1; i >= catCurrentHealth; i--)
        {
            hearts[i].gameObject.SetActive(false);
        }
    }
}
