using UnityEngine;

public class GateArmor : MonoBehaviour
{
    [SerializeField] private int armorValue;

    [SerializeField] private GateAppereance gateAppereance;

    private void OnValidate()
    {
        gateAppereance.UpdateVisual(armorValue);
    }

    private void OnTriggerEnter(Collider other)
    {
        TankModifier tankModifier = other.attachedRigidbody.GetComponent<TankModifier>();
        if (tankModifier != null)
        {
            if (gateAppereance.upgrade)
            {
                tankModifier.AddArmor(armorValue);
            }

            else if (gateAppereance.downgrade)
            {
                tankModifier.RemoveArmor(armorValue);
            }
        }
    }

    /*private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }*/
}
