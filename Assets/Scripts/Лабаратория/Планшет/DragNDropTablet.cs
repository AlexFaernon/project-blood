using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;

public class DragNDropTablet : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    [SerializeField] private GameObject drop;
    private Canvas canvas;
    private RectTransform otherRectTransform;
    private Vector2 originalPosition;

    private void Awake()
    {
        otherRectTransform = drop.GetComponent<RectTransform>();
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
        drop.transform.GetComponent<RectTransform>().position = new Vector3(camPos.x, camPos.y, 0);
        drop.SetActive(true);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        otherRectTransform.anchoredPosition = originalPosition;
        drop.SetActive(false);
    }
}
