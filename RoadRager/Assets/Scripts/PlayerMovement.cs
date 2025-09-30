//using UnityEditor.ShaderGraph.Internal;
//using UnityEditor.VersionControl;
using UnityEngine;
//using UnityEngine.Rendering;
//using System;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;

    public Vector3 playerPos;
    public Vector3 origPlayerPos;

    int playerLane;
    //string message;

    bool swiped = false;


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
//#if UNITY_ANDROID || UNITY_IOS
    playerPos = transform.position;
    //float bTime = 0;
    //float eTime = 0;
    if (Input.touchCount > 0)// && swipeTimer > 60)
    {
            Debug.Log(Input.touchCount);
            Touch touch = Input.GetTouch(0);

            

        switch (touch.phase)
        {
            case TouchPhase.Began:
                startPos = touch.position;
               // Debug.Log("Touch Started");
                //bTime = Time.time;
                //Debug.Log("bTime" + bTime);
                break;

            case TouchPhase.Moved:

                    if (!swiped && touch.position.x - startPos.x > 0) // && touch.position.x > 50) //&& (playerLane == -1)
                    {
                        //Debug.Log("Moving Right");
                        //Vector3 newPos = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                        transform.position = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                        playerLane += 1;

                    }
                    else if (!swiped && touch.position.x - startPos.x < 0)// && touch.position.x > 50) //&& (playerLane == 1) 
                    {
                        //Debug.Log("Moving Left");
                        //Vector3 newPos = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
                        transform.position = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
                        playerLane -= 1;
                    }
                    else if (playerLane == 0)
                    {
                        if (!swiped && touch.position.x - startPos.x > 0 && touch.position.x > 50)
                        {
                            //Debug.Log("Centered: Moving Right");
                            //Vector3 newPos = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                            transform.position = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                            playerLane += 1;
                        }
                        else if (!swiped && touch.position.x - startPos.x < 0 && touch.position.x > 50)
                        {
                            //Debug.Log("Centered: Moving Left");
                            //Vector3 newPos = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
                            transform.position = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
                            playerLane -= 1;
                        }
                    }

                    swiped = true;


                    break;

            case TouchPhase.Ended:
                    //Debug.Log("Touch Ended");
                    swiped = false;
                break;


        }
    }
//#endif
    }

    //float TouchTime()
    //{
    //    float bTime = Time.time;
    //    float eTime = Time.time + 3.0f;

    //    Debug.Log("Time.time: " + bTime);
    //    Debug.Log("Time.time +3: " + eTime);

    //    return eTime;
    //}

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
