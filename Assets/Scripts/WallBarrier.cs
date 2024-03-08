using UnityEngine;

public class WallBarrier : MonoBehaviour
{
    [SerializeField] private GameObject brickEffectPrefab;

    private void OnTriggerEnter(Collider other)
    {
        EnemyController enemyController = other.attachedRigidbody.GetComponent<EnemyController>();
        if (enemyController != null) 
        {
            Destroy(gameObject);
            Instantiate(brickEffectPrefab, transform.position, transform.rotation);
        }
    }
}
