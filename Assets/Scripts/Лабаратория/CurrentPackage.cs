using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentPackage : MonoBehaviour
{
    private bool IsDrop;
    private Vector2 originalPos;
    private RectTransform rectTransform;
    void Awake()
    {
        if (BloodClass.CurrentBloodSample == null)
        {
            gameObject.SetActive(false);
        }
        
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
    }

    void OnDrop(GameObject other)
    {
        if (gameObject == other)
        {
            IsDrop = true;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsDrop)
        {
            IsDrop = false;
            rectTransform.anchoredPosition = originalPos;
            BloodClass.CurrentBloodSample.IsSeparated = false;
            SceneManager.LoadScene("Lab");
        }
    }
}
