using Unity.VisualScripting;
using UnityEngine;

public class WarningSignPrefab : MonoBehaviour
{
    [System.NonSerialized] public Transform followCar = null;
    GameObject player;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player");
        Invoke("TurnOff", 2f); //hardcoding this rn but if it works it works
    }

    void TurnOff()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        if (followCar != null && !followCar.GetComponent<EnemyCar>().spinningOut)
        {
            transform.localPosition = new Vector3(75f * (followCar.position.x - player.transform.position.x), -250f, 0f);
        }
    }
}
