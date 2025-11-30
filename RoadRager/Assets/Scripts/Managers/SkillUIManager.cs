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

    public GameObject[] skillSlotsIcons = new GameObject[8];
    public GameObject[] skillSlotsSwoops = new GameObject[8];
    
    void Start()
    {
        for(int i = 0; i < skillSlotsIcons.Length; i++)
        {
            skillSlotsIcons[i].SetActive(false);
            skillSlotsSwoops[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplaySkillSprite(string skill, string rarity)
    {
        for(int i = 0; i< skillSlotsIcons.Length; i++)
        {
            //if (skillSlotsIcons[i].activeSelf  == false)
            if (skillSlotsSwoops[i].activeSelf  == false)
            {
                if (skill == "fast")
                {
                    if(rarity == "common")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = fastCarCI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = fastCarCISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = fastCarRI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = fastCarRISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = fastCarEI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = fastCarEISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                }
                else if (skill == "gainhp")
                {
                    if(rarity == "common")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = gainHPCI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = gainHPCISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = gainHPRI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = gainHPRISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = gainHPEI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = gainHPEISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                }
                else if (skill == "gainMoney")
                {
                    if(rarity == "common")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = gainMoneyCI;
                        skillSlotsSwoops[i].GetComponent <Image>().sprite = gainMoneyCISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = gainMoneyRI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = gainMoneyRISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = gainMoneyEI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = gainMoneyEISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                }
                else if(skill == "armor")
                {
                    if(rarity == "common")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = increaseArmorCI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = increaseArmorCISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if (rarity == "rare")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite= increaseArmorRI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = increaseArmorRISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = increaseArmorEI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = increaseArmorEISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);
                        break;

                    }
                }
                else if(skill == "magnetize")
                {
                    if(rarity == "common")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = magnetizeMoneyCI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = magnetizeMoneyCISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        skillSlotsIcons[i].GetComponent< Image>().sprite = magnetizeMoneyRI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = magnetizeMoneyRISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = magnetizeMoneyEI;
                        skillSlotsIcons[i].GetComponent<Image>().sprite = magnetizeMoneyEISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                }
                else if(skill == "negate")
                {
                    if(rarity == "common")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = negateDamageCI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = negateDamageCISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = negateDamageRI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = negateDamageRISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = negateDamageEI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = negateDamageEISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                }
                else if(skill == "reducedis")
                {
                    if(rarity == "common")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = reduceDistanceCI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = reduceDistanceCISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);
                        break;
                    }
                    else if(rarity == "rare")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = reduceDistanceRI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = reduceDistanceCISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = reduceDistanceEI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = reduceDistanceEISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                }
                else if(skill == "slow")
                {
                    if(rarity == "common")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = slowEnemyCI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = slowEnemyCISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "rare")
                    {
                        skillSlotsIcons[i].GetComponent <Image>().sprite = slowEnemyRI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = slowEnemyRISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                    else if(rarity == "epic")
                    {
                        skillSlotsIcons[i].GetComponent<Image>().sprite = slowEnemyEI;
                        skillSlotsSwoops[i].GetComponent<Image>().sprite = slowEnemyEISwoop;

                        skillSlotsIcons[i].SetActive(true);
                        skillSlotsSwoops[i].SetActive(true);

                        break;
                    }
                }
            }
           
        }
    }
}
