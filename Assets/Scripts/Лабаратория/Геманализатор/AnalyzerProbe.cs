using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnalyzerProbe : MonoBehaviour
{
    [SerializeField]private Sprite SeparatedSprite;
    [SerializeField] private TMP_Text Result;
    private Vector2 originalPos;
    private RectTransform rectTransform;
    private bool isTriggered;
    void Awake()
    {
        if (BloodClass.CurrentBloodSample == null)
        {
            gameObject.SetActive(false);
            return;
        }
        
        if (BloodClass.CurrentBloodSample.IsSeparated)
        {
            GetComponent<Image>().sprite = SeparatedSprite;
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
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
    }
    
    void OnDrop(GameObject other)
    {
        if (gameObject == other)
        {
            if (isTriggered)
            {
                Result.text = GetHemoglobin();
            }
            
            rectTransform.anchoredPosition = originalPos;
        }
    }

    private string GetHemoglobin()
    {
        if (BloodClass.CurrentBloodSample.IsSeparated)
        {
            return "ERROR";
        }
        
        BloodClass.CurrentBloodSample.IsAnalyzed = true;
            
        if (BloodClass.CurrentBloodSample.BloodQuality == BloodQuality.Normal)
        {
            return "ok";
        }

        return "anemia";
    }
}
