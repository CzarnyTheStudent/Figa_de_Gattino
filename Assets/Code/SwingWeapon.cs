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
    }

    IEnumerator StartSwingWeapon()
    {
        while (true)
        {
            yield return new WaitForSeconds(swingTime);
            
            GameObject newWeapon = Instantiate(weaponPrefab, throwPoint.position, Quaternion.identity);
            newWeapon.transform.SetParent(throwPoint, true);

            Destroy(newWeapon, weaponLifeTime);
        }
    }
}
