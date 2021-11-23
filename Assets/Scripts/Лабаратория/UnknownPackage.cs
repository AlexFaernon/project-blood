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
    public BloodGroup BloodGroup;
    public Rh Rh;
    public BloodQuality BloodQuality;
    void Awake()
    {
        var sample = BloodClass.GetSampleByNumber(name);

        if (sample == null)
        {
            gameObject.SetActive(false);
            return;
        }
        
        BloodGroup = sample.BloodGroup;
        Rh = sample.Rh;
        BloodQuality = sample.BloodQuality;
        
        if (sample.IsCurrent)
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
                BloodClass.ChangeCurrentBloodSample(BloodClass.GetSampleByNumber(name));
                SceneManager.LoadScene("Lab");
            }
            
            rectTransform.anchoredPosition = originalPos;
        }
    }
}