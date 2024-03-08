using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage = 20;

    private void OnTriggerEnter(Collider other)
    {
        damage = FindObjectOfType<TankModifier>().power;
        EnemyController enemyController = other.GetComponent<EnemyController>();
        if (enemyController != null) 
        {
            enemyController.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
