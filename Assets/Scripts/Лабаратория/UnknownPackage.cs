using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnknownPackage : MonoBehaviour
{
    private bool IsTriggered;
    private Vector2 originalPos;
    private RectTransform rectTransform;
    void Awake()
    {
        if (BloodClass.GetSampleByNumber(name).IsCurrent)
        {
            gameObject.SetActive(false);
            return;
        }

        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
    }
    
    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IsTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsTriggered = false;
    }
    
    void OnDrop(GameObject other)
    {
        if (gameObject == other)
        {
            if (IsTriggered)
            {
                BloodClass.ChangeBloodSample(BloodClass.GetSampleByNumber(name));
                SceneManager.LoadScene("Lab");
            }
            
            rectTransform.anchoredPosition = originalPos;
        }
    }
}