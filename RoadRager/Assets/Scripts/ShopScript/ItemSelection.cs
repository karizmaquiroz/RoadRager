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

    [Header("Optional Shop Panel")]
    [SerializeField] private GameObject shopPanel; // <- assign if you want
    [SerializeField] private GameObject modifyPanel; // <- modify panel

    private int currAccessorie;

    private void Awake()
    {
        // Attach the locked button event
        locked.onClick.AddListener(OnLockedPressed);

        SelectAccessorie(0);
    }
    public void SelectAccessorie(int _index)
    {

        //new code below
        bool modifyOpen = (modifyPanel != null && modifyPanel.activeInHierarchy);
        if (!modifyOpen)
        {
            HideAllAccessories();
            play.gameObject.SetActive(false);
            locked.gameObject.SetActive(false);
            return;
        }


        //origional code below
        prevButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount - 1);


        currAccessorie = _index;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);

        }

        // Show Play button or Locked button
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

        // Optionally open shop panel if assigned
        if (shopPanel != null)
        {
            shopPanel.SetActive(true);
        }


    }

    //new
    private void HideAllAccessories()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
