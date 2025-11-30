using UnityEngine;

public class MagnetizeMoney : MonoBehaviour
{
    public GameObject player;

    public PlayerMovement magnetizeRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //player = GameObject.FindWithTag("Player");
        //magnetizeRef = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);

        if(dist < magnetizeRef.getMagentizeMultiplier())
        {
            float step = 25.0f * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            magnetizeRef.collectMoney();
            //Destroy(gameObject);
        }
    }
}
