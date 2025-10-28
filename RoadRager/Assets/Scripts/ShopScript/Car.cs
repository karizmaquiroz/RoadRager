using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName ="New Car", menuName = "ScriptableObjects/Car")]
public class Car : ScriptableObject
{
    public int carAccessoryIndex;
    public string carAccessoryName;
    public string carAccessoryDescription;
    public string carAccessoryPrice;
    public Color carAccessoryColor;
    public Sprite carAccessoryImage;
    public Button carAccessoryUse;
    
    //public GameObject Car3DModel;




}
