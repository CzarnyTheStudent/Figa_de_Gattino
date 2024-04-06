using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatGoldMenagement : MonoBehaviour
{
   
    public int catGoldAmount = 0;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.CompareTag("Coin"))
        {
            AddGold(1);
            Destroy(other.gameObject);
        }
    }


    private void AddGold(int amount)
    {
        catGoldAmount += amount;
    }
}
