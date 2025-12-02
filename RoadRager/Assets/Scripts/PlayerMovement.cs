//using UnityEditor.ShaderGraph.Internal;
//using UnityEditor.VersionControl;
using UnityEngine;
//using UnityEngine.Rendering;
using System;
using TMPro;
//using UnityEditor.TerrainTools;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 startPos;
    public Vector2 direction;

    public Vector3 playerPos;
    public Vector3 origPlayerPos;

    Vector2 startPosSwipe;
    Vector2 endPosSwipe;

    Vector3 newPos; //needs to be saved globally so Lerp works
    public float spd; //3f

    float requiredSwipe = 200.0f;

    int playerLane;

    float playerHp;
    int totalPlayerHp;

    float moneyAmount;
    float moneyMultiplier;
    float armorMultiplier;
    float noDamageChance;
    float magnetizeMultiplier;

    public Animator playerAnim;

    public TMP_Text hpText;
    public static bool paused = false;

    public GameObject gameOver;

    public TMP_Text moneyTxt; //moneycounter contains this



    void Start()
    {
        paused = false;
        playerLane = 0;
        playerHp = 3;
        //moneyAmount = 0; is instantiated in save mamanger as money
        moneyMultiplier = 1;
        magnetizeMultiplier = 0;

        Skills.pauseGame.AddListener(Pause);
        Skills.resumeGame.AddListener(Unpause);

        newPos = transform.position;

        //moneyTxt.text = "Money: " + moneyAmount.ToString();

        // initialize UI at start
        if (moneyTxt != null)
            moneyTxt.text = "Money: $" + SaveManager.instance.money;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.text = "HP: " + playerHp.ToString();
        if (playerHp <= 0)
        {
            Skills.pauseGame.Invoke();
            gameOver.SetActive(true);
        }
        if (!paused)
        { //mobile controls need to be tested!!
#if UNITY_ANDROID || UNITY_IOS
        TouchPhaseTracker();
           
#else
            PCMovement();

#endif
            MovePlayer();
            if (playerHp == 0)
            {
                endGame();
            }
        }
        else //if in skill select; makes sure the lane pos don't skew
        {
            transform.position = newPos;
        }
    }

    void Pause()
    {
        paused = true;
    }
    void Unpause()
    {
        paused = false;
    }


    void TouchPhaseTracker()
    {
#if UNITY_ANDROID || UNITY_IOS
        playerPos = transform.position;
        Vector3 newPos = Vector3.zero;
        
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
                                newPos = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                                playerLane += 1;
                            }
                            
                            
                          
                        }
                        else if (touch.position.x - startPos.x < 0 && (playerLane == 1))
                        {
                        endPosSwipe = touch.position;
                            if (DetectSwipe(TouchPhase.Ended,startPosSwipe, endPosSwipe))
                            {
                                newPos = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
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
                                    newPos = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                                    playerLane += 1;
                                }
                                
                            }
                            else if (touch.position.x - startPos.x < 0)
                            {
                                endPosSwipe = touch.position;
                                if (DetectSwipe(TouchPhase.Ended,startPosSwipe, endPosSwipe))
                                {
                                    newPos = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
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

        if (phase1 == TouchPhase.Ended)
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
        playerPos = newPos;
        if (playerLane == 1)
        {
            
            if (Input.GetKeyDown(KeyCode.A))
            {
                playerAnim.Play("Steering Wheel Left");
                newPos = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
                playerLane -= 1;
            }
        }
        else if (playerLane == 0)
        {
            
            if (Input.GetKeyDown(KeyCode.D))
            {

                playerAnim.Play("Steering Wheel Right");
                newPos = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                playerLane += 1;

            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                playerAnim.Play("Steering Wheel Left");
                newPos = new Vector3(playerPos.x - 3, playerPos.y, playerPos.z);
                playerLane -= 1;

            }
        }
        else if (playerLane == -1)
        {
            
            if (Input.GetKeyDown(KeyCode.D))
            {

                playerAnim.Play("Steering Wheel Right");
                newPos = new Vector3(playerPos.x + 3, playerPos.y, playerPos.z);
                playerLane += 1;

            }
        }
    }

    void MovePlayer()
    {
        if (newPos != Vector3.zero)
        {
            transform.position = Vector3.Lerp(transform.position, newPos, spd * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        GameObject gameObject = collision.gameObject;

        if (gameObject.layer == 3) //obstacle layer
        {
            Debug.Log("hit");
            setHP(1 );
        }

    }

    void setHP(int damage) //need to test
    {
        if (armorMultiplier > 0f)
        {
            float reducedDmg = damage * armorMultiplier;
            playerHp -= reducedDmg;
        }
        else
        {
            playerHp -= damage;
        }
    }

    void endGame()
    {
        Debug.Log("Game Over");
    }

    public void setOverallHp(int hp)
    {
        totalPlayerHp = hp;
        playerHp += hp - playerHp; //need to test
    }
    public void setMoneyMultiplier(float multiplier)
    {
        moneyMultiplier += multiplier;
    }

    public void setRequiredDistance()
    {

    }

    public void setArmorMultiplier(float multiplier)
    {
        armorMultiplier = multiplier;
    }

    public void setNoDamageChance(float damageChance)
    {
        noDamageChance = damageChance;
    }

    public void setMagentizeMultiplier(float multiplier)
    {
        magnetizeMultiplier = multiplier;
    }

    public float getMagentizeMultiplier()
    {
        return magnetizeMultiplier;
    }

    public void collectMoney()
    {
        // Increase saved money
        SaveManager.instance.money += Mathf.RoundToInt(moneyMultiplier);

        // Save the updated money value permanently
        SaveManager.instance.Save();

        // Update UI
        if (moneyTxt != null)
            moneyTxt.text = "Money: $" + SaveManager.instance.money;
    }

  

}

