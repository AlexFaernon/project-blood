using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragItem : MonoBehaviour, IPointerDownHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    public GameObject Board;
    public GameObject Room;
    private bool isOnLowerLayer;
    private bool isHoverOnBoard;
    private bool isOnBoard;
    public float halfHeight;
    public float halfWidth;
    private bool isInScreen = true;
    private const int UpBorder = 100;
    private const int SideBorder = 150;

    private void Start()
    {
        Canvas.ForceUpdateCanvases();
        rectTransform = GetComponent<RectTransform>();
        halfHeight = (canvas.GetComponent<RectTransform>().rect.height - 50) / 2;
        halfWidth = (canvas.GetComponent<RectTransform>().rect.width - 50) / 2;
    }

    public void Update()
    {
        if (isHoverOnBoard && !isOnBoard)
        {
            transform.SetParent(Board.transform);
            transform.SetSiblingIndex(1);
            isOnBoard = true;
            return;
        }
        
        if (isHoverOnBoard) return;
        isOnBoard = false;
        transform.SetParent(Room.transform);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            var siblingsCount = transform.parent.childCount;
            if (isOnLowerLayer)
                transform.SetSiblingIndex(siblingsCount - 1);
            else
                transform.SetSiblingIndex(2);
            isOnLowerLayer = !isOnLowerLayer;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (isInScreen && eventData.button == PointerEventData.InputButton.Left)
        {
            var nextPos = rectTransform.anchoredPosition + eventData.delta / canvas.scaleFactor;
            if (nextPos.x < -halfWidth + SideBorder || nextPos.x > halfWidth - SideBorder ||
                nextPos.y < -halfHeight || nextPos.y > halfHeight - UpBorder)
            {
                isInScreen = false;
            }
            nextPos.x = Mathf.Clamp(nextPos.x, -halfWidth + SideBorder, halfWidth - SideBorder);
            nextPos.y = Mathf.Clamp(nextPos.y, -halfHeight, halfHeight - UpBorder);
            rectTransform.anchoredPosition = nextPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isInScreen = true;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("board"))
        {
            isHoverOnBoard = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("board"))
        {
            isHoverOnBoard = false;
        }
    }
}
