using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName ="New Car", menuName = "ScriptableObjects/Car")]
public class Car : ScriptableObject
{
    [Header("Description")]
    
    public string carAccessoryName;
    public string carAccessoryDescription;

    [Header("Details")]
    public string carAccessoryPrice;
    public Sprite carAccessoryImage; //public GameObject Car3DModel;

    [Header("SelectionToUse")]
    public Button carAccessoryUse;
    
    




}
