using UnityEngine;

public class Currency : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360f;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Shop>().AddOne();
        Destroy(gameObject); 
    }
}
