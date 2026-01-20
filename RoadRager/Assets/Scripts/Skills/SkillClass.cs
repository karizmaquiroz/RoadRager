using UnityEngine;

public abstract class SkillClass
{
    protected string commonDescription;
    protected string rareDescription;
    protected string epicDescription;
    
    string rarity;

    public SkillClass()
    {
       
    }

    public abstract void ActivateSkill(string rarity);


}
