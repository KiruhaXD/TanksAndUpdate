using UnityEngine;

public class GatePower : MonoBehaviour
{
    [SerializeField] private int powerValue;

    [SerializeField] private GateAppereance gateAppereance;

    private void OnValidate()
    {
        gateAppereance.UpdateVisual(powerValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        TankModifier tankModifier = other.attachedRigidbody.GetComponent<TankModifier>();
        if (tankModifier != null)
        {
            if (gateAppereance.upgrade)
            {
                tankModifier.AddPower(powerValue);
            }

            else if (gateAppereance.downgrade)
            {
                tankModifier.RemovePower(powerValue);
            }
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }*/
}
