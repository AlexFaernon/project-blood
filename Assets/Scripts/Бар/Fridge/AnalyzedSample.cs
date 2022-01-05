using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnalyzedSample : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
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
        SetText();
    }

    private void SetText()
    {
        var text =
            (bloodSample.BloodGroupSticker == BloodGroup.Zero ? "0" : bloodSample.BloodGroupSticker.ToString()) +
            (bloodSample.RhSticker == Rh.Negative ? "-" : "+") + '\n' +
            (bloodSample.BloodQuality == BloodQuality.Normal ? "Норм" : "Анем");
        label.text = text;
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
