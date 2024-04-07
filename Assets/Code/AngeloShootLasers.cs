using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngeloShootLasers : MonoBehaviour
{
   public Animator animAng;
   public GameObject eye1;
   public GameObject eye2;

   private void Start()
   {
      eye1.SetActive(false);
      eye2.SetActive(false);
      StartCoroutine(LaserTime());
   }

   IEnumerator LaserTime()
   {
      while (true)
      {
         yield return new WaitForSeconds(5f);
         animAng.SetBool("Laser", true);
         eye1.SetActive(true);
         eye2.SetActive(true);
         yield return new WaitForSeconds(1.5f);
         eye1.SetActive(false);
         eye2.SetActive(false);
         animAng.SetBool("Laser", false);
      }
   }
}
