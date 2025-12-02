using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyConsumables : MonoBehaviour
{
    
    public int ItemID;
    public TMP_Text PriceText;
    public TMP_Text QuantityText;

    private ShopManager shopManager;

    private void Start()
    {
        shopManager = Object.FindFirstObjectByType<ShopManager>();
        RefreshUI();
    }

    // Called by the button's OnClick
    public void OnBuyPressed()
    {
        if (shopManager == null)
        {
            Debug.LogError("ShopManager not found in scene.");
            return;
        }

        shopManager.Buy(ItemID);
        RefreshUI(); // update our own quantity & price display
    }

    private void RefreshUI()
    {
        if (shopManager == null) return;

        int price = shopManager.shopUpgradeItems[2, ItemID];
        int qty = shopManager.shopUpgradeItems[3, ItemID];

        if (PriceText != null)
            PriceText.text = price.ToString();

        if (QuantityText != null)
            QuantityText.text = qty.ToString();
    }
}
