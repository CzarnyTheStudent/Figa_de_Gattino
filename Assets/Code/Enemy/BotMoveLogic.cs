using UnityEngine;

public class BotMoveLogic : MonoBehaviour
{
    public Transform target; // Cel, który będzie śledzony
    public float moveSpeed = 3f; // Prędkość przemieszczania przeciwnika
    public float stoppingDistance = 2f; // Odległość, w której przeciwnik zatrzyma się
    public LayerMask avoidanceLayer; // Warstwa kolizji, której należy unikać
    public float avoidanceDistance = 3f; // Odległość, na jaką należy się odsunąć od obiektu kolizyjnego
    public float avoidanceTimeThreshold = 2f; // Czas, po którym następuje próba uniknięcia kolizji

    public bool isMoving = true;
    private float timeSinceCollision = 0f;

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
                // Sprawdź kolizję i unikaj, jeśli konieczne
                if (CheckForCollision())
                {
                    isMoving = false;
                    return;
                }

                transform.position += direction * moveSpeed * Time.deltaTime; 
            }
            else // W przeciwnym razie zatrzymaj się
            {
                isMoving = false;
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

    bool CheckForCollision()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, avoidanceDistance, avoidanceLayer))
        {
            // Jeśli wykryto kolizję, odsuń się od obiektu kolizyjnego
            timeSinceCollision += Time.deltaTime;
            if (timeSinceCollision > avoidanceTimeThreshold)
            {
                Vector3 avoidanceDirection = Vector3.Cross(hit.normal, Vector3.up);
                transform.position += avoidanceDirection * moveSpeed * Time.deltaTime;
                return true;
            }
        }
        else
        {
            // Jeśli nie ma kolizji, zresetuj czas od kolizji
            timeSinceCollision = 0f;
        }

        return false;
    }
}
