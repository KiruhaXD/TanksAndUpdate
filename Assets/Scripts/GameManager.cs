using UnityEditor.SearchService;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject choiseTanks;
    [SerializeField] private List<GameObject> priceTanks;

    public void Play() 
    {
        startMenu.SetActive(false);
        choiseTanks.SetActive(false);

        foreach (GameObject price in priceTanks)
        {
            price.SetActive(false);
        }

        FindObjectOfType<TankBehaviour>().Play();
    }
}
