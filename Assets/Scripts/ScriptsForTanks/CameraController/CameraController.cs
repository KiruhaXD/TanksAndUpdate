using UnityEngine;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        target.position = transform.position;
    }
}
