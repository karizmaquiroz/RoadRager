using UnityEngine;

public class PlayerSfx : MonoBehaviour
{
    AudioSource aud;
    void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Car") || collision.gameObject.CompareTag("Trash"))
        {
            aud.Play();
        }
    }
}
