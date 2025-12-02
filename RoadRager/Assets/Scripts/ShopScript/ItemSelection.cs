using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


//attached to the CarAccessoriesHolder gameobject
public class ItemSelection : MonoBehaviour
{
    [Header("Navigation Buttons")]
    [SerializeField] private Button prevButton;
    [SerializeField] private Button nextButton;

    [Header("Play/Locked Buttons")]
    [SerializeField] private Button play;
    [SerializeField] private Button locked;

    [Header("Optional Shop Panel")]
    [SerializeField] private GameObject shopPanel;

    [Header("Modify Panel (Accessories only show when this is open)")]
    [SerializeField] private GameObject modifyPanel;   // NEW

    private int currAccessorie;

    private void Awake()
    {
        locked.onClick.AddListener(OnLockedPressed);
        SelectAccessorie(0);
    }

    public void SelectAccessorie(int _index)
    {
        bool modifyOpen = (modifyPanel != null && modifyPanel.activeInHierarchy);

        // NEW: If modify panel is NOT open, hide everything immediately
        if (!modifyOpen)
        {
            HideAllAccessories();
            play.gameObject.SetActive(false);
            locked.gameObject.SetActive(false);
            return;
        }

        // Your original logic -------------------------------------------------

        prevButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount - 1);

        currAccessorie = _index;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }

        if (SaveManager.instance.carItemUnlocked[_index])
        {
            play.gameObject.SetActive(true);
            locked.gameObject.SetActive(false);
        }
        else
        {
            play.gameObject.SetActive(false);
            locked.gameObject.SetActive(true);
        }
    }

    public void ChangeAccessorie(int _change)
    {
        currAccessorie += _change;
        SelectAccessorie(currAccessorie);
    }

    private void OnLockedPressed()
    {
        // Turn OFF the currently visible accessory
        if (currAccessorie >= 0 && currAccessorie < transform.childCount)
        {
            transform.GetChild(currAccessorie).gameObject.SetActive(false);
        }

        if (shopPanel != null)
        {
            shopPanel.SetActive(true);
        }
    }

    //NEW: helper to hide everything when modify panel is closed
    private void HideAllAccessories()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
