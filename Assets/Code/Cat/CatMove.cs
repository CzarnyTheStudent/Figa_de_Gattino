using UnityEngine;

public class CatMove : MonoBehaviour
{
    public float moveSpeed = 5f; // Prędkość poruszania się postaci
    public float rotationSpeed = 10f; // Prędkość obrotu postaci

    public Transform cameraTarget; // Cel kamery, którym będzie postać
    public float cameraDistance = 5f; // Odległość kamery od postaci
    public float cameraHeight = 5f; // Wysokość kamery nad postacią

    //private Rigidbody rb;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Rotate();
        UpdateCameraPosition();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime, Space.World);
    }

    void Rotate()
    {
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            Vector3 lookDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        }
    }

    void UpdateCameraPosition()
    {
        // Oblicz pozycję kamery
        Vector3 cameraPosition = transform.position - new Vector3(-cameraDistance, -cameraHeight, cameraDistance);
        // Ustaw pozycję kamery
        Camera.main.transform.position = cameraPosition;
        // Należy pamiętać, żeby kamera zawsze patrzyła na cel (postać)
        Camera.main.transform.LookAt(cameraTarget);
    }
    
}