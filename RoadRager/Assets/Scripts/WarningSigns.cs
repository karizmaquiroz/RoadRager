using UnityEngine;

public class WarningSigns : MonoBehaviour
{
    public Canvas warningSignCanvas;
    GameObject leftSign;
    GameObject midSign;
    GameObject rightSign;

    int leftTimer;
    int midTimer;
    int rightTimer;
    int timerLim = 100;

    private void Start()
    {
        leftSign = warningSignCanvas.transform.GetChild(0).gameObject;
        midSign = warningSignCanvas.transform.GetChild(1).gameObject;
        rightSign = warningSignCanvas.transform.GetChild(2).gameObject;
    }

    void FixedUpdate()
    {
        leftTimer++;
        midTimer++;
        rightTimer++;

        if (leftTimer >= timerLim && leftSign.activeInHierarchy) //not sure if it's better to check or just set inactive every round
        {
            leftSign.SetActive(false);
        }
        if (midTimer >= timerLim && midSign.activeInHierarchy)
        {
            midSign.SetActive(false);
        }
        if (rightTimer >= timerLim && rightSign.activeInHierarchy)
        {
            rightSign.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car")) //also check if moving backwards
        {
            if (other.GetComponent<EnemyCar>().movingForward)
            {
                if (other.transform.position.x < transform.position.x) //left
                {
                    leftTimer = 0;
                    leftSign.SetActive(true);
                }
                else if (other.transform.position.x > transform.position.x) //right
                {
                    rightTimer = 0;
                    rightSign.SetActive(true);
                }
                else //back
                {
                    midTimer = 0;
                    midSign.SetActive(true);
                }
                //instantiate warning sign
                //assign that car to the warning sign
            }
        }
    }
}
