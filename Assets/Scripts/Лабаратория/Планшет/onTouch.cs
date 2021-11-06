using UnityEngine;
using UnityEngine.EventSystems;

public class onTouch : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private GameObject drop;
    public void OnPointerDown(PointerEventData eventData)
    {
        drop.transform.GetComponent<RectTransform>().position =
            transform.GetComponent<RectTransform>().position;
    }
}
