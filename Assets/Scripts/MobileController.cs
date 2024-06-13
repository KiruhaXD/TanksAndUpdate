using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class MobileController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    [Header("Move")]
    public Image joystickBG;
    public Image joystick;

    private Vector2 inputVector;

    private void Start()
    {
        joystickBG.enabled = false;
        joystick.enabled = false;
    }

    public virtual void OnPointerDown(PointerEventData ped) { OnDrag(ped); }
    public virtual void OnPointerUp(PointerEventData ped) 
    {
        inputVector = Vector2.zero;
        joystick.rectTransform.anchoredPosition = inputVector;
    }
    public virtual void OnDrag(PointerEventData ped) 
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystickBG.rectTransform, ped.position, ped.pressEventCamera, out pos)) 
        {
            pos.x = (pos.x / joystickBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joystickBG.rectTransform.sizeDelta.x);

            inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1); // установка точных координат из касания
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            joystick.rectTransform.anchoredPosition = new Vector2(inputVector.x * (joystickBG.rectTransform.sizeDelta.x / 2), inputVector.y * (joystickBG.rectTransform.sizeDelta.y / 2));
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
