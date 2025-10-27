using UnityEngine;

public class Progression : MonoBehaviour
{
    float playerDistance;
    float distance;
    float levelCount = 1;
    float paceMultiplier = 1f; //changes as speed gets faster?

    Skills skillRef;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerDistance = 0;
        distance = 500.0f;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDistanceCrossed();
    }

    private void FixedUpdate()
    {
        playerDistance += paceMultiplier;
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
