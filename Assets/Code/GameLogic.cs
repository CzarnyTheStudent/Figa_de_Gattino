using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]private GameObject figa;
    [SerializeField]private GameObject leonardo;
    [SerializeField]private Spawner spawner;


    private void Start()
    {
        Vector3 respawnLeo = figa.transform.position;
        GameObject leonardoInstance = Instantiate(leonardo, respawnLeo + new Vector3(5, 0 , 0), Quaternion.identity);
        leonardoInstance.AddComponent<GoldAndLvlUp>();

        spawner = figa.GetComponent<Spawner>();
        spawner.leonardoRef = leonardoInstance;
    }
}
