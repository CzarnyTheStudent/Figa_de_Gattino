using UnityEngine;

public class BotMoveLogic : MonoBehaviour
{
    public Transform target; // Cel, który będzie śledzony
    public float moveSpeed = 3f; // Prędkość przemieszczania przeciwnika
    public float stoppingDistance = 2f; // Odległość, w której przeciwnik zatrzyma się

    public bool isMoving = true;

    void Update()
    {
        if (target != null && isMoving)
        {
            Vector3 direction = new Vector3(target.position.x - transform.position.x, 0f, target.position.z - transform.position.z).normalized;
            
            // Oblicz odległość między przeciwnikiem a celem
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            transform.rotation = Quaternion.LookRotation(direction);

            // Jeśli odległość do celu jest większa niż odległość zatrzymania, przemieszczaj się w jego kierunku
            if (distanceToTarget > stoppingDistance)
            {
                //transform.Translate(direction * moveSpeed * Time.deltaTime);
                transform.position += direction * moveSpeed * Time.deltaTime; 
                
            }
            else // W przeciwnym razie zatrzymaj się
            {
                isMoving = false;
                transform.position -= direction * moveSpeed * Time.deltaTime; 
            }
        }
        else if (target != null && !isMoving) // Jeśli przeciwnik zatrzymał się i cel się oddalił, wznowienie ruchu
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget > stoppingDistance)
            {
                isMoving = true;
            }
        }
    }
}