using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int numberOfCurrencyInLevel;
    [SerializeField] private TMP_Text countCrystals;

    public void AddOne()
    {
        numberOfCurrencyInLevel++;
        UpdateUI();
    }

    public void AddItem(string tankName) => UpdateUI();

    public void UpdateUI() => countCrystals.text = numberOfCurrencyInLevel.ToString();
}
