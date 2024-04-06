using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CatGoldMenagement : MonoBehaviour
{
    public int catGoldAmount = 0;
    public int catPotionAmount = 0;
    public TextMeshProUGUI goldText; // Referencja do obiektu TextMeshPro

    public Image potionImage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            AddGold(20);
            Destroy(other.gameObject);
            UpdateGoldText(); // Aktualizuj tekst na obiekcie TextMeshPro
        }

        if (catPotionAmount == 0 && other.CompareTag("Potion"))
        {
            catPotionAmount++;
            Destroy(other.gameObject);
            potionImage.gameObject.SetActive(true);
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
