using Unity.Burst.Intrinsics;
using UnityEngine;

public class GainMoney : SkillClass
{
    public GainMoney()
    {
        commonDescription = "Gain 10% more money.";
        rareDescription = "Gain 15% more money.";
        epicDescription = "Gain 15% more money, but lose one heart from your healthpool.";
    }


    PlayerMovement playerAttr;
    public override void ActivateSkill(string rarity)
    {
        Debug.Log("running skill");
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
}
