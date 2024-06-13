using TMPro;
using UnityEngine;

public class CrystalsManager : MonoBehaviour
{
    public int numberOfCrystals;
    [SerializeField] private TMP_Text countCrystals;

    private void Start()
    {
        numberOfCrystals = Progress.Instance.playerInfo.�rystals;
        UpdateUI();
    }

    public void AddOne()
    {
        numberOfCrystals++;
        UpdateUI();
    }

    public void SaveToProgress() 
    {
        Progress.Instance.playerInfo.�rystals = numberOfCrystals;
    }

    public void AddItem(string tankName) => UpdateUI();

    public void SpendMoney(int price) 
    {
        numberOfCrystals -= price;
        UpdateUI();
    }

    public void UpdateUI() => countCrystals.text = numberOfCrystals.ToString();
}
