using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private int damageCount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            other.GetComponent<TankModifier>().TakeDamage(damageCount);
        }
    }    
}
