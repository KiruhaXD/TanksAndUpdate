using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyManager : MonoBehaviour
{
    [SerializeField] private int priceForCrystals;
    [SerializeField] private string tankName;

    [SerializeField] private Button playButton; 

    public void Buy()
    {
        if (GetComponentInParent<Shop>().numberOfCurrencyInLevel >= priceForCrystals) 
        {
            GetComponentInParent<Shop>().numberOfCurrencyInLevel -= priceForCrystals;
            GetComponentInParent<Shop>().AddItem(tankName);
            FindObjectOfType<GameManager>().Play();
        }

        else
        {
            playButton.enabled = false;
            Debug.Log("Не хватает денег!");
        }
    }
}
