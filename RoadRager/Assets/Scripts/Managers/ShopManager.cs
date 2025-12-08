using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using static UnityEditor.Progress;


public class ShopManager : MonoBehaviour
{
    public int[,] shopUpgradeItems = new int[5, 5];

    public TMP_Text moneyTxt;

    private void Start()
    {
        moneyTxt.text = SaveManager.instance.money + "$";

        // IDs
        shopUpgradeItems[1, 1] = 1;
        shopUpgradeItems[1, 2] = 2;
        shopUpgradeItems[1, 3] = 3;
        shopUpgradeItems[1, 4] = 4;

        // Prices
        shopUpgradeItems[2, 1] = 200;
        shopUpgradeItems[2, 2] = 250;
        shopUpgradeItems[2, 3] = 300;
        shopUpgradeItems[2, 4] = 350;

        // Quantities
        shopUpgradeItems[3, 1] = 0;
        shopUpgradeItems[3, 2] = 0;
        shopUpgradeItems[3, 3] = 0;
        shopUpgradeItems[3, 4] = 0;
    }

    //Call this from your BuyConsumables script or directly from the button
    public void Buy(int itemId)
    {
        int price = shopUpgradeItems[2, itemId];

        if (SaveManager.instance.money >= price)
        {
            // Take money
            SaveManager.instance.money -= price;

            // Increase quantity
            shopUpgradeItems[3, itemId]++;

            // Update money UI
            moneyTxt.text = SaveManager.instance.money + "$";

            // Optionally save immediately
            SaveManager.instance.Save();
        }
        else
        {
            Debug.Log("Not enough money to buy item " + itemId);
        }
    }
}
