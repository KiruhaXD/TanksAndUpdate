using System.Runtime.CompilerServices;
using UnityEngine;

// Gate (Health)
public class Gate : MonoBehaviour
{
    [SerializeField] private int healthValue;

    [SerializeField] private GateAppereance gateAppereance;

    private void OnValidate()
    {
        gateAppereance.UpdateVisual(healthValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        TankModifier tankModifier = other.attachedRigidbody.GetComponent<TankModifier>();
        if (tankModifier != null) 
        {
            if (gateAppereance.upgrade)
            {
                tankModifier.AddHealth(healthValue);
            }

            else if (gateAppereance.downgrade) 
            {
                tankModifier.RemoveHealth(healthValue); 
            }               
        }     
    }

    /*private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }*/
}
