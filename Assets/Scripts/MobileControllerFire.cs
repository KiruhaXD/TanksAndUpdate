using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MobileControllerFire : MonoBehaviour
{
    [Header("Fire")]
    public GameObject buttonFire;

    private void Start()
    {
        buttonFire.SetActive(false);
    }
}
