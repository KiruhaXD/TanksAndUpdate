using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum DeviceType 
{
    PK,
    Mobile
}

public class DeviceTypeDetector : MonoBehaviour
{
    public DeviceType type;

    private void Awake()
    {
        int screenWidthTreshold = 1024;

        int screenWidth = Screen.width;

        if (screenWidth < screenWidthTreshold) 
        {
            type = DeviceType.Mobile;
            SceneManager.LoadScene("ManagementOnPhone");
        }

        else
        {
            type = DeviceType.PK;
            SceneManager.LoadScene("ManagementOnPK");
        }
    }
}
