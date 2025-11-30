using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    Rigidbody rb;
    GameObject truck;
    Vector3 initPos;
    public float moveSpd = 10f; //make it match enemy car when it slows down?
    //AudioSource aud;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        truck = GameObject.FindWithTag("Truck");
        initPos = transform.position;
        gameObject.SetActive(false);

        Skills.pauseGame.AddListener(Reset);
        Skills.resumeGame.AddListener(Reset);

        //aud = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(0f, 0f, -moveSpd) * Time.fixedDeltaTime;
        transform.Rotate(0f, 3f, 0f);
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
        if (collision.gameObject.CompareTag("Player")) //add later; sound and explosion
        {
            //need to put in money stuff
        }
    }
}
