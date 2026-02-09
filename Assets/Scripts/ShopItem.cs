using UnityEngine;
using UnityEngine.EventSystems;

public class ShopItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject tooltipUi;

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltipUi.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltipUi.SetActive(false);
    }
}