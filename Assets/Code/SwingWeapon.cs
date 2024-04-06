using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingWeapon : MonoBehaviour
{
    public float swingTime;
    public float weaponLifeTime;
    public GameObject weaponPrefab; // Prefabrykat broni
    public Transform throwPoint; // Punkt, z którego będzie rzucona broń
    
    
    private void Start()
    {
        StartCoroutine(StartSwingWeapon());
        //weaponPrefab.GetComponent<Animator>();
    }

    IEnumerator StartSwingWeapon()
    {
        while (true)
        {
            yield return new WaitForSeconds(swingTime);
            
            GameObject newWeapon = Instantiate(weaponPrefab, throwPoint.position, Quaternion.identity);

            Destroy(newWeapon, weaponLifeTime);
        }
    }
}
