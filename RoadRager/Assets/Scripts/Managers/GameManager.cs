using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    public GameObject MainMenuUIPanel;
    public GameObject SettingUIPanel;
    public GameObject ShopUIPanel;
    //public Button Profile1;

    public Button SettingButton;
    public Button StoreButton;
    public Button BackButton;




    private void Awake()
    {
        MainMenuUIPanel.SetActive(true);
        SettingUIPanel.SetActive(false);
        ShopUIPanel.SetActive(false);

    }

   


    public void Menu()
    {
        SceneManager.LoadScene("Menu");
        MainMenuUIPanel.SetActive(true);
        SettingUIPanel.SetActive(false);
        ShopUIPanel.SetActive(false);

    }


    public void quit() //inside gameOver when pressed application quits
    {
        //SceneManager.LoadScene("Credits");

        Application.Quit();
    }

    /*
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");

    }
    */


    public void startGame()
    {
        //SceneManager.LoadScene("nameofscene");


    }

    
    public void creditButton()
    {
        SceneManager.LoadScene("Credits");
        //Debug.Log("In the credits scene");




    }

    public void creditBackButton()
    {
        SceneManager.LoadScene("Menu");
        //Debug.Log("Back in MainMenu scene");

    }
}
