using UnityEngine;

public class PreFinishTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        TankBehaviour tankBehaviour = other.attachedRigidbody.GetComponent<TankBehaviour>();
        if (tankBehaviour != null) 
        {
            tankBehaviour.StartPreFinishBehaviour();
        }
    }
}
