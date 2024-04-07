using UnityEngine;

public class CatMove : MonoBehaviour
{
    public float moveSpeed = 5f; 
    public float rotationSpeed = 10f; 
    public Transform cameraTarget; 
    public float cameraDistance = 5f; 
    public float cameraHeight = 5f; 
    [SerializeField]private Animator catAnim;

    private Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection.Set(horizontalInput, 0f, verticalInput);
        moveDirection = moveDirection.normalized * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + moveDirection);
    }

    void Rotate()
    {
        if (moveDirection != Vector3.zero)
        {
            Vector3 lookDirection = moveDirection;
            Quaternion rotation = Quaternion.LookRotation(lookDirection);
            rb.isKinematic = false;
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, rotation, rotationSpeed * Time.fixedDeltaTime));
            catAnim.SetBool("Move", true);
        }
        else
        {
            rb.isKinematic = true;
            catAnim.SetBool("Move", false);
        }
    }

    void LateUpdate()
    {
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        Vector3 cameraPosition = transform.position - new Vector3(-cameraDistance, -cameraHeight, cameraDistance);
        Camera.main.transform.position = cameraPosition;
        Camera.main.transform.LookAt(cameraTarget);
    }
}