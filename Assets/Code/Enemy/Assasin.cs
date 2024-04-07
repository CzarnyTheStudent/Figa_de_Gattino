using UnityEngine;
using System.Collections;

public class Assassin : MonoBehaviour
{
    public int hitDamage;
    public float hitTime;
    public float pushDistance; // Dystans, o który zostanie przesunięty obiekt w przód

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Health>())
        {
            StartCoroutine(HitAndRevert(other.transform)); // Uruchom Coroutine, aby obsłużyć uderzenie i powrót
        }
    }

    IEnumerator HitAndRevert(Transform targetTransform)
    {
        // Przesuń obiekt do przodu
        yield return new WaitForSeconds(hitTime);
        Vector3 originalPosition = transform.position;
        Vector3 targetPosition = transform.position + transform.forward * pushDistance;
        float elapsedTime = 0f;

        while (elapsedTime < hitTime)
        {
            transform.position = Vector3.Lerp(originalPosition, targetPosition, elapsedTime / hitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        

        // Wróć na początkową pozycję
        elapsedTime = 0f;
        while (elapsedTime < hitTime)
        {
            transform.position = Vector3.Lerp(targetPosition, originalPosition, elapsedTime / hitTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        
        // Uzyskaj dostęp do komponentu Health i zadaj obrażenia
        Health theHealth = targetTransform.GetComponent<Health>();
        if (theHealth != null)
        {
            theHealth.TakeDamage(hitDamage);
        }
    }
}