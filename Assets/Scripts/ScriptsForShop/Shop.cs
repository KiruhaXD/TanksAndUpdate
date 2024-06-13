using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private int priceForCrystals;
    [SerializeField] private string tankName;

    [SerializeField] private GameObject panelNotEnoughCrystals;
    [SerializeField] private GameObject panelCharacteristicsUpdateTanks;

    public Button playButton;

    public GameObject panelPriceTanks;

    [SerializeField] private UpdateTanks updateTanks;
    [SerializeField] private TankPurchased tankPurchased;

    private float hideDelay = 0.3f; // Время задержки перед скрытием панели

    public GameObject select;
    [SerializeField] private GameObject buy;

    private void Start()
    {
        tankPurchased = FindAnyObjectByType<TankPurchased>();
    }

    public void Buy()
    {
        if (GetComponentInParent<CrystalsManager>().numberOfCrystals >= priceForCrystals)
        {
            GetComponentInParent<CrystalsManager>().SpendMoney(priceForCrystals);
            GetComponentInParent<CrystalsManager>().AddItem(tankName);
            tankPurchased.isTankPurchased = true;
            //tankPurchased.SaveTankPurchaseState();
            HidePanelCanvasAfterSuccessfulPurchase();
            HidePlayButton();
            buy.SetActive(false);
            select.SetActive(true);

#if UNITY_WEBGL
            tankPurchased.Save();
#endif
        }

        else
        {
            HidePlayButton();
            ShowPanelCanvasAfterUnsuccessfulPurchase();
            StartCoroutine(HidePanelAfterDelay());
            tankPurchased.isTankPurchased = false;
            //tankPurchased.SaveTankPurchaseState();
            buy.SetActive(true);
            select.SetActive(false);
        }
    }

    public void Selected()
    {
        UpdateCharacteristics();
        ShowPlayButton();
        HidePanelCanvasAfterSuccessfulPurchase();
        select.SetActive(false);
    }

    /*public void SaveToProgress() 
    {
        TankPurchased.instance.isTankPurchased = tankPurchased;
    }*/

    public void ShowPlayButton() => playButton.enabled = true;
    public void HidePlayButton() => playButton.enabled = false;


    public void HidePanelCanvasAfterSuccessfulPurchase() 
    {
        panelPriceTanks.SetActive(false);
        panelNotEnoughCrystals.SetActive(false);
        panelCharacteristicsUpdateTanks.SetActive(false);
    }

    public void ShowPanelCanvasAfterUnsuccessfulPurchase()
    {
        panelPriceTanks.SetActive(true);
        panelNotEnoughCrystals.SetActive(true);
        panelCharacteristicsUpdateTanks.SetActive(true);
    }

    public IEnumerator HidePanelAfterDelay() 
    {
        yield return new WaitForSeconds(hideDelay);
        panelNotEnoughCrystals.SetActive(false);
    }

    

    public void UpdateCharacteristics() 
    {
        updateTanks.UpdateCharacteristicsTanksHealth();
        updateTanks.UpdateCharacteristicsTanksArmor();
        updateTanks.UpdateCharacteristicsTanksPower();
    }
}

