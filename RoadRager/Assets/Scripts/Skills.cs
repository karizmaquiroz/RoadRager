using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class Skills : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public PlayerMovement playerAttr;
    public Progression distanceRef;
    public GameObject skillCanvas;

    int[,] skillArray;
    string[,] stringSkillArray;

    public TMP_Text skillText1;
    public TMP_Text skillText2;
    public TMP_Text skillText3;

    void Start()
    {
        skillArray = new int[3, 2];
        stringSkillArray = new string[3, 2];    
        
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

    void skillMagnetizeMoney(float magnetStr)
    {

    }

    void skillIncreaseArmor(string rarity)
    {
        switch (rarity)
        {
            case "common":
                playerAttr.setArmorMultiplier(0.5f);
                break;
            case "rare":
                playerAttr.setArmorMultiplier(0.25f);
                break;
            case "epic":
                playerAttr.setArmorMultiplier(0.15f);
                playerAttr.setMoneyMultiplier(-0.15f);

                break;

        }
       
    }

    bool skillNegateDamage(string rarity)
    {
        int noDamageChance = UnityEngine.Random.Range(0, 11);
        switch (rarity)
        {
            case "common":
                if(noDamageChance <= 1)
                {
                    return true;
                }
                break;
            case "rare":
                if(noDamageChance<=1.5)
                {
                    return true;
                }
                break;
            case "epic":
                if(noDamageChance <= 2)
                {
                    return true;
                }
                break;
        }

        return false;
    }

    void skillFasterCar()
    {

    }

    void skillSlowEnemy(float slowMultiplier)
    {

    }

    public void SkillGenerator()
    {
        //iterate and set
        for (int i = 0; i < 3; i++)
        {
         
            for (int j = 0; j < 2; j++)
            {
                if(j == 0)
                {
                    skillArray[i, j] = UnityEngine.Random.Range(0, 8);
                }
                else if(j == 1)
                {
                    skillArray[i, j] = UnityEngine.Random.Range(0, 11);
                }

                    Debug.Log("Skillset " + i + ": " + skillArray[i, j]);

            }
        }



        /*
        if (!CheckForDuplicateSkill(skillArray))
        {
            SkillGenerator();
        }
        */


        //now we parse the array -- array format [skill type, skill rarity]
        for (int i = 0; i < 3; i++)
        {
            int tempNumber = skillArray[i,0];
            Debug.Log("TempNumberOfSA: " + tempNumber);

            switch (tempNumber)
            {
                case 0:
                    Debug.Log("Case 0");
                    stringSkillArray[i,0] = "gainmoney";

                    break;
                case 1:
                    Debug.Log("Case 1");
                    stringSkillArray[i,0] = "gainhp";

                    break;
                case 2:
                    Debug.Log("Case 2");
                    stringSkillArray[i, 0] = "reducedistance";
                    break;
                case 3:
                    Debug.Log("Case 3");
                    stringSkillArray[i, 0] = "magnetize";
                    break;
                case 4:
                    Debug.Log("Case 4");
                    stringSkillArray[i, 0] = "increasearmor";
                    break;
                case 5:
                    Debug.Log("5");
                    stringSkillArray[i, 0] = "negate";
                    break;
                case 6:
                    Debug.Log("6");
                    stringSkillArray[i, 0] = "fastcar";
                    break;
                case 7:
                    Debug.Log("7");
                    stringSkillArray[i, 0] = "slowenemy";
                    break;

            }

           
        }

        int counter = 0;
        for (int i = 0; i < 3; i++)
        {
           
            int tempNumber2 = skillArray[i, 1];
            Debug.Log("TempNumberOfRaritySA: " + tempNumber2);

            switch (tempNumber2)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    stringSkillArray[i, 1] = "common";
                    break;

                case 7:
                case 8:
                case 9:
                    stringSkillArray[i, 1] = "rare";
                    break;
                case 10:
                    stringSkillArray[i, 1] = "epic";
                    break;

            }
            counter++;
        }




        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Debug.Log("Skill + Rarity BEFORE PASS: " + stringSkillArray[i, j]);
            }
        }


        DisplaySkills(stringSkillArray);

    }

    /*

    bool CheckForDuplicateSkill(int[,] skillArray)
    {
        //Make a set, if the set size < the size of the array, then there's duplicates. 	//Genius work actually
        HashSet<int> skillNumbers = new HashSet<int>();
        for (int i = 0; i < 2; i++)
        {
            int curRow = skillArray[i,0];
            skillNumbers.Add(curRow);
           
        }
        if(skillNumbers.Count < skillArray.Length)
        {
            return true;
        }

            return false;
    }
    */
    
    string DetermineSkill(string skill)
    {
        Debug.Log("DS skillPass: " +  skill);
        string[] skillParse = skill.Split(',');
        string fullSkill = null;
        if(skill.Contains("gainmoney") == true)
        {
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "Gain 10% more money from coins";
                    break;
                case "rare":
                    fullSkill = "Gain 15% more money from coins";
                    break;
                case "epic":
                    fullSkill = "Gain 30% more money from coins, but your health pool decreases by one";
                    break;

            }
        }

        if (skill.Contains("gainhp"))
        {
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "Gain one heart to your health pool";
                    break;
                case "rare":
                    fullSkill = "Gain two hearts to your health pool";
                    break;
                case "epic":
                    fullSkill = "Gain three hearts to your health pool, but your distance to travel is increased by 50%";
                    break;
            }
        }

        if (skill.Contains("reducedistance"))
        {
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "Reduce distance needed by 10%";
                    break;
                case "rare":
                    fullSkill = "Reduce distance needed by 15%";
                    break;
                case "epic":
                    fullSkill = "Reduce distance needed by 30%, but you collect 15% less money";
                    break;
            }
        }

        if (skill.Contains("magnetize"))
        {
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "Money is magnetized by 5%";
                    break;
                case "rare":
                    fullSkill = "Money is magnetized by 8%";
                    break;
                case "epic":
                    fullSkill = "Money is magnetized by 10% -- (add more)";
                    break;
            }
        }

        if (skill.Contains("increasearmor"))
        {
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "You take 50% less damage.";
                    break;
                case "rare":
                    fullSkill = "You take 75% less damage";
                    break;
                case "epic":
                    fullSkill = "You take 100% less damage, but your travel distance is increased by 50%";
                    break;
            }
        }

        if (skill.Contains("negate"))
        {
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "You have a 10% chance to not take damage.";
                    break;
                case "rare":
                    fullSkill = "You have a 15% chance to not take damage.";
                    break;
                case "epic":
                    fullSkill = "You have a 20% chance to not take damage.";
                    break;
            }
        }

        if (skill.Contains("fastcar"))
        {
            //Ivy here :)
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "placeholder";
                    break;
                case "rare":
                    fullSkill = "placeholder";
                    break;
                case "epic":
                    fullSkill = "placeholder";
                    break;

            }
        }

        if (skill.Contains("slowenemy"))
        {
            //Aiden here :)
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "placeholder";
                    break;
                case "rare":
                    fullSkill = "placeholder";
                    break;
                case "epic":
                    fullSkill = "placeholder";
                    break;
            }
        }

        return fullSkill;
    }

    public void DisplaySkills(string[,] skillArray)
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j <2; j++)
            {
                Debug.Log("Skill + Rarity DS PASS: " + skillArray[i,j]);
            }
        }
        string skill0 = null;
        string skill1 = null;
        string skill2 = null;
        string tempString = null;

        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 2; j++)
            {
               
                tempString += skillArray[i, j] + ',';

            }

            if(i == 0)
            {
                skill0 = tempString;
            }
            else if(i == 1)
            {
                skill1 = tempString;
            }
            else if (i == 2)
            {
                skill2 = tempString;
            }

            tempString = null;
        }

        Debug.Log("Skill0 " + skill0);
        Debug.Log("Skill1 " + skill1);
        Debug.Log("Skill2 " + skill2);


        skillText1.text = DetermineSkill(skill0);
        skillText2.text = DetermineSkill(skill1);
        skillText3.text = DetermineSkill(skill2);

        Debug.Log("1.String: " + skillText1.text);
        Debug.Log("2.String: " + skillText2.text);
        Debug.Log("3.String: " + skillText3.text);

    }

}
