using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;


//update script to include the upgrades buy button and price; 



//attached to the SaveManager gameobject
public class SaveManager : MonoBehaviour
{
    public static SaveManager instance {  get; private set; }

    //what we want to save

    public int currentItem; //accessory (non consumable)
    public int money = 0; //in game currency
    public bool[] carItemUnlocked = new bool[4] { true, false, false, false }; //accessory already purchased (non consumable) item goes from non to diff color dice




    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else 
        { 
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
        Load();
    }

    public void Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData_Storage data = (PlayerData_Storage)bf.Deserialize(file);


            money = data.money;
            currentItem = data.currentItem;
            carItemUnlocked = data.carItemUnlocked;


            if (data.carItemUnlocked == null)
                carItemUnlocked = new bool[4] { true, false, false, false };



            file.Close();


        }
       
    }

    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData_Storage data = new PlayerData_Storage();


        data.money = money;
        data.currentItem = currentItem;
        data.carItemUnlocked = carItemUnlocked;


        bf.Serialize(file, data);
        file.Close();

    }


}

[Serializable]
class PlayerData_Storage
{
    public int currentItem;
    public int money;
    public bool[] carItemUnlocked;
}
