using UnityEngine;
using UnityEngine.UI;

public class ChoiseTanks : MonoBehaviour
{
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;

    private int currentTank;

    private void Awake()
    {
        SelectTank(0);
    }

    public void SelectTank(int _index)
    {
        leftButton.interactable = (_index != 0);
        rightButton.interactable = (_index != transform.childCount - 5); // -5 это наша камера, два эффекта для гусениц и канвас для перезарядки

        // если мы будем добавлять еще танки, то надо ставить цифру больше 6, там 7 или 8 и тд,
        // чтоб у нас переменная i доходила до всех дочерних элементов
        for (int i = 0; i < 6; i++) 
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
        }
    }

    public void ChangeTank(int _change) 
    {
        currentTank += _change;
        SelectTank(currentTank);
    }

}
