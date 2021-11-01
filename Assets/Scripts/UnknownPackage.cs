using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnknownPackage : MonoBehaviour
{
    private bool IsDrop;
    private Vector2 originalPos;
    private RectTransform rectTransform;
    void Awake()
    {
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
            Debug.Log("trigger");
            BloodClass.ChangeBloodSample(BloodClass.GetSampleByNumber(name));
            SceneManager.LoadScene("Lab");
        }
    }
}
