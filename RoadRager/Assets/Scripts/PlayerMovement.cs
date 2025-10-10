using UnityEditor.ShaderGraph.Internal;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.Rendering;
using System;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;

    public Vector3 playerPos;
    public Vector3 origPlayerPos;

    Vector2 startPosSwipe;
    Vector2 endPosSwipe;

    float requiredSwipe = 200.0f;

    int playerLane;
    string message;

    int playerHp = 3;
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
        if(playerHp == 0)
        {
            endGame();
        }
    }


    void TouchPhaseTracker()
    {
#if UNITY_ANDROID || UNITY_IOS
        playerPos = transform.position;
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPos = touch.position;
                    startPosSwipe = touch.position;
                    break;

                case TouchPhase.Moved:
                    
                        if (touch.position.x - startPos.x > 0 && (playerLane == -1))
                        {
                            endPosSwipe = touch.position;
                            if(DetectSwipe(TouchPhase.Ended, startPosSwipe, endPosSwipe))
                            {
                                Vector3 newPos = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                                transform.position = newPos;
                                playerLane += 1;
                            }
                            
                            
                          
                        }
                        else if (touch.position.x - startPos.x < 0 && (playerLane == 1))
                        {
                        endPosSwipe = touch.position;
                            if (DetectSwipe(TouchPhase.Ended,startPosSwipe, endPosSwipe))
                            {
                                Vector3 newPos = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
                                transform.position = newPos;
                                playerLane -= 1;
                            }
                           
                        }
                        else if (playerLane == 0)
                        {
                            if (touch.position.x - startPos.x > 0)
                            {
                            endPosSwipe = touch.position;
                                if (DetectSwipe(TouchPhase.Ended,startPosSwipe, endPosSwipe))
                                {
                                    Vector3 newPos = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                                    transform.position = newPos;
                                    playerLane += 1;
                                }
                                
                            }
                            else if (touch.position.x - startPos.x < 0)
                            {
                                endPosSwipe = touch.position;
                                if (DetectSwipe(TouchPhase.Ended,startPosSwipe, endPosSwipe))
                                {
                                    Vector3 newPos = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
                                    transform.position = newPos;
                                    playerLane -= 1;
                                }
                             
                            }
                        }
                    
                break;
                        

                case TouchPhase.Ended:
                    
                    break;

            }
        }
#endif
    }


    Vector2 CalculateStartPos(Touch touch)
    {
        Vector2 startPos = touch.position;
        return startPos;
    }

    bool DetectSwipe(TouchPhase phase1, Vector2 startingSwipePos, Vector2 endSwipePos)
    {
        Debug.Log("Detecting a swipe"); 
       
        if(phase1 == TouchPhase.Ended)
        {
            Debug.Log("End.");
            Vector2 endPosSwipe = endSwipePos;
            Vector2 swipe = endPosSwipe - startingSwipePos;
            Debug.Log("Swipe.x: " + swipe.x);
            Debug.Log("StartingSwipe: " + startingSwipePos);
            Debug.Log(endPosSwipe);
            Debug.Log("required swipe: " + requiredSwipe);
            if (Math.Abs(swipe.x) >= requiredSwipe)
            {
                Debug.Log("Swipe Dectected");
                return true;
            }
        }
        /*
        switch (touch.phase)
        {
                
           case TouchPhase.Began:
              Debug.Log("Began.");
              startPosSwipe = touch.position;
              Debug.Log("startPosSwipe: " + startPosSwipe);
           break;
           case TouchPhase.Moved:
           break;
           case TouchPhase.Ended:
               Debug.Log("End.");
               Vector2 endPosSwipe = touch.position;
               Vector2 swipe = endPosSwipe - startPosSwipe;
               Debug.Log("Swipe.x: " + swipe.x);
                if(swipe.x > requiredSwipe)
                {
                    Debug.Log("Swipe Dectected");
                    return true;
                }
           break;
                    

        }
        */
            
        
        Debug.Log("Swipe not Detected");
        return false;
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

    private void OnCollisionEnter(Collision collision)
    {
        GameObject gameObject = collision.gameObject;

        if(gameObject.tag == "Enemy")
        {
            setHP(1);
        }
    }

    void setHP(int damage)
    {
        playerHp -= damage;
    }

    void endGame()
    {
        Debug.Log("Game Over");
    }


}

