using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldAndLvlUp : MonoBehaviour
{
    public int leonardosGoldAmount = 0;
    public int level = 1;

    public List<Component> componentsList;

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
        catGoldScript.catGoldAmount = 0;
    }

    private void AddGold(int amount)
    {
        leonardosGoldAmount += amount;
        Debug.Log("Zdobyles " + amount + " złota! Aktualna ilość złota: " + leonardosGoldAmount);

        if (leonardosGoldAmount >= 20*level)
        {
            leonardosGoldAmount = 0;
            level++;

            for (int i = 0; i < level; i++)
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
