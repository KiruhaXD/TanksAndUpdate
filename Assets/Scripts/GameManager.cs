using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject choiseTanks;

    [SerializeField] private MobileController mobileController;
    [SerializeField] private MobileControllerTower mobileTower;
    [SerializeField] private MobileControllerFire mobileFire;

    public void Play() 
    {
        startMenu.SetActive(false);
        choiseTanks.SetActive(false);
        FindAnyObjectByType<TankBehaviour>().Play();
        EnabledMove();

#if UNITY_WEBGL
        Progress.Instance.Save();
#endif
        TankAnimation tankAnimation = FindAnyObjectByType<TankAnimation>();
        tankAnimation.transform.position = Vector3.zero;
    }

    public void EnabledMove()
    {
        mobileController.joystickBG.enabled = true;
        mobileController.joystick.enabled = true;

        mobileFire.buttonFire.SetActive(true);

        mobileTower.joystickBGTower.enabled = true;
        mobileTower.joystickTower.enabled = true;
    }
}