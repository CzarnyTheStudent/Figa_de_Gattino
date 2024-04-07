using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DONTFUCKINGOOUTSIDE : MonoBehaviour
{
    // Ta funkcja jest wywoływana, gdy inny obiekt dotyka tego obiektu z koliderem
    private void OnCollisionStay(Collision collision)
    {
        collision.transform.position -= collision.transform.forward * 0.1f;
    }
}