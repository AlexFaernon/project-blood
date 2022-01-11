using UnityEngine;
using UnityEngine.EventSystems;

public class DragGlasses : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject glass;
    private Canvas canvas;
    private RectTransform otherRectTransform;
    private Vector2 originalPosition;

    private void Awake()
    {
        otherRectTransform = glass.GetComponent<RectTransform>();
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
        glass.transform.GetComponent<RectTransform>().position = new Vector3(camPos.x, camPos.y, 0);
        glass.SetActive(true);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        EventAggregator.OnDrop.Publish(glass);
        otherRectTransform.anchoredPosition = originalPosition;
        glass.SetActive(false);
    }
}
