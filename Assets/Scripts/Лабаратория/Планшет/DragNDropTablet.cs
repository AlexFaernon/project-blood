using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDropTablet : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject pipette;
    [SerializeField] private TypeOfDraggingItem typeOfDraggingItem;
    [SerializeField] private Erythrocyte erythrocyte;
    [SerializeField] private Antigen antigen;
    private Canvas canvas;
    private RectTransform otherRectTransform;
    private Vector2 originalPosition;

    private void Awake()
    {
        otherRectTransform = pipette.GetComponent<RectTransform>();
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
        pipette.transform.GetComponent<RectTransform>().position = new Vector3(camPos.x, camPos.y, 0);
        pipette.SetActive(true);
        
        switch (typeOfDraggingItem)
        {
            case TypeOfDraggingItem.Plasma:
                EventAggregator.PlasmaPickUp.Publish();
                break;
            case TypeOfDraggingItem.BloodCells:
                EventAggregator.BloodCellsPickUp.Publish();
                break;
            case TypeOfDraggingItem.Erythrocyte:
                EventAggregator.ErythrocytePickUp.Publish(erythrocyte);
                break;
            case TypeOfDraggingItem.Antigen:
                EventAggregator.AntigenPickUp.Publish(antigen);
                break;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        switch (typeOfDraggingItem)
        {
            case TypeOfDraggingItem.Plasma:
                EventAggregator.PlasmaDrop.Publish();
                break;
            case TypeOfDraggingItem.BloodCells:
                EventAggregator.BloodCellsDrop.Publish();
                break;
            case TypeOfDraggingItem.Erythrocyte:
                EventAggregator.ErythrocyteDrop.Publish(erythrocyte);
                break;
            case TypeOfDraggingItem.Antigen:
                EventAggregator.AntigenDrop.Publish(antigen);
                break;
        }
        otherRectTransform.anchoredPosition = originalPosition;
        pipette.SetActive(false);
    }
    
    public enum TypeOfDraggingItem
    {
        Plasma,
        BloodCells,
        Erythrocyte,
        Antigen
    }
}
