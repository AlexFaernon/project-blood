using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnalyzedSample : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private BloodSample bloodSample;
    private bool isTriggered;
    private Vector2 originalPos;
    private RectTransform rectTransform;
    private void Awake()
    {
        bloodSample = BloodClass.GetAnalyzedSampleByNumber(name);
        if (bloodSample == null || bloodSample == TableManager.CurrentPackage)
        {
            gameObject.SetActive(false);
            return;
        }

        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
        text.text =
            bloodSample.BloodGroupSticker.ToString() + bloodSample.RhSticker + '\n' + bloodSample.BloodQualitySticker;
    }

    private void OnDrop(GameObject other)
    {
        if (other != gameObject)
        {
            return;
        }

        if (isTriggered)
        {
            TableManager.CurrentPackage = bloodSample;
            SceneManager.LoadScene("Fridge");
            return;
        }

        rectTransform.anchoredPosition = originalPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }
}
