using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;


//attached to the CarAccessoriesHolder gameobject
public class ItemSelection : MonoBehaviour
{
    [Header("Navigation Buttons")]
    [SerializeField] private Button prevButton; //set to 1 in inspector 
    [SerializeField] private Button nextButton; //set to -1 in inspector

    [Header("Play/Locked Buttons")]
    [SerializeField] private Button play;
    [SerializeField] private Button locked; //when pressed it would open the shop panel

    [Header("Optional Panel")]
    [SerializeField] private GameObject shopPanel; // <- assign if you want
    [SerializeField] private GameObject modifyPanel;   // <- panel where accessories ARE allowed


    private int currAccessorie;

    private void Awake()
    {
        if (locked != null)
            locked.onClick.AddListener(OnLockedPressed);

        // Start on index 0 but respect panel visibility
        currAccessorie = 0;
        RefreshAccessories();
    }
    public void SelectAccessorie(int _index)
    {
        //new
        currAccessorie = Mathf.Clamp(_index, 0, transform.childCount - 1);
        RefreshAccessories();

    }
    public void ChangeAccessorie(int change)
    {
        currAccessorie += change;
        currAccessorie = Mathf.Clamp(currAccessorie, 0, transform.childCount - 1);
        RefreshAccessories();
    }

    public void OnModifyPanelOpened()
    {
        if (modifyPanel != null)
            modifyPanel.SetActive(true);

        RefreshAccessories();
    }

    public void OnModifyPanelClosed()
    {
        if (modifyPanel != null)
            modifyPanel.SetActive(false);

        HideAllAccessories();

        // Hide only play/locked — NOT your navigation buttons
        if (play != null) play.gameObject.SetActive(false);
        if (locked != null) locked.gameObject.SetActive(false);

        // Keep the prev/next interactable state (DO NOT override)
    }

    private void RefreshAccessories()
    {
        bool modifyOpen = (modifyPanel == null || modifyPanel.activeInHierarchy);

        // -----------------------
        // Keep navigation working ALWAYS
        // -----------------------
        if (prevButton != null)
            prevButton.interactable = (currAccessorie != 0);

        if (nextButton != null)
            nextButton.interactable = (currAccessorie != transform.childCount - 1);

        // -----------------------
        // If modify panel closed -> hide accessories + play/locked only
        // -----------------------
        if (!modifyOpen)
        {
            HideAllAccessories();
            if (play != null) play.gameObject.SetActive(false);
            if (locked != null) locked.gameObject.SetActive(false);
            return;  // DO NOT disable prev/next buttons
        }

        // -----------------------
        // Modify panel open -> show only current accessory
        // -----------------------
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == currAccessorie);
        }

        // Play vs Locked logic
        if (SaveManager.instance.carItemUnlocked[currAccessorie])
        {
            if (play != null) play.gameObject.SetActive(true);
            if (locked != null) locked.gameObject.SetActive(false);
        }
        else
        {
            if (play != null) play.gameObject.SetActive(false);
            if (locked != null) locked.gameObject.SetActive(true);
        }
    }
    private void HideAllAccessories()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void OnLockedPressed()
    {
        // Turn OFF the currently visible accessory
        if (currAccessorie >= 0 && currAccessorie < transform.childCount)
        {
            transform.GetChild(currAccessorie).gameObject.SetActive(false);
        }

        // Optionally open shop panel if assigned
        if (shopPanel != null)
        {
            shopPanel.SetActive(true);
        }

       
    }
}
