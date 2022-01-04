using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Canvas canvas;
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
       EventAggregator.ToggleHighlightingOn.Publish(gameObject);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        var nextPos = rectTransform.anchoredPosition + eventData.delta / canvas.scaleFactor;
        rectTransform.anchoredPosition = nextPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EventAggregator.ToggleHighlightingOff.Publish();
        EventAggregator.OnDrop.Publish(gameObject);
    }
}
