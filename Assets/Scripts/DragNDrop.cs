using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        var nextPos = rectTransform.anchoredPosition + eventData.delta / canvas.scaleFactor;
        rectTransform.anchoredPosition = nextPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EventAggregator.OnDrop.Publish(gameObject);
    }
}
