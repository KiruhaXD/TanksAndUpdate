using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScene : MonoBehaviour
{
    [SerializeField] private CrystalsManager crystalsManager;
    [SerializeField] private ChoiseTanks choiseTanks;
    //private TankPurchased tankPurchased;

    private void Start()
    {
        // не производительно
        //tankPurchased = FindAnyObjectByType<TankPurchased>();
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next < SceneManager.sceneCountInBuildSettings)
        {
            crystalsManager.SaveToProgress();

            Progress.Instance.playerInfo.level = SceneManager.GetActiveScene().buildIndex;

#if UNITY_WEBGL
            Progress.Instance.Save();
#endif
            //tankPurchased.LoadTankPurchaseState();

            SceneManager.LoadScene(next);
        }
    }
}
