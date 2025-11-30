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

    



    private int currAccessorie;

    private void Awake()
    {
        SelectAccessorie(0);
    }
    public void SelectAccessorie(int _index)
    {

        prevButton.interactable = (_index != 0);
        nextButton.interactable = (_index != transform.childCount - 1);

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


  
}
