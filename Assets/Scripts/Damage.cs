using System.Collections;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damageCount = 10;
    private void OnTriggerEnter(Collider other)
    {
        TankModifier tankModifier = other.GetComponent<TankModifier>();
        if (tankModifier != null) 
        {
            tankModifier.TakeDamage(damageCount);
        }
    }    
}
