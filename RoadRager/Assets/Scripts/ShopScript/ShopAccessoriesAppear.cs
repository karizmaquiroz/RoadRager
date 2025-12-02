using UnityEngine;

public class ShopAccessoriesAppear : MonoBehaviour
{
    private void Start()
    {
        int item = SaveManager.instance.currentItem;

        // Disable all children first
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        // Activate chosen accessory
        if (item >= 0 && item < transform.childCount)
        {
            transform.GetChild(item).gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Invalid accessory index: " + item);
        }
    }
}
