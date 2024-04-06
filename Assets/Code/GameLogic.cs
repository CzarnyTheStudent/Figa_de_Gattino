using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    [SerializeField]private GameObject figa;
    [SerializeField]private GameObject leonardo;


    private void Start()
    {
        Vector3 respawnLeo = figa.transform.position;
        GameObject leonardoInstance = Instantiate(leonardo, respawnLeo + new Vector3(5, 0 , 0), Quaternion.identity);
    }
}
