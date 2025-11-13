using Unity.VisualScripting;
using UnityEngine;

public class EnemyCar : MonoBehaviour
{
    Rigidbody rb;
    GameObject truck;
    Vector3 initPos;
    public bool movingForward = true;
    public float moveSpd = 10f;
    bool spinningOut = false;
    int spinoutDir = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        truck = GameObject.FindWithTag("Truck");
        initPos = transform.position;
        gameObject.SetActive(false);

        Skills.pauseGame.AddListener(Reset);
        Skills.resumeGame.AddListener(Reset);
    }
    void OnAwake()
    {
        spinningOut = false;
    }


    void FixedUpdate()
    {
        if (!spinningOut)
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
        else
        {
            SpinOut();
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

    void SpinOut()
    {
        transform.Rotate(0f, moveSpd * spinoutDir, 0f);
        transform.position += new Vector3(spinoutDir * 0.5f, 0f, 1f);
        Invoke("Reset", 5);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Reset();
        }
        if (collision.gameObject.CompareTag("Player")) //add later; sound and explosion
        {
            if (transform.position.x > truck.transform.position.x) //in right lane
            {
                spinoutDir = 1;
            }
            else if (transform.position.x < truck.transform.position.x) //in left lane
            {
                spinoutDir = -1;
            }
            else //in middle lane
            {
                spinoutDir = Random.Range(0, 2);
            }
            spinningOut = true;
        }
    }
}
