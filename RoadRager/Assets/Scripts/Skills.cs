using Unity.Burst.Intrinsics;
using UnityEngine;

public class Skills : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public PlayerMovement playerAttr;
    public Progression distanceRef;
    public GameObject skillCanvas;

    int[,] skillArray;

    void Start()
    {
        skillArray = new int[1, 2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void skillGainMoney(string rarity)
    {
        switch (rarity)
        {
            case "common":
                playerAttr.setMoneyMultiplier(0.10f);
                break;
            case "rare":
                //gain 15% more money
                playerAttr.setMoneyMultiplier(0.15f);
                break;
            case "epic":
                //gain 30% more money, but lose one heart from your healthpool
                //reduce overall HP not HP in the moment. 
                playerAttr.setMoneyMultiplier(0.30f);
                playerAttr.setOverallHp(2);
                break;
        }
    }

    void skillGainHP(string rarity)
    {
        switch (rarity)
        {
            case "common":
                //Add one heart to healthpool
                playerAttr.setOverallHp(4);
                break;
            case "rare":
                //Add two hearts to
                playerAttr.setOverallHp(5);
                break;
            case "epic":
                //add three hearts to healthpool, but required distance increases by 15%
                playerAttr.setOverallHp(6);
                distanceRef.setNewDistance(0.15f);
                break;
        }
    }

    void skillReduceDistance(string rarity)
    {
        switch (rarity)
        {
            case "common":
                //Reduce required distance by 10%
                distanceRef.setNewDistance(-0.10f);
                break;
            case "rare":
                //Reduce required distance by 15%
                distanceRef.setNewDistance(-0.15f);
                break;
            case "epic":
                //Reduce required distance by 20%, but you gain less money.
                distanceRef.setNewDistance(-0.20f);
                playerAttr.setMoneyMultiplier(-0.30f);
                break;
        }
    }

    void generateRandomSkill()
    {
        skillArray[0, 0] = Random.Range(0, 3);
        skillArray[0, 1] = Random.Range(0, 3);
        skillArray[1, 0] = Random.Range(0, 3);
        skillArray[1, 1] = Random.Range(0, 3);
        skillArray[2,0] = Random.Range(0, 3);
        skillArray[2, 1] = Random.Range(0, 3);

    }

    public void DisplaySkills()
    {
        generateRandomSkill();

        
    }

}
