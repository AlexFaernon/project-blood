using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class onTouch : MonoBehaviour,IPointerDownHandler
{
    [SerializeField] private new GameObject gameObject;
    public void OnPointerDown(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
