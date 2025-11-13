using UnityEngine;

public class WarningSignPrefab : MonoBehaviour
{
    public GameObject followCar = null;

    void SetCar(GameObject car)
    {
        followCar = car;
    }

    void Update()
    {
        if (followCar != null) { 

        }
    }
}
