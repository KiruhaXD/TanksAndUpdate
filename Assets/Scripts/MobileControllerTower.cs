using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MobileControllerTower : MonoBehaviour
{
    [Header("Move Tower")]
    public Image joystickBGTower;
    public Image joystickTower;

    private Vector2 inputVector;

    private void Start()
    {
        joystickBGTower.enabled = false;
        joystickTower.enabled = false;
    }

    public virtual void OnPointerDown(PointerEventData ped) { OnDrag(ped); }
    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        joystickTower.rectTransform.anchoredPosition = inputVector;
    }
    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBGTower.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joystickBGTower.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBGTower.rectTransform.sizeDelta.x);

            inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1); // установка точных координат из касания
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystickTower.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBGTower.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBGTower.rectTransform.sizeDelta.y / 2));
        }
    }

    public float Horizontal()
    {
        if (inputVector.x != 0) return inputVector.x;
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.y != 0) return inputVector.y;
        else return Input.GetAxis("Vertical");
    }
}
