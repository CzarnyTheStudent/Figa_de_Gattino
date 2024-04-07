using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldAndLvlUp : MonoBehaviour
{
    public int leonardosGoldAmount = 0;
    public int level = 1;

    public List<Component> componentsList;

    public TextMeshProUGUI leoGoldText;
    public RectTransform lvlbar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cat"))
        {
            CatGoldMenagement catGoldScript = other.GetComponent<CatGoldMenagement>();
            if (catGoldScript != null)
            {
                CollectGoldFromCat(catGoldScript);
            }
        }
    }

    private void CollectGoldFromCat(CatGoldMenagement catGoldScript)
    {
        int catGoldAmount = catGoldScript.catGoldAmount;
        AddGold(catGoldAmount);
        UpdateLeoGoldText();
        catGoldScript.catGoldAmount = 0;
    }

    private void AddGold(int amount)
    {
        leonardosGoldAmount += amount;
        Debug.Log("Zdobyles " + amount + " złota! Aktualna ilość złota: " + leonardosGoldAmount);

        float levelPercentage = leonardosGoldAmount / (10f * level);
        lvlbar.localScale = new Vector3(levelPercentage, 1f, 1f);

        if (leonardosGoldAmount >= 10*level)
        {
            leonardosGoldAmount = 0;
            level++;
            lvlbar.localScale = new Vector3(leonardosGoldAmount/(10*level), 1f, 1f);

            for (int i = 0; i < level; i++)
            {
                if (level <= componentsList.Count)
                {
                    if (componentsList[i] != null)
                    {
                        Behaviour behaviourComponent = componentsList[i] as Behaviour;
                        if (behaviourComponent != null)
                        {
                            behaviourComponent.enabled = true;
                        }
                    }
                }
            }
        }
    }

    private void UpdateLeoGoldText()
    {
        leoGoldText.text = "Leonardo's Gold: " + leonardosGoldAmount.ToString();
    }
}
