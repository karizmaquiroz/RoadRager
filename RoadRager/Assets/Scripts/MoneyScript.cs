using UnityEngine;

public class MoneyScript : MonoBehaviour
{
    Rigidbody rb;
    GameObject truck;
    Vector3 initPos;
    [System.NonSerialized] public float moveSpd = 10f; //make it match enemy car when it slows down?
    //AudioSource aud;
    GameObject player;
    PlayerMovement magnetizeRef;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        truck = GameObject.FindWithTag("Truck");
        initPos = transform.position;
        gameObject.SetActive(false);

        Skills.pauseGame.AddListener(Reset);
        Skills.resumeGame.AddListener(Reset);

        //aud = GetComponent<AudioSource>();

        player = GameObject.FindWithTag("Player");
        magnetizeRef = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);

        if (dist <= magnetizeRef.getMagentizeMultiplier())
        {
            float step = 25.0f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
            if (dist < 0.2f)
            {
                MoneyGain();
            }
        }
        else
        {
            transform.position -= new Vector3(0f, 0f, moveSpd) * Time.deltaTime;
        }
        transform.Rotate(0f, 3f, 0f);
    }

    void MoneyGain()
    {
        magnetizeRef.collectMoney();
        Reset();
        //aud.Play();
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
            MoneyGain();
        }
    }
}
