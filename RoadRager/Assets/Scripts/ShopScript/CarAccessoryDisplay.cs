using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class CarAccessoryDisplay : MonoBehaviour
{
    [SerializeField] private TMP_Text carAccessoryName;
    [SerializeField] private Image carAccessoryImage; //[SerializeField] private Gameobject Car3DModel;

    [SerializeField] private TMP_Text carAccessoryPrice;
    [SerializeField] private Button carAccessoryUse;



    public void DisplayAccessories(Car _carAccessories)
    {
        carAccessoryName.text = _carAccessories.carAccessoryName;

        carAccessoryImage.sprite = _carAccessories.carAccessoryImage;

        //car3DModel.gameObject = _carAccessories.car3DModel;
        carAccessoryPrice.text = _carAccessories.carAccessoryPrice;

    }
}
