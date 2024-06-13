using UnityEngine;

public class Crystals : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 360f;
    [SerializeField] private GameObject crystalEffect;

    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindAnyObjectByType<CrystalsManager>().AddOne();
        Destroy(gameObject);
        Instantiate(crystalEffect, transform.position, Quaternion.identity);
    }
}
