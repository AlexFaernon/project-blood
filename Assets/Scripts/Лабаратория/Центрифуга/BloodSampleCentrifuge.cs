using UnityEngine;
using UnityEngine.UI;

public class BloodSampleCentrifuge : MonoBehaviour
{
    [SerializeField]private Sprite SeparatedSprite;
    private Vector2 originalPos;
    private RectTransform rectTransform;
    private bool isTriggered;
    private void Awake()
    {
        if (BloodClass.CurrentBloodSample == null)
        {
            gameObject.SetActive(false);
            return;
        }
    
        if (BloodClass.CurrentBloodSample.IsSeparated)
        {
            GetComponent<Image>().sprite = SeparatedSprite;
            gameObject.tag = "Finish";
        }
        
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
    }

    void OnDrop(GameObject other)
    {
        if (gameObject == other)
        {
            if (isTriggered)
            {
                if (!BloodClass.CurrentBloodSample.IsSeparated)
                {
                    gameObject.SetActive(false);
                    EventAggregator.SampleDropOnCentrifuge.Publish();
                }
            }
            
            rectTransform.anchoredPosition = originalPos;
        }
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
}
