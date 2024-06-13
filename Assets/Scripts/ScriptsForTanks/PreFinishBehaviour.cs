using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PreFinishBehaviour : MonoBehaviour
{
    public GameObject player;

    [SerializeField] private TankController controller;
    [SerializeField] private List<EnemyController> enemyController;

    private void Update()
    {
        /*float x = Mathf.MoveTowards(transform.position.x, 0, Time.deltaTime);

        float rot = Mathf.MoveTowardsAngle(transform.eulerAngles.y, 0, Time.deltaTime * 1f);
        transform.localEulerAngles = new Vector3(0, rot, 0);*/
    }

    private void OnTriggerExit(Collider other)
    {
        if (player != null) 
        {
            controller.enabled = false;

            foreach (EnemyController controller in enemyController) 
            {
                controller.ChangeDistance(EnemyState.run);
            }
        }
    }
}
