using TMPro;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class SkillUIManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Sprite fastCarCI;
    public Sprite fastCarRI;
    public Sprite fastCarEI;

    public Sprite fastCarCISwoop;
    public Sprite fastCarRISwoop;
    public Sprite fastCarEISwoop;

    public Sprite gainHPCI;
    public Sprite gainHPRI;
    public Sprite gainHPEI;

    public Sprite gainHPCISwoop;
    public Sprite gainHPRISwoop;
    public Sprite gainHPEISwoop;

    public Sprite gainMoneyCI;
    public Sprite gainMoneyRI;
    public Sprite gainMoneyEI;

    public Sprite gainMoneyCISwoop;
    public Sprite gainMoneyRISwoop;
    public Sprite gainMoneyEISwoop;

    public Sprite increaseArmorCI;
    public Sprite increaseArmorRI;
    public Sprite increaseArmorEI;

    public Sprite increaseArmorCISwoop;
    public Sprite increaseArmorRISwoop;
    public Sprite increaseArmorEISwoop;

    public Sprite magnetizeMoneyCI;
    public Sprite magnetizeMoneyRI;
    public Sprite magnetizeMoneyEI;

    public Sprite magnetizeMoneyCISwoop;
    public Sprite magnetizeMoneyRISwoop;
    public Sprite magnetizeMoneyEISwoop;

    public Sprite negateDamageCI;
    public Sprite negateDamageRI;
    public Sprite negateDamageEI;

    public Sprite negateDamageCISwoop;
    public Sprite negateDamageRISwoop;
    public Sprite negateDamageEISwoop;

    public Sprite reduceDistanceCI;
    public Sprite reduceDistanceRI;
    public Sprite reduceDistanceEI;

    public Sprite reduceDistanceCISwoop;
    public Sprite reduceDistanceRISwoop;
    public Sprite reduceDistanceEISwoop;

    public Sprite slowEnemyCI;
    public Sprite slowEnemyRI;
    public Sprite slowEnemyEI;

    public Sprite slowEnemyCISwoop;
    public Sprite slowEnemyRISwoop;
    public Sprite slowEnemyEISwoop;

    public GameObject[] skillSlotsIcons = new GameObject[3];
    public GameObject[] skillSlotsSwoops = new GameObject[8];
    public TMP_Text[] stackTexts = new TMP_Text[8];

    
    
    void Start()
    {
        //for(int i = 0; i < skillSlotsIcons.Length; i++)
        for(int i = 0; i < skillSlotsSwoops.Length; i++)
        {
            skillSlotsSwoops[i].SetActive(false);
           
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplaySkillSprite(string skill, string rarity)
    {
        //for(int i = 0; i< skillSlotsIcons.Length; i++)
        for(int i = 0; i< skillSlotsSwoops.Length; i++)
        {
            //if (skillSlotsIcons[i].activeSelf  == false)
            if (skillSlotsSwoops[i].activeSelf  == false)
            {
                if (skill == "fast")
                {
                    if(rarity == "common")
                    {
                        if (CheckForAbility(fastCarCISwoop))
                        {
                            for(int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if(fastCarCISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                    
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = fastCarCI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = fastCarCISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                           

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        if (CheckForAbility(fastCarRISwoop))
                        {
                            for(int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if(fastCarRISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = fastCarRI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = fastCarRISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);

                            
                        }

                        break;

                    }
                    else if(rarity == "epic")
                    {
                        if (CheckForAbility(fastCarEISwoop))
                        {
                            for(int j=0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (fastCarEISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = fastCarEI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = fastCarEISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                          

                        break;
                    }
                }
                else if (skill == "gainhp")
                {
                    if(rarity == "common")
                    {
                        if (CheckForAbility(gainHPCISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (gainHPCISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = gainHPCI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = gainHPCISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                      

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        if (CheckForAbility(gainHPRISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (gainHPRISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = gainHPRI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = gainHPRISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                          

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        if (CheckForAbility(gainHPEISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (gainHPEISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = gainHPEI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = gainHPEISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                       

                        break;
                    }
                }
                else if (skill == "gainMoney")
                {
                    if(rarity == "common")
                    {
                        if (CheckForAbility(gainMoneyCISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (gainMoneyCISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = gainMoneyCI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = gainMoneyCISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                            

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        if (CheckForAbility(gainMoneyRISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (gainMoneyRISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = gainMoneyRI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = gainMoneyRISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                       

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        if (CheckForAbility(gainMoneyEISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (gainMoneyEISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = gainMoneyEI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = gainMoneyEISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                          

                        break;
                    }
                }
                else if(skill == "armor")
                {
                    if(rarity == "common")
                    {
                        if (CheckForAbility(increaseArmorCISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (increaseArmorCISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = increaseArmorCI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = increaseArmorCISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                            

                        break;
                    }
                    else if (rarity == "rare")
                    {
                        if (CheckForAbility(increaseArmorRISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (increaseArmorRISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {

                            //skillSlotsIcons[i].GetComponent<Image>().sprite= increaseArmorRI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = increaseArmorRISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }


                        break;
                    }
                    else if(rarity == "epic")
                    {
                        if (CheckForAbility(increaseArmorEISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (increaseArmorEISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {

                            //skillSlotsIcons[i].GetComponent<Image>().sprite = increaseArmorEI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = increaseArmorEISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                        break;

                    }
                }
                else if(skill == "magnetize")
                {
                    if(rarity == "common")
                    {
                        if (CheckForAbility(magnetizeMoneyCISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (magnetizeMoneyCISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = magnetizeMoneyCI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = magnetizeMoneyCISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                          

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        if (CheckForAbility(magnetizeMoneyRISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (magnetizeMoneyRISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent< Image>().sprite = magnetizeMoneyRI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = magnetizeMoneyRISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                            

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        if (CheckForAbility(magnetizeMoneyEISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (magnetizeMoneyEISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = magnetizeMoneyEI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = magnetizeMoneyEISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                           

                        break;
                    }
                }
                else if(skill == "negate")
                {
                    if(rarity == "common")
                    {
                        if (CheckForAbility(negateDamageCISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (negateDamageCISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = negateDamageCI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = negateDamageCISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                            

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        if (CheckForAbility(negateDamageRISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (negateDamageRISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = negateDamageRI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = negateDamageRISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                            

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        if (CheckForAbility(negateDamageEISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (negateDamageEISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = negateDamageEI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = negateDamageEISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);

                        }

                        break;
                    }
                }
                else if(skill == "reducedis")
                {
                    if(rarity == "common")
                    {
                        if (CheckForAbility(reduceDistanceCISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (reduceDistanceCISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = reduceDistanceCI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = reduceDistanceCISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                           
                        break;
                    }
                    else if(rarity == "rare")
                    {
                        if (CheckForAbility(reduceDistanceRISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (reduceDistanceRISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = reduceDistanceRI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = reduceDistanceCISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                       

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        if (CheckForAbility(reduceDistanceEISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (reduceDistanceEISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = reduceDistanceEI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = reduceDistanceEISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                            

                        break;
                    }
                }
                else if(skill == "slow")
                {
                    if(rarity == "common")
                    {
                        if (CheckForAbility(slowEnemyCISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (slowEnemyCISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = slowEnemyCI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = slowEnemyCISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                           

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        if (CheckForAbility(slowEnemyRISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (slowEnemyRISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {

                            //skillSlotsIcons[i].GetComponent <Image>().sprite = slowEnemyRI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = slowEnemyRISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);

                        }
                       

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        if (CheckForAbility(slowEnemyEISwoop))
                        {
                            for (int j = 0; j < skillSlotsSwoops.Length; j++)
                            {
                                if (slowEnemyEISwoop == skillSlotsSwoops[j].GetComponent<Image>().sprite)
                                {
                                    int num = int.Parse(stackTexts[j].text);
                                    int stack = num + 1;

                                    stackTexts[j].text = stack.ToString();
                                }
                            }
                        }
                        else
                        {
                            //skillSlotsIcons[i].GetComponent<Image>().sprite = slowEnemyEI;
                            skillSlotsSwoops[i].GetComponent<Image>().sprite = slowEnemyEISwoop;

                            //skillSlotsIcons[i].SetActive(true);
                            skillSlotsSwoops[i].SetActive(true);
                        }
                          

                        break;
                    }
                }
            }
           
        }
    }

    public void DisplaySkillIcon(string skill, string rarity, int order)
    {
        if (skill == "fastcar")
        {
            if (rarity == "common")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = fastCarCI;

            }
            else if (rarity == "rare")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = fastCarRI;

            }
            else if (rarity == "epic")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = fastCarEI;


            }
        }
        else if (skill == "gainhp")
        {
            if (rarity == "common")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = gainHPCI;
            }
            else if (rarity == "rare")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = gainHPRI;  
            }
            else if (rarity == "epic")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = gainHPEI;


            }
        }
        else if (skill == "gainmoney")
        {
            if (rarity == "common")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = gainMoneyCI;

            }
            else if (rarity == "rare")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = gainMoneyRI;

            }
            else if (rarity == "epic")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = gainMoneyEI;

            }
        }
        else if (skill == "increasearmor")
        {
            if (rarity == "common")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = increaseArmorCI;

            }
            else if (rarity == "rare")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite= increaseArmorRI;

            }
            else if (rarity == "epic")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = increaseArmorEI;


            }
        }
        else if (skill == "magnetize")
        {
            if (rarity == "common")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = magnetizeMoneyCI;

            }
            else if (rarity == "rare")
            {
                skillSlotsIcons[order].GetComponent< Image>().sprite = magnetizeMoneyRI;

            }
            else if (rarity == "epic")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = magnetizeMoneyEI;

            }
        }
        else if (skill == "negate")
        {
            if (rarity == "common")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = negateDamageCI;

            }
            else if (rarity == "rare")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = negateDamageRI;

            }
            else if (rarity == "epic")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = negateDamageEI;

            }
        }
        else if (skill == "reducedistance")
        {
            if (rarity == "common")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = reduceDistanceCI;

            }
            else if (rarity == "rare")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = reduceDistanceRI;

            }
            else if (rarity == "epic")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = reduceDistanceEI;

            }
        }
        else if (skill == "slowenemy")
        {
            if (rarity == "common")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = slowEnemyCI;

            }
            else if (rarity == "rare")
            {
                skillSlotsIcons[order].GetComponent <Image>().sprite = slowEnemyRI;

            }
            else if (rarity == "epic")
            {
                skillSlotsIcons[order].GetComponent<Image>().sprite = slowEnemyEI;

            }
        }



    }

    public bool CheckForAbility(Sprite sprite)
    {
        for(int i = 0; i < skillSlotsSwoops.Length; i++)
        {
            if(sprite == skillSlotsSwoops[i].GetComponent<Image>().sprite)
            {
                return true;
            }
        }

        return false;
    }
}
