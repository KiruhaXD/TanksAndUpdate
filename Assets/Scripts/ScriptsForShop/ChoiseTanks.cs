using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ChoiseTanks : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    private int currentTank;

    public Button playButton;

    [SerializeField] private TankModifier tankModifier;
    //[SerializeField] private List<UpdateTanks> tanksUpdate;
    //[SerializeField] private List<GameObject> playersTanks;

    private TankPurchased tankIndex;
    [SerializeField] private List<Shop> shops;

    //private Shop shopItem;

    private void Awake()
    {
        tankIndex = FindAnyObjectByType<TankPurchased>();
        //shopItem = FindAnyObjectByType<Shop>();
        SelectTank(0);
    }


    public void BaseCharacteristics() 
    {
        tankModifier.health = 100;
        tankModifier.armor = 20;
        tankModifier.power = 20;
    }

    public void SelectTank(int _index)
    {
        tankIndex.currentTankIndex = _index;

        leftButton.interactable = (_index != 0);
        rightButton.interactable = (_index != transform.childCount - 5); // -5 это наша камера, два эффекта для гусениц и канвас для перезарядки

        // если мы будем добавлять еще танки, то надо ставить цифру больше 6, там 7 или 8 и тд,
        // чтоб у нас переменная i доходила до всех дочерних элементов

        for (int i = 0; i < 9; i++) 
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }

        if (_index == 0) 
        {
            ShowPlayButton();
            BaseCharacteristics();
            UpdateUICharacteristics();
        }

        if (_index >= 1) 
        {
            HidePlayButton();
            if (FindAnyObjectByType<TankPurchased>().isTankPurchased == true) 
            {
                HidePlayButton();
                BaseCharacteristics();
                UpdateUICharacteristics();
                foreach (Shop _shop in shops) 
                {
                    _shop.select.SetActive(true);
                }
            }


            if (FindAnyObjectByType<TankPurchased>().isTankPurchased == false)
            {
                BaseCharacteristics();
                UpdateUICharacteristics();
                foreach (Shop _shop in shops)
                {
                    _shop.select.SetActive(false);
                }
            }
        }
    }
 

    public void ShowPlayButton() => playButton.enabled = true;
    public void HidePlayButton() => playButton.enabled = false;

    public void ChangeTank(int _change) 
    {
        currentTank += _change;
        SelectTank(currentTank);
    }

    public void UpdateUICharacteristics() 
    {
        tankModifier.UpdateUIHealth();
        tankModifier.UpdateUIArmor();
        tankModifier.UpdateUIPower();
    }
}
