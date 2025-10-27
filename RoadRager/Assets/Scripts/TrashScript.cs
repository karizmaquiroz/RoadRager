using UnityEngine;

public class TrashScript : MonoBehaviour
{
    Rigidbody rb;
    GameObject truck;
    Vector3 initPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        truck = GameObject.FindWithTag("Truck");
        initPos = transform.position;
        gameObject.SetActive(false);

        Skills.pauseGame.AddListener(Reset);
        Skills.resumeGame.AddListener(Reset);
    }

    private void Reset()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initPos;
        truck.SendMessage("ReAddTrash", gameObject);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
           Reset();
        }
    }
}
