using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDropIce : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject ice;
    private Canvas canvas;
    private RectTransform otherRectTransform;
    private Vector2 originalPosition;

    private void Awake()
    {
        otherRectTransform = ice.GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        originalPosition = otherRectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var nextPos = otherRectTransform.anchoredPosition + eventData.delta / canvas.scaleFactor;
        otherRectTransform.anchoredPosition = nextPos;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var camPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y));
        ice.transform.GetComponent<RectTransform>().position = new Vector3(camPos.x, camPos.y, 0);
        ice.SetActive(true);
        EventAggregator.ToggleHighlightingOn.Publish(ice);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EventAggregator.OnDrop.Publish(ice);
        otherRectTransform.anchoredPosition = originalPosition;
        ice.SetActive(false);
        EventAggregator.ToggleHighlightingOff.Publish();
    }
}
