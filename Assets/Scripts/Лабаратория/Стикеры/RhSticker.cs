using UnityEngine;

public class RhSticker : MonoBehaviour
{
    [SerializeField] private Rh rh;
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
            EventAggregator.RhSticker.Publish(rh);
        }

        GetComponent<RectTransform>().anchoredPosition = rectTransform;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RhSticker"))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RhSticker"))
        {
            isTriggered = false;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }
}