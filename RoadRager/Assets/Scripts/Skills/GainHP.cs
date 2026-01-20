using UnityEngine;

public class GainHP : SkillClass
{
    PlayerMovement playerAttr;
    Progression distanceRef;

    public GainHP()
    {
        commonDescription = "Add one heart to your healthpool.";
        rareDescription = "Add two hearts to your healthpool.";
        epicDescription = "Add three hearts to your healthpool, but the required distance increases by 15%.";
    }

    public override void ActivateSkill(string rarity)
    {
        Debug.Log("running skill"); //heal instead of overall hp?
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


}
