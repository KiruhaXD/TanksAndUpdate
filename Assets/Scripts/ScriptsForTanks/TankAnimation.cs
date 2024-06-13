using UnityEngine;

public class TankAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 finalPosition;
    private Vector3 initialPosition; // позиция вне поле нашего зрения, т.е за пределами экрана

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        //transform.position = Vector3.Lerp(finalPosition, transform.position, 0.1f);
        
        // включить
        //transform.RotateAround(gameObject.transform.position, Vector3.up, 20 * Time.deltaTime);
    }

    // с помощью него происходит перемещение на позицию вне экрана
    private void OnDisable()
    {
        transform.position = initialPosition;
    }
}
