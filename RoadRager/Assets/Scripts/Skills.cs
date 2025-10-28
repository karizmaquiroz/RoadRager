using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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

    string skill0;
    string skill1;
    string skill2;

    public static UnityEvent pauseGame = new UnityEvent();
    public static UnityEvent resumeGame = new UnityEvent();

    void Start()
    {
        skillArray = new int[3, 2];
        stringSkillArray = new string[3, 2];

        skill0 = null;
        skill1 = null;
        skill2 = null;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void skillGainMoney(string rarity)
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

    void skillGainHP(string rarity)
    {
        Debug.Log("running skill");
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

    void skillMagnetizeMoney(string rarity)
    {
        Debug.Log("running skill");
    }

    void skillIncreaseArmor(string rarity)
    {
        Debug.Log("running skill");
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
        Debug.Log("running skill");
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

    void skillFasterCar(string rarity)
    {
        Debug.Log("running skill");
    }

    void skillSlowEnemy(string rarity)
    {
        Debug.Log("running skill");
    }

    public void SkillGenerator()
    {
        pauseGame.Invoke();
        skillCanvas.SetActive(true);
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



        
        if (CheckForDuplicateSkill(skillArray))
        {
            Debug.Log("rerolling");
            SkillGenerator();
        }
        


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


    bool CheckForDuplicateSkill(int[,] skillArray)
    {
        int firstSkill = 0;
        int secondSkill = 0;
        int thirdSkill = 0;

        Debug.Log("Checking for Duplicates.");

        for (int i = 0; i < 3; i++)
        {
            if (i == 1)
            {
                firstSkill = skillArray[i, 0];
            }

            if (i == 2)
            {
                secondSkill = skillArray[i, 0];
            }

            if (i == 3)
            {
                thirdSkill = skillArray[i, 0];
            }
        }

        if (firstSkill == secondSkill || firstSkill == thirdSkill || secondSkill == thirdSkill)
        {
            Debug.Log("Duplicate Found");
            return true;
        }
        Debug.Log("Duplicate Not FOund");
            return false;
    }
   
    
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

    public void ApplySkills(Button clickedButton)
    {
        TMP_Text buttonText = clickedButton.GetComponentInChildren<TMP_Text>();
        string tempString = buttonText.text;

        skillCanvas.SetActive(false);
        resumeGame.Invoke();

        Debug.Log(tempString);
        Debug.Log("SkillText1: " + skillText1.text);

        Debug.Log(skill0);
        

        if(tempString == skillText1.text)
        {
            string[] skillParse = skill0.Split(',');
            

            if (skill0.Contains("gainhp"))
            {
                
                switch (skillParse[1])
                {
                    case "common":
                        skillGainHP("common");
                        break;
                    case "rare":
                        skillGainHP("rare");
                        break;
                    case "epic":
                        skillGainHP("epic");
                        break;
                }
            }

            if (skill0.Contains("reducedistance"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillReduceDistance("common");
                        break;
                    case "rare":
                        skillReduceDistance("rare");
                        break;
                    case "epic":
                        skillReduceDistance("epic");
                        break;
                }
            }

            if (skill0.Contains("magnetize"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillMagnetizeMoney("common");
                        break;
                    case "rare":
                        skillMagnetizeMoney("rare");
                        break;
                    case "epic":
                        skillMagnetizeMoney("epic");
                        break;
                }
            }

            if (skill0.Contains("increasearmor"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillIncreaseArmor("common");
                        break;
                    case "rare":
                        skillIncreaseArmor("rare");
                        break;
                    case "epic":
                        skillIncreaseArmor("epic");
                        break;
                }
            }

            if (skill0.Contains("negate"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillNegateDamage("common");
                        break;
                    case "rare":
                        skillNegateDamage("rare");
                        break;
                    case "epic":
                        skillNegateDamage("epic");
                        break;
                }
            }

            if (skill0.Contains("fastcar"))
            {
                //Ivy here :)
                switch (skillParse[1])
                {
                    case "common":
                        skillFasterCar("common");
                        break;
                    case "rare":
                        skillFasterCar("rare");
                        break;
                    case "epic":
                        skillFasterCar("epic");
                        break;

                }
            }

            if (skill0.Contains("slowenemy"))
            {
                //Aiden here :)
                switch (skillParse[1])
                {
                    case "common":
                        skillSlowEnemy("common");
                        break;
                    case "rare":
                        skillSlowEnemy("rare");
                        break;
                    case "epic":
                        skillSlowEnemy("epic");
                        break;
                }
            }
        }
        else if(tempString == skillText2.text)
        {
            
                string[] skillParse = skill1.Split(',');

                if (skill1.Contains("gainhp"))
                {

                    switch (skillParse[1])
                    {
                        case "common":
                            skillGainHP("common");
                            break;
                        case "rare":
                            skillGainHP("rare");
                            break;
                        case "epic":
                            skillGainHP("epic");
                            break;
                    }
                }

                if (skill1.Contains("reducedistance"))
                {
                    switch (skillParse[1])
                    {
                        case "common":
                            skillReduceDistance("common");
                            break;
                        case "rare":
                            skillReduceDistance("rare");
                            break;
                        case "epic":
                            skillReduceDistance("epic");
                            break;
                    }
                }

                if (skill1.Contains("magnetize"))
                {
                    switch (skillParse[1])
                    {
                        case "common":
                            skillMagnetizeMoney("common");
                            break;
                        case "rare":
                            skillMagnetizeMoney("rare");
                            break;
                        case "epic":
                            skillMagnetizeMoney("epic");
                            break;
                    }
                }

                if (skill1.Contains("increasearmor"))
                {
                    switch (skillParse[1])
                    {
                        case "common":
                            skillIncreaseArmor("common");
                            break;
                        case "rare":
                            skillIncreaseArmor("rare");
                            break;
                        case "epic":
                            skillIncreaseArmor("epic");
                            break;
                    }
                }

                if (skill1.Contains("negate"))
                {
                    switch (skillParse[1])
                    {
                        case "common":
                            skillNegateDamage("common");
                            break;
                        case "rare":
                            skillNegateDamage("rare");
                            break;
                        case "epic":
                            skillNegateDamage("epic");
                            break;
                    }
                }

                if (skill1.Contains("fastcar"))
                {
                    //Ivy here :)
                    switch (skillParse[1])
                    {
                        case "common":
                            skillFasterCar("common");
                            break;
                        case "rare":
                            skillFasterCar("rare");
                            break;
                        case "epic":
                            skillFasterCar("epic");
                            break;

                    }
                }

                if (skill1.Contains("slowenemy"))
                {
                    //Aiden here :)
                    switch (skillParse[1])
                    {
                        case "common":
                            skillSlowEnemy("common");
                            break;
                        case "rare":
                            skillSlowEnemy("rare");
                            break;
                        case "epic":
                            skillSlowEnemy("epic");
                            break;
                    }
                }
            
        }
        else if(tempString == skillText3.text)
        {
            
                string[] skillParse = skill2.Split(',');

                if (skill2.Contains("gainhp"))
                {

                    switch (skillParse[1])
                    {
                        case "common":
                            skillGainHP("common");
                            break;
                        case "rare":
                            skillGainHP("rare");
                            break;
                        case "epic":
                            skillGainHP("epic");
                            break;
                    }
                }

                if (skill2.Contains("reducedistance"))
                {
                    switch (skillParse[1])
                    {
                        case "common":
                            skillReduceDistance("common");
                            break;
                        case "rare":
                            skillReduceDistance("rare");
                            break;
                        case "epic":
                            skillReduceDistance("epic");
                            break;
                    }
                }

                if (skill2.Contains("magnetize"))
                {
                    switch (skillParse[1])
                    {
                        case "common":
                            skillMagnetizeMoney("common");
                            break;
                        case "rare":
                            skillMagnetizeMoney("rare");
                            break;
                        case "epic":
                            skillMagnetizeMoney("epic");
                            break;
                    }
                }

                if (skill2.Contains("increasearmor"))
                {
                    switch (skillParse[1])
                    {
                        case "common":
                            skillIncreaseArmor("common");
                            break;
                        case "rare":
                            skillIncreaseArmor("rare");
                            break;
                        case "epic":
                            skillIncreaseArmor("epic");
                            break;
                    }
                }

                if (skill2.Contains("negate"))
                {
                    switch (skillParse[1])
                    {
                        case "common":
                            skillNegateDamage("common");
                            break;
                        case "rare":
                            skillNegateDamage("rare");
                            break;
                        case "epic":
                            skillNegateDamage("epic");
                            break;
                    }
                }

                if (skill2.Contains("fastcar"))
                {
                    //Ivy here :)
                    switch (skillParse[1])
                    {
                        case "common":
                            skillFasterCar("common");
                            break;
                        case "rare":
                            skillFasterCar("rare");
                            break;
                        case "epic":
                            skillFasterCar("epic");
                            break;

                    }
                }

                if (skill2.Contains("slowenemy"))
                {
                    //Aiden here :)
                    switch (skillParse[1])
                    {
                        case "common":
                            skillSlowEnemy("common");
                            break;
                        case "rare":
                            skillSlowEnemy("rare");
                            break;
                        case "epic":
                            skillSlowEnemy("epic");
                            break;
                    }
                }
            
        }


    }

}
