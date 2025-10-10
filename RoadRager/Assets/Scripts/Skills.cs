using Unity.Burst.Intrinsics;
using UnityEngine;

public class Skills : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    //Skill thoughts: Elevate playstyles
    /*
             * Common:
        -Add one heart to healthpool
        -Gain 10% more money
        -Reduce required distance by 10%

        Rare:
        -Add two hearts to healthpool
        -Gain 15% more money
        -Reduce required distance by 15%

        Epic:
        -Add three hearts to healthpool, your car moves slower.
        -Gain 30% more money, but you lose one heart from your healthpool
        -Reduce required distance by 20%
     */
    void Start()
    {
        
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
                //gain 10% more money
                break;
            case "rare":
                //gain 15% more money
                break;
            case "epic":
                //gain 30% more money, but lose one heart from your healthpool
                //reduce overall HP not HP in the moment. 
                break;
        }
    }

    void skillGainHP(string rarity)
    {
        switch (rarity)
        {
            case "common":
             //Add one heart to healthpool
                break;
            case "rare":
                //Add two hearts to healthpool
                break;
            case "epic":
                //add three hearts to healthpool, but required distance increases by 15%
                break;
        }
    }

    void skillReduceDistance(string rarity)
    {
        switch (rarity)
        {
            case "common":
                //Reduce required distance by 10%
                break;
            case "rare":
                //Reduce required distance by 15%
                break;
            case "epic":
                //Reduce required distance by 20%, but you gain less money.
                break;
        }
    }

}
