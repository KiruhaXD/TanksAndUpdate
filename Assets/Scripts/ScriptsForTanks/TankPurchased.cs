using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


public class TankPurchased : MonoBehaviour
{
    public bool isTankPurchased = false;

    //public static TankPurchased instance;

    public int currentTankIndex;

    // ������� ������
    [DllImport("__Internal")] // DllImport - �� ���������� ��������� �� � �#, � � javascript � ��� ����� ��������� � ����� jssleep
    private static extern void SaveExternPurchase(string date);

    [DllImport("__Internal")]
    private static extern void LoadExternPurchase();

    private void Awake()
    {
        LoadExternPurchase();
    }

    /*private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }*/

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(isTankPurchased);
        SaveExternPurchase(jsonString);
    }

    public void LoadPurchase(string value) 
    {
        isTankPurchased = JsonUtility.FromJson<TankPurchased>(value);
    }
}
