using UnityEngine;

public class TrashScript : MonoBehaviour
{
    Rigidbody rb;
    float spd = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * spd, ForceMode.Impulse);
    }

}
