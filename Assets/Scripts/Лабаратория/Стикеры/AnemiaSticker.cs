using UnityEngine;

public class AnemiaSticker : MonoBehaviour
{
    [SerializeField] private BloodQuality bloodQuality;
    private bool isTriggered;
    private Vector2 rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>().anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
    }

    private void OnDrop(GameObject other)
    {
        if (other == gameObject && isTriggered)
        {
            EventAggregator.BloodQualitySticker.Publish(bloodQuality);
        }

        GetComponent<RectTransform>().anchoredPosition = rectTransform;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AnemiaSticker"))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("AnemiaSticker"))
        {
            isTriggered = false;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }
}