//using System;
//using System.Collections;
//using System.Collections.Generic;
using TMPro;
//using TMPro.EditorUtilities;
//using Unity.Burst.Intrinsics;
//using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Unity.VisualScripting;

public class Skills : MonoBehaviour //find a way to cap skills at 8?
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

    public Truck truck;
    float initTrashSpd;
    float initCarSpd;

    public SkillUIManager skillManager = new SkillUIManager();

    //public SkillManager skillRef = new SkillManager();

    public GameObject pauseIcon;
    public GameObject pauseTxt;

    void Start()
    {
        skillArray = new int[3, 2];
        stringSkillArray = new string[3, 2];

        skill0 = null;
        skill1 = null;
        skill2 = null;

        initTrashSpd = truck.trashSpd;
        initCarSpd = truck.carSpd;

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
        switch (rarity)
        {
            case "common":
                playerAttr.setMagentizeMultiplier(1.0f);
                break;
            case "rare":
                playerAttr.setMagentizeMultiplier(1.5f);
                break;
            case "epic":
                playerAttr.setMagentizeMultiplier(3.0f);
                break;
        }
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

    bool skillNegateDamage(string rarity) //doens't do anything rn
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
        switch (rarity)
        {
            case "common":
                playerAttr.spd = playerAttr.spd + playerAttr.spd * 0.05f;
                break;
            case "rare":
                playerAttr.spd = playerAttr.spd + playerAttr.spd * 0.1f;
                break;
            case "epic":
                playerAttr.spd = playerAttr.spd + playerAttr.spd * 0.15f;
                break;
        }
    }

    void skillSlowEnemy(string rarity)
    {
        Debug.Log("running skill");  // if you have a rarer version of a skill, can you end up getting a common one too?
        switch (rarity)
        {
            case "common":
                truck.carSpd = initCarSpd - initCarSpd * 0.2f;
                truck.trashSpd = initTrashSpd - initTrashSpd * 0.2f;
                break;
            case "rare":
                truck.carSpd = initCarSpd - initCarSpd * 0.5f;
                truck.trashSpd = initTrashSpd - initTrashSpd * 0.5f;
                break;
            case "epic":
                truck.carSpd = initCarSpd - initCarSpd * 0.75f;
                truck.trashSpd = initTrashSpd - initTrashSpd * 0.75f;
                break;
        }
    }

    public void PauseUnpause() //for pause button
    {
        if (!PlayerMovement.paused)
        {
            pauseGame.Invoke();
            pauseTxt.SetActive(true);
        }
        else
        {
            resumeGame.Invoke();
            pauseTxt.SetActive(false);
        }
    }

    public void SkillGenerator()
    {
        pauseGame.Invoke();
        pauseIcon.GetComponent<Image>().color = new Color (1f, 1f, 1f, 0.5f);
        pauseIcon.GetComponent<Button>().interactable = false;
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
                case 0:
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

    /*
    public bool CheckForDuplicateSkillRarity(string[,] skillArray)
    {
        string firstSkill = null;
        string secondSkill = null;
        string thirdSkill = null;

        string rarityone = null;
        string raritytwo = null;
        string raritythree = null;


        for (int i = 0; i < 3; i++)
        {
            if(i == 0)
            {
                firstSkill =skillArray[i, 0];
                rarityone = skillArray[i, 1];
            }
            else if(i == 1)
            {
                secondSkill=skillArray[i, 0];   
                raritytwo = skillArray[i, 1];
            }
            else if(i == 2)
            {
                thirdSkill=skillArray[i, 0];
                raritytwo=skillArray[i, 1];
            }
        }

      
        if(skillRef.currentPlayerSkills.Count != 0)
        {
            foreach(SkillClass skill in skillRef.currentPlayerSkills)
            {
                if(firstSkill == skill.name)
                {
                    //if it's less than, don't display.
                    if(rarityone == "common" && raritytwo == "rare")
                    {
                        return true;
                    }
                    //if it's greater than, display.
                    else if(rarityone == "rare" && raritytwo == "common")
                    {
                        return false;
                    }
                    else if(rarityone == "epic")
                    {
                        return false;
                    }

                }
            }
        }
    }
    */   
    
    string DetermineSkill(string skill, int order)  //some show up blank sometimes
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
                    skillManager.DisplaySkillIcon("gainmoney", "common", order);
                    break;
                case "rare":
                    fullSkill = "Gain 15% more money from coins";
                    skillManager.DisplaySkillIcon("gainmoney", "rare", order);
                    break;
                case "epic":
                    fullSkill = "Gain 30% more money from coins, but your health pool decreases by one";
                    skillManager.DisplaySkillIcon("gainmoney", "epic", order);
                    break;

            }
        }

        if (skill.Contains("gainhp"))
        {
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "Gain one heart to your health pool";
                    skillManager.DisplaySkillIcon("gainhp", "common", order);
                    break;
                case "rare":
                    fullSkill = "Gain two hearts to your health pool";
                    skillManager.DisplaySkillIcon("gainhp", "rare", order);
                    break;
                case "epic":
                    fullSkill = "Gain three hearts to your health pool, but your distance to travel is increased by 50%";
                    skillManager.DisplaySkillIcon("gainhp", "epic", order);
                    break;
            }
        }

        if (skill.Contains("reducedistance"))
        {
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "Reduce distance needed by 10%";
                    skillManager.DisplaySkillIcon("reducedistance", "common", order);
                    break;
                case "rare":
                    fullSkill = "Reduce distance needed by 15%";
                    skillManager.DisplaySkillIcon("reducedistance", "rare", order);
                    break;
                case "epic":
                    fullSkill = "Reduce distance needed by 30%, but you collect 15% less money";
                    skillManager.DisplaySkillIcon("reducedistance", "epic", order);
                    break;
            }
        }

        if (skill.Contains("magnetize"))
        {
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "Money is magnetized by 5%";
                    skillManager.DisplaySkillIcon("magnetize", "common", order);
                    break;
                case "rare":
                    fullSkill = "Money is magnetized by 8%";
                    skillManager.DisplaySkillIcon("magnetize", "rare", order);
                    break;
                case "epic":
                    fullSkill = "Money is magnetized by 10%";
                    skillManager.DisplaySkillIcon("magnetize", "epic", order);
                    break;
            }
        }

        if (skill.Contains("increasearmor"))
        {
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "You take 50% less damage.";
                    skillManager.DisplaySkillIcon("increasearmor", "common", order);
                    break;
                case "rare":
                    fullSkill = "You take 75% less damage";
                    skillManager.DisplaySkillIcon("increasearmor", "rare", order);
                    break;
                case "epic":
                    fullSkill = "You take 100% less damage, but your travel distance is increased by 50%";
                    skillManager.DisplaySkillIcon("increasearmor", "epic", order);
                    break;
            }
        }

        if (skill.Contains("negate"))
        {
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "You have a 10% chance to not take damage.";
                    skillManager.DisplaySkillIcon("negate", "common", order);
                    break;
                case "rare":
                    fullSkill = "You have a 15% chance to not take damage.";
                    skillManager.DisplaySkillIcon("negate", "rare", order);
                    break;
                case "epic":
                    fullSkill = "You have a 20% chance to not take damage.";
                    skillManager.DisplaySkillIcon("negate", "epic", order);
                    break;
            }
        }

        if (skill.Contains("fastcar"))
        {
            //Ivy here :)
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "Make your car 5% faster";
                    skillManager.DisplaySkillIcon("fastcar", "common", order);
                    break;
                case "rare":
                    fullSkill = "Make your car 10% faster";
                    skillManager.DisplaySkillIcon("fastcar", "rare", order);
                    break;
                case "epic":
                    fullSkill = "Make your car 15% faster";
                    skillManager.DisplaySkillIcon("fastcar", "epic", order);
                    break;

            }
        }

        if (skill.Contains("slowenemy"))
        {
            //Aiden here :)
            switch (skillParse[1])
            {
                case "common":
                    fullSkill = "Trash and enemy cars go 20% slower";
                    skillManager.DisplaySkillIcon("slowenemy", "common", order);
                    break;
                case "rare":
                    fullSkill = "Trash and enemy cars go 50% slower";
                    skillManager.DisplaySkillIcon("slowenemy", "rare", order);
                    break;
                case "epic":
                    fullSkill = "Trash and enemy cars go 75% slower";
                    skillManager.DisplaySkillIcon("slowenemy", "epic", order);
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


        skillText1.text = DetermineSkill(skill0, 0);
        skillText2.text = DetermineSkill(skill1, 1);
        skillText3.text = DetermineSkill(skill2, 2);

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
        pauseIcon.GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
        pauseIcon.GetComponent<Button>().interactable = true;

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
                        skillManager.DisplaySkillSprite("gainhp", "common");
                        SkillClass gainHPCommon = new SkillClass("gainhp", "common");
                        break;
                    case "rare":
                        skillGainHP("rare");
                        skillManager.DisplaySkillSprite("gainhp", "rare");
                        SkillClass gainHPRare = new SkillClass("gainhp", "rare");
                        break;
                    case "epic":
                        skillGainHP("epic");
                        skillManager.DisplaySkillSprite("gainhp", "epic");
                        SkillClass gainHPEpic = new SkillClass("gainhp", "epic");
                        break;
                }
            }

            if (skill0.Contains("reducedistance"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillReduceDistance("common");
                        skillManager.DisplaySkillSprite("reducedis", "common");
                        SkillClass reduceDisCommon = new SkillClass("reduceddis", "common");
                        break;
                    case "rare":
                        skillReduceDistance("rare");
                        skillManager.DisplaySkillSprite("reducedis", "rare");
                        SkillClass reduceDisRare = new SkillClass("reduceddis", "rare");
                        break;
                    case "epic":
                        skillReduceDistance("epic");
                        skillManager.DisplaySkillSprite("reducedis", "epic");
                        SkillClass reduceDisEpic = new SkillClass("reduceddis", "epic");
                        break;
                }
            }

            if (skill0.Contains("magnetize"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillMagnetizeMoney("common");
                        skillManager.DisplaySkillSprite("magnetize", "common");
                        SkillClass magnetizeMoneyCommon = new SkillClass("magnetize", "common");
                        break;
                    case "rare":
                        skillMagnetizeMoney("rare");
                        skillManager.DisplaySkillSprite("magnetize", "rare");
                        SkillClass magnetizeMoneyRare = new SkillClass("magnetize", "rare");
                        break;
                    case "epic":
                        skillMagnetizeMoney("epic");
                        skillManager.DisplaySkillSprite("magnetize", "epic");
                        SkillClass magnetizeMoneyEpic = new SkillClass("magnetize", "epic");
                        break;
                }
            }

            if (skill0.Contains("increasearmor"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillIncreaseArmor("common");
                        skillManager.DisplaySkillSprite("armor", "common");
                        SkillClass armorCommon = new SkillClass("armor", "common");
                        break;
                    case "rare":
                        skillIncreaseArmor("rare");
                        skillManager.DisplaySkillSprite("armor", "rare");
                        SkillClass armorRare = new SkillClass("armor", "rare");
                        break;
                    case "epic":
                        skillIncreaseArmor("epic");
                        skillManager.DisplaySkillSprite("armor", "epic");
                        SkillClass armorEpic = new SkillClass("armor", "epic");
                        break;
                }
            }

            if (skill0.Contains("negate"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillNegateDamage("common");
                        skillManager.DisplaySkillSprite("negate", "common");
                        SkillClass negateCommon = new SkillClass("negate", "common");
                        break;
                    case "rare":
                        skillNegateDamage("rare");
                        skillManager.DisplaySkillSprite("negate", "rare");
                        SkillClass negateRare = new SkillClass("negate", "rare");
                        break;
                    case "epic":
                        skillNegateDamage("epic");
                        skillManager.DisplaySkillSprite("negate", "epic");
                        SkillClass negateEpic = new SkillClass("negate", "epic");
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
                        skillManager.DisplaySkillSprite("fast", "common");
                        SkillClass fastCommon = new SkillClass("fast", "common");
                        break;
                    case "rare":
                        skillFasterCar("rare");
                        skillManager.DisplaySkillSprite("fast", "rare");
                        SkillClass fastRare = new SkillClass("fast", "rare");
                        break;
                    case "epic":
                        skillFasterCar("epic");
                        skillManager.DisplaySkillSprite("fast", "epic");
                        SkillClass fastEpic = new SkillClass("fast", "epic");
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
                        skillManager.DisplaySkillSprite("slow", "common");
                        SkillClass slowCommon = new SkillClass("slow", "common");
                        break;
                    case "rare":
                        skillSlowEnemy("rare");
                        skillManager.DisplaySkillSprite("slow", "rare");
                        SkillClass slowRare = new SkillClass("slow", "rare");
                        break;
                    case "epic":
                        skillSlowEnemy("epic");
                        skillManager.DisplaySkillSprite("slow", "epic");
                        SkillClass slowEpic = new SkillClass("slow", "epic");
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
                        skillManager.DisplaySkillSprite("gainhp", "common");
                        SkillClass gainHPCommon = new SkillClass("gainhp", "common");
                        break;
                    case "rare":
                        skillGainHP("rare");
                        skillManager.DisplaySkillSprite("gainhp", "rare");
                        SkillClass gainHPRare = new SkillClass("gainhp", "rare");
                        break;
                    case "epic":
                        skillGainHP("epic");
                        skillManager.DisplaySkillSprite("gainhp", "epic");
                        SkillClass gainHPEpic = new SkillClass("gainhp", "epic");
                        break;
                }
            }

            if (skill1.Contains("reducedistance"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillReduceDistance("common");
                        skillManager.DisplaySkillSprite("reducedis", "common");
                        SkillClass reduceDisCommon = new SkillClass("reduceddis", "common");
                        break;
                    case "rare":
                        skillReduceDistance("rare");
                        skillManager.DisplaySkillSprite("reducedis", "rare");
                        SkillClass reduceDisRare = new SkillClass("reduceddis", "rare");
                        break;
                    case "epic":
                        skillReduceDistance("epic");
                        skillManager.DisplaySkillSprite("reducedis", "epic");
                        SkillClass reduceDisEpic = new SkillClass("reduceddis", "epic");
                        break;
                }
            }

            if (skill1.Contains("magnetize"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillMagnetizeMoney("common");
                        skillManager.DisplaySkillSprite("magnetize", "common");
                        SkillClass magnetizeMoneyCommon = new SkillClass("magnetize", "common");
                        break;
                    case "rare":
                        skillMagnetizeMoney("rare");
                        skillManager.DisplaySkillSprite("magnetize", "rare");
                        SkillClass magnetizeMoneyRare = new SkillClass("magnetize", "rare");
                        break;
                    case "epic":
                        skillMagnetizeMoney("epic");
                        skillManager.DisplaySkillSprite("magnetize", "epic");
                        SkillClass magnetizeMoneyEpic = new SkillClass("magnetize", "epic");
                        break;
                }
            }

            if (skill1.Contains("increasearmor"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillIncreaseArmor("common");
                        skillManager.DisplaySkillSprite("armor", "common");
                        SkillClass armorCommon = new SkillClass("armor", "common");
                        break;
                    case "rare":
                        skillIncreaseArmor("rare");
                        skillManager.DisplaySkillSprite("armor", "rare");
                        SkillClass armorRare = new SkillClass("armor", "rare");
                        break;
                    case "epic":
                        skillIncreaseArmor("epic");
                        skillManager.DisplaySkillSprite("armor", "epic");
                        SkillClass armorEpic = new SkillClass("armor", "epic");
                        break;
                }
            }

            if (skill1.Contains("negate"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillNegateDamage("common");
                        skillManager.DisplaySkillSprite("negate", "common");
                        SkillClass negateCommon = new SkillClass("negate", "common");
                        break;
                    case "rare":
                        skillNegateDamage("rare");
                        skillManager.DisplaySkillSprite("negate", "rare");
                        SkillClass negateRare = new SkillClass("negate", "rare");
                        break;
                    case "epic":
                        skillNegateDamage("epic");
                        skillManager.DisplaySkillSprite("negate", "epic");
                        SkillClass negateEpic = new SkillClass("negate", "epic");
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
                        skillManager.DisplaySkillSprite("fast", "common");
                        SkillClass fastCommon = new SkillClass("fast", "common");
                        break;
                    case "rare":
                        skillFasterCar("rare");
                        skillManager.DisplaySkillSprite("fast", "rare");
                        SkillClass fastRare = new SkillClass("fast", "rare");
                        break;
                    case "epic":
                        skillFasterCar("epic");
                        skillManager.DisplaySkillSprite("fast", "epic");
                        SkillClass fastEpic = new SkillClass("fast", "epic");
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
                        skillManager.DisplaySkillSprite("slow", "common");
                        SkillClass slowCommon = new SkillClass("slow", "common");
                        break;
                    case "rare":
                        skillSlowEnemy("rare");
                        skillManager.DisplaySkillSprite("slow", "rare");
                        SkillClass slowRare = new SkillClass("slow", "rare");
                        break;
                    case "epic":
                        skillSlowEnemy("epic");
                        skillManager.DisplaySkillSprite("slow", "epic");
                        SkillClass slowEpic = new SkillClass("slow", "epic");
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
                        skillManager.DisplaySkillSprite("gainhp", "common");
                        SkillClass gainHPCommon = new SkillClass("gainhp", "common");
                        break;
                    case "rare":
                        skillGainHP("rare");
                        skillManager.DisplaySkillSprite("gainhp", "rare");
                        SkillClass gainHPRare = new SkillClass("gainhp", "rare");
                        break;
                    case "epic":
                        skillGainHP("epic");
                        skillManager.DisplaySkillSprite("gainhp", "epic");
                        SkillClass gainHPEpic = new SkillClass("gainhp", "epic");
                        break;
                }
            }

            if (skill2.Contains("reducedistance"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillReduceDistance("common");
                        skillManager.DisplaySkillSprite("reducedis", "common");
                        SkillClass reduceDisCommon = new SkillClass("reduceddis", "common");
                        break;
                    case "rare":
                        skillReduceDistance("rare");
                        skillManager.DisplaySkillSprite("reducedis", "rare");
                        SkillClass reduceDisRare = new SkillClass("reduceddis", "rare");
                        break;
                    case "epic":
                        skillReduceDistance("epic");
                        skillManager.DisplaySkillSprite("reducedis", "epic");
                        SkillClass reduceDisEpic = new SkillClass("reduceddis", "epic");
                        break;
                }
            }

            if (skill2.Contains("magnetize"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillMagnetizeMoney("common");
                        skillManager.DisplaySkillSprite("magnetize", "common");
                        SkillClass magnetizeMoneyCommon = new SkillClass("magnetize", "common");
                        break;
                    case "rare":
                        skillMagnetizeMoney("rare");
                        skillManager.DisplaySkillSprite("magnetize", "rare");
                        SkillClass magnetizeMoneyRare = new SkillClass("magnetize", "rare");
                        break;
                    case "epic":
                        skillMagnetizeMoney("epic");
                        skillManager.DisplaySkillSprite("magnetize", "epic");
                        SkillClass magnetizeMoneyEpic = new SkillClass("magnetize", "epic");
                        break;
                }
            }

            if (skill2.Contains("increasearmor"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillIncreaseArmor("common");
                        skillManager.DisplaySkillSprite("armor", "common");
                        SkillClass armorCommon = new SkillClass("armor", "common");
                        break;
                    case "rare":
                        skillIncreaseArmor("rare");
                        skillManager.DisplaySkillSprite("armor", "rare");
                        SkillClass armorRare = new SkillClass("armor", "rare");
                        break;
                    case "epic":
                        skillIncreaseArmor("epic");
                        skillManager.DisplaySkillSprite("armor", "epic");
                        SkillClass armorEpic = new SkillClass("armor", "epic");
                        break;
                }
            }

            if (skill2.Contains("negate"))
            {
                switch (skillParse[1])
                {
                    case "common":
                        skillNegateDamage("common");
                        skillManager.DisplaySkillSprite("negate", "common");
                        SkillClass negateCommon = new SkillClass("negate", "common");
                        break;
                    case "rare":
                        skillNegateDamage("rare");
                        skillManager.DisplaySkillSprite("negate", "rare");
                        SkillClass negateRare = new SkillClass("negate", "rare");
                        break;
                    case "epic":
                        skillNegateDamage("epic");
                        skillManager.DisplaySkillSprite("negate", "epic");
                        SkillClass negateEpic = new SkillClass("negate", "epic");
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
                        skillManager.DisplaySkillSprite("fast", "common");
                        SkillClass fastCommon = new SkillClass("fast", "common");
                        break;
                    case "rare":
                        skillFasterCar("rare");
                        skillManager.DisplaySkillSprite("fast", "rare");
                        SkillClass fastRare = new SkillClass("fast", "rare");
                        break;
                    case "epic":
                        skillFasterCar("epic");
                        skillManager.DisplaySkillSprite("fast", "epic");
                        SkillClass fastEpic = new SkillClass("fast", "epic");
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
                        skillManager.DisplaySkillSprite("slow", "common");
                        SkillClass slowCommon = new SkillClass("slow", "common");
                        break;
                    case "rare":
                        skillSlowEnemy("rare");
                        skillManager.DisplaySkillSprite("slow", "rare");
                        SkillClass slowRare = new SkillClass("slow", "rare");
                        break;
                    case "epic":
                        skillSlowEnemy("epic");
                        skillManager.DisplaySkillSprite("slow", "epic");
                        SkillClass slowEpic = new SkillClass("slow", "epic");
                        break;
                }
            }

        }


    }

}
