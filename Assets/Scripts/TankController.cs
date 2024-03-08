using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    private float oldMousePositionX;
    private float eulerY;

    private float rotationSpeedX = 20f;

    // LateUpdate служит для того чтобы у нас танк не дергался 
    private void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            oldMousePositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0)) 
        {
            Vector3 newPosition = transform.position + transform.forward * Time.deltaTime * moveSpeed;
            newPosition.x = Mathf.Clamp(newPosition.x, -3f, 3f);
            transform.position = newPosition;

            float deltaX = Input.mousePosition.x - oldMousePositionX;
            oldMousePositionX = Input.mousePosition.x;

            // Time.deltaTime служит для того чтобы наш танк не поварачивался со скоростью света вправо или влево
            eulerY += deltaX * Time.deltaTime * rotationSpeedX; 
            eulerY = Mathf.Clamp(eulerY, -50f, 50f);
            transform.eulerAngles = new Vector3(0, eulerY, 0);
        }
    }
}
