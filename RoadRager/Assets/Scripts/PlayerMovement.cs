using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;

    public Vector3 playerPos;

    int playerLane;
    string message;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerLane = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID || UNITY_IOS
        TouchPhaseTracker();
           
#else
        PCMovement();
    
#endif
    }


    void TouchPhaseTracker()
    {
#if UNITY_ANDROID || UNITY_IOS
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    message = "Began";
                    break;

                case TouchPhase.Moved:
                    if(touch.position.x - startPos.x > 0)
                    {
                        playerPos.x += 2;
                    }
                    else
                    {
                        playerPos.x -= 2;
                    }

                    message = "Moving";
                    break;

                case TouchPhase.Ended:
                    message = "Ending";
                    break;

            }
        }
#endif
    }

    void PCMovement()
    {
        playerPos = transform.position;
        if (playerLane == 1)
        {
            Debug.Log("Player Lane: " + playerLane);
            if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("moving left");
                Vector3 newPos = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
                transform.position = newPos;
                playerLane -= 1;
            }
        }
        else if(playerLane == 0)
        {
            Debug.Log("Player Lane: " + playerLane);
            if (Input.GetKeyDown(KeyCode.D))
            {

                Debug.Log("moving right");
                Vector3 newPos = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                transform.position = newPos;
                playerLane += 1;

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("moving left");
                Vector3 newPos = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
                transform.position = newPos;
                playerLane -= 1;

            }
        }
        else if(playerLane == -1)
        {
            Debug.Log("Player Lane: " + playerLane);
            if (Input.GetKeyDown(KeyCode.D))
            {

                Debug.Log("moving right");
                Vector3 newPos = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                transform.position = newPos;
                playerLane += 1;

            }
        }
       
    }
}
