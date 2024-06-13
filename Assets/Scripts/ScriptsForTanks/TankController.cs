using UnityEditor.Search;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    //private float oldMousePositionX;
    //private float eulerY;
    float xRotation;

    private float rotationSpeedX = 50f;

    //[SerializeField] private MobileController mobileController;
    public Joystick joystickMove;

    public DeviceType type;

    int screenWidthTreshold = 1024;

    private void Awake()
    {
        //mobileController = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
        if (type == DeviceType.PK)
        {
            joystickMove.gameObject.SetActive(false);
        }
    }

    // LateUpdate служит для того чтобы у нас танк не дергался 
    private void LateUpdate()
    {
        int screenWidth = Screen.width;

        if (screenWidth < screenWidthTreshold)
        {
            type = DeviceType.Mobile;
            joystickMove.gameObject.SetActive(true);
        }

        else
        {
            type = DeviceType.PK;
            DesktopMove();
        }
    }

    private void Update()
    {
        if (type == DeviceType.PK) 
        {
            // - решить проблему с границей возле дороги, чтоб игрок не заезжал за нее
            /*Vector3 newPosition = transform.position * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, -3f, 3f);
            transform.position = newPosition;*/

            /*xRotation = transform.position * Time.deltaTime;
            xRotation.x = Mathf.Clamp(xRotation.x, -3f, 3f);*/

            // Time.deltaTime служит для того чтобы наш танк не поварачивался со скоростью света вправо или влево
            /*eulerY += Time.deltaTime * rotationSpeedX;
            eulerY = Mathf.Clamp(eulerY, -50f, 50f);
            transform.eulerAngles = new Vector3(0, eulerY, 0);*/

            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * ver * moveSpeed * Time.deltaTime);

            transform.Rotate(Vector3.up * hor * rotationSpeedX * Time.deltaTime);
        }

        else if (type == DeviceType.Mobile) 
        {
            // - решить проблему с границей возле дороги, чтоб игрок не заезжал за нее
            /*Vector3 newPosition = transform.position * Time.deltaTime;
            newPosition.x = Mathf.Clamp(newPosition.x, -3f, 3f);
            transform.position = newPosition;

            //xRotation = transform.position * Time.deltaTime;
            //xRotation.x = Mathf.Clamp(xRotation.x, -3f, 3f);
            //transform.position = xRotation;

            // Time.deltaTime служит для того чтобы наш танк не поварачивался со скоростью света вправо или влево
            xRotation += Time.deltaTime * rotationSpeedX; 
            xRotation = Mathf.Clamp(xRotation, -50f, 50f);
            transform.eulerAngles = new Vector3(0, xRotation, 0);*/

            float hor = joystickMove.Horizontal;
            float ver = joystickMove.Vertical;

            transform.Translate(Vector3.forward * ver * moveSpeed * Time.deltaTime);

            transform.Rotate(Vector3.up * hor * rotationSpeedX * Time.deltaTime);
        }
    }

    public void DesktopMove() 
    {
        /*if (Input.GetMouseButtonDown(0))
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
        }*/

    }

}
