using UnityEngine;

public class Progression : MonoBehaviour
{
    float playerDistance;
    float distance;
    float levelCount = 1;

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

    void CalculateDistance()
    {
        distance *= levelCount;
    }

    void CheckIfDistanceCrossed()
    {
        if(playerDistance == distance)
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
        //grab some object unique to the level scene, so that we know what scene we are in.
        //then, choose a level at random that ISN'T the current one. 
    }
}
