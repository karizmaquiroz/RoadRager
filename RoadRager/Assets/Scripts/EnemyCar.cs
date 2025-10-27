using Unity.VisualScripting;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    Rigidbody rb;
    GameObject truck;
    Vector3 initPos;
    public bool movingForward = true;
    float moveSpd = 10f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        truck = GameObject.FindWithTag("Truck");
        initPos = transform.position;
        gameObject.SetActive(false);

        Skills.pauseGame.AddListener(Reset);
        Skills.resumeGame.AddListener(Reset);
    }

    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, truck.transform.position) < 10f)
        {
            movingForward = false;
        }
        if (movingForward)
        {
            MoveForward();
        }
        else
        {
            MoveBack();
        }
    }

    void MoveForward()
    {
        transform.position += new Vector3(0f, 0f, moveSpd) * Time.fixedDeltaTime;
    }

    void MoveBack() //happens until colliding with despawn trigger
    {
        transform.position -= new Vector3(0f, 0f, moveSpd) * Time.fixedDeltaTime;
    }

    private void Reset()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = initPos;
        truck.SendMessage("ReAddCar", gameObject);
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
