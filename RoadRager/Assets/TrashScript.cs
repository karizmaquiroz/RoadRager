using UnityEngine;

public class TrashScript : MonoBehaviour
{
    Rigidbody rb;
    float spd = 10f;

    public void Move()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward * spd, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

}
