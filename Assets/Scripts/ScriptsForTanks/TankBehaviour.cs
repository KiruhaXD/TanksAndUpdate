using System.Collections.Generic;
using UnityEngine;

public class TankBehaviour : MonoBehaviour
{
    [SerializeField] private TankController tankController;
    [SerializeField] private List<TowerController> towerController;
    [SerializeField] private List<OtherTowerController> otherTowerController;
    [SerializeField] private UpdateTowerController updateTowerController;

    void Start()
    {
        tankController.enabled = false;
        DisabledMoveTower();
        updateTowerController.enabled = false;
    }

    public void Play() 
    {
        tankController.enabled = true;
        EnabledMoveTower();
        updateTowerController.enabled = true;
    }

    public void EnabledMoveTower() 
    {
        foreach (TowerController tower in towerController)
        {
            tower.enabled = true;
        }

        foreach (OtherTowerController other in otherTowerController)
        {
            other.enabled = true;
        }
    }

    public void DisabledMoveTower() 
    {
        foreach (TowerController tower in towerController)
        {
            tower.enabled = false;
        }

        foreach (OtherTowerController other in otherTowerController)
        {
            other.enabled = false;
        }
    }
    
}
