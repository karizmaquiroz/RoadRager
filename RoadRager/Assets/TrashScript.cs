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

    //private void Update()
    //{
    //    if (transform.position.y < 0)
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Destroy(gameObject);
        }
    }

}
