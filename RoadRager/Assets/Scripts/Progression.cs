using UnityEngine;
using UnityEngine.UI;

public class Progression : MonoBehaviour
{
    float playerDistance;
    float distance;
    float levelCount = 1;
    float paceMultiplier = 1f; //changes as speed gets faster?
    bool paused = false;

    public Skills skillRef;
    public GameObject distUIObj;
    Slider distUI;
    //public TMP_Text distUI;

    void Start()
    {
        playerDistance = 0;
        distance = 500.0f;
        Skills.pauseGame.AddListener(Pause);
        Skills.resumeGame.AddListener(Unpause);

        distUI = distUIObj.GetComponent<Slider>();
        distUI.minValue = 0;
        distUI.maxValue = distance;
    }

    void Update()
    {
        if (!paused)
        {
            CheckIfDistanceCrossed();
            distUI.value = playerDistance;
        }
    }

    private void FixedUpdate()
    {
        if (!paused)
        {
            playerDistance += paceMultiplier;
        }
    }

    void Pause()
    {
        paused = true;
        distUI.minValue = playerDistance;
        distUIObj.SetActive(false);
    }
    void Unpause()
    {
        paused = false;
        distUI.maxValue = distance;
        distUIObj.SetActive(true);
    }

    void CalculateDistance()
    {
        distance *= levelCount;
    }

    void CheckIfDistanceCrossed()
    {
        if(playerDistance >= distance)
        {
            levelCount++;
            CalculateDistance();
            ChangeLevel();

            skillRef.SkillGenerator();
        }
    }

    public void setNewDistance(float distanceMultiplier)
    {
        levelCount += distanceMultiplier;
    }

    void ChangeLevel()
    {
        Debug.Log("new level!");
        //grab some object unique to the level scene, so that we know what scene we are in.
        //then, choose a level at random that ISN'T the current one. 
    }
}
