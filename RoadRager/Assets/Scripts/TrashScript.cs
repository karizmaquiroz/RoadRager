using TMPro;
using UnityEngine;

public class TrashScript : MonoBehaviour
{
    Rigidbody rb;
    public float spd = 3f;
    GameObject truck;
    Vector3 initPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        rb.useGravity = false;
        truck = GameObject.FindWithTag("Truck");
        initPos = transform.position;
    }

    public void Move() //sometimes moves backward after resetting??
    {
        SetVar();
        rb.AddForce(-transform.forward * spd * Time.fixedDeltaTime, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.rotation = Quaternion.identity;
            SetVar();
            transform.position = initPos;
            truck.SendMessage("ReAddTrash", gameObject);
        }
    }

    void SetVar()
    {
        rb.useGravity = !rb.useGravity;
        GetComponent<MeshRenderer>().enabled = !GetComponent<MeshRenderer>().enabled;
        GetComponent<SphereCollider>().enabled = !GetComponent<SphereCollider>().enabled;
    }

}
