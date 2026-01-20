using UnityEngine;

public class ReduceDistance : SkillClass
{
    public Progression distanceRef;
    public PlayerMovement playerAttr;
    public ReduceDistance()
    {
        commonDescription = "Reduce required distance by 10%.";
        rareDescription = "Reduce required distance by 15%.";
        epicDescription = "Reduce required distance by 20%, but you gain 30% less money.";
    }

    public override void ActivateSkill(string rarity)
    {
        Debug.Log("running skill");
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
}
