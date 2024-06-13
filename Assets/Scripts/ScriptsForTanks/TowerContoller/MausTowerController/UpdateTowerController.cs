using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTowerController : MonoBehaviour
{
    [SerializeField] private Transform tower;
    [SerializeField] private float speedRotateTower = 50f;
    private bool isReloading = false; // ����������� ������

    [SerializeField] private TowerBehaviour towerBehaviour;

    //[SerializeField] private MobileControllerTower mobileControllerTower;
    public Joystick joystickTower;
    public Joystick joystickFire;

    public DeviceType type;

    private void Awake()
    {
        //mobileControllerTower = GameObject.FindGameObjectWithTag("JoystickForTower").GetComponent<MobileControllerTower>();
        if (type == DeviceType.PK) 
        {
            joystickTower.gameObject.SetActive(false);
            joystickFire.gameObject.SetActive(false);
        }
    }

    private void LateUpdate()
    {
        int screenWidthTreshold = 1024;

        int screenWidth = Screen.width;

        if (screenWidth < screenWidthTreshold)
        {
            type = DeviceType.Mobile;
            joystickTower.gameObject.SetActive(true);
            joystickFire.gameObject.SetActive(true);
        }

        else
        {
            type = DeviceType.PK;
        }
    }

    private void Update()
    {
        if (type == DeviceType.PK) 
        {
            float hor = Input.GetAxis("HorizontalTower");

            float rotateTower = hor * speedRotateTower * Time.deltaTime;

            // ��� ������ ������ � ��� ����� ����������� forward,
            // �.� � ��� ���������� �������� ����� ��� ����� 90 �������� � ����� ��������� ������� ����� � ����������� ����������� Vector3.up
            // ��� � ���� ������������ ����������� ����� ������� ������ ������ ����� � ������(��� ������)
            tower.Rotate(Vector3.up, rotateTower);

            if (Input.GetKeyDown(KeyCode.Space) && !isReloading && type == DeviceType.PK)
            {
                towerBehaviour.Fier();
            }
        }

        else if (type == DeviceType.Mobile) 
        {
            float hor = joystickTower.Horizontal;

            float rotateTower = hor * speedRotateTower * Time.deltaTime;

            // ��� ������ ������ � ��� ����� ����������� forward,
            // �.� � ��� ���������� �������� ����� ��� ����� 90 �������� � ����� ��������� ������� ����� � ����������� ����������� Vector3.up
            // ��� � ���� ������������ ����������� ����� ������� ������ ������ ����� � ������(��� ������)
            tower.Rotate(Vector3.up, rotateTower);

            if (joystickFire.Horizontal != 0 || joystickFire.Vertical != 0 && !isReloading && type == DeviceType.Mobile)
            {
                towerBehaviour.Fier();
            }
        }
    }
}
