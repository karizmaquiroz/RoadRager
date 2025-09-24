using UnityEngine;

public class TrashScript : MonoBehaviour
{
    Rigidbody rb;
    float spd = 10f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnAwake()
    {
        rb.AddForce(transform.forward * spd, ForceMode.Impulse);
    }

}
