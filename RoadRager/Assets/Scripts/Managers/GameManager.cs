using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public GameObject MainMenuUIPanel;
    public GameObject SettingUIPanel;
    public GameObject ShopUIPanel;
    public GameObject ModifyUIPanel;
    //public Button Profile1;

    public Button SettingButton;
    public Button StoreButton;
    public Button BackButton;
    public Button ModifySelectButton;




    private void Awake()
    {
        if (SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            MainMenuUIPanel.SetActive(true);
            SettingUIPanel.SetActive(false);
            ShopUIPanel.SetActive(false);
            ModifyUIPanel.SetActive(false);
        }

    }

   


    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        if (SceneManager.GetActiveScene().name.Equals("Menu"))
        {
            MainMenuUIPanel.SetActive(true);
            SettingUIPanel.SetActive(false);
            ShopUIPanel.SetActive(false);
            ModifyUIPanel.SetActive(false);
        }

    }


    public void quit() //inside gameOver when pressed application quits
    {
        //title scene
            //or
        //SceneManager.LoadScene("Credits");

        Application.Quit();
    }



    public void startGame()
    {
        //SceneManager.LoadScene("nameofscene");
        SceneManager.LoadScene("CarAndTrash");

    }

    
    public void creditButton()
    {
        //SceneManager.LoadScene("Credits");
        //Debug.Log("In the credits scene");




    }

}
