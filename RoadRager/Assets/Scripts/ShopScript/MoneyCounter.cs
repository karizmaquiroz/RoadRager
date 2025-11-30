using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using System.Runtime.CompilerServices;


//attached to the text money counter game object

public class MoneyCounter : MonoBehaviour
{
    private TMP_Text moneyText;

    private void Awake()
    {
        moneyText = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        moneyText.text = SaveManager.instance.money + "$";
    }
}
