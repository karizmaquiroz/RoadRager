using UnityEngine;
using UnityEngine.UI;

public class WarningSigns : MonoBehaviour
{
    public Canvas warningSignCanvas; //idk if this still needs to be here
    public GameObject warningSign;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) //also check if moving backwards
        {
            if (other.GetComponent<EnemyCar>().movingForward)
            {
                GameObject sign = Instantiate(warningSign, new Vector3(0f, 0f, 0f), Quaternion.identity);
                sign.transform.SetParent(warningSignCanvas.transform, false);
                sign.GetComponent<WarningSignPrefab>().followCar = other.transform;
            }
        }
    }
}
