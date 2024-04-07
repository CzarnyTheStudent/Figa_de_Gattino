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
        spawner = figa.GetComponent<Spawner>();
        spawner.leonardoRef = leonardo;
    }
}
