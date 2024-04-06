using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CatGoldMenagement : MonoBehaviour
{
    public int catGoldAmount = 0;
    public TextMeshProUGUI goldText; // Referencja do obiektu TextMeshPro

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddGold(20);
            Destroy(other.gameObject);
            UpdateGoldText(); // Aktualizuj tekst na obiekcie TextMeshPro
        }
    }

    private void AddGold(int amount)
    {
        catGoldAmount += amount;
    }

    private void UpdateGoldText()
    {
        // Aktualizuj tekst na obiekcie TextMeshPro
        goldText.text = "Cat's Gold: " + catGoldAmount.ToString();
    }
}
