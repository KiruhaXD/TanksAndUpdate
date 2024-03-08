using UnityEngine;

public class TankBehaviour : MonoBehaviour
{
    public TankController tankController;

    void Start()
    {
        tankController.enabled = false;
    }

    public void Play() 
    {
        tankController.enabled = true;
    }

    public void StartPreFinishBehaviour() 
    {
        tankController.enabled = false;
    }

    
}
