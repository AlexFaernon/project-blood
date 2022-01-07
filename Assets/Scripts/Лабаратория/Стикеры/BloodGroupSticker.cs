using UnityEngine;
using UnityEngine.UI;

public class BloodGroupSticker : MonoBehaviour
{
    [SerializeField] private BloodGroup bloodGroup;
    private bool isTriggered;
    private Vector2 rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>().anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
        
        if (GameMode.IsTraining)
        {
            EventAggregator.HighlightCorrectBloodGroupSticker.Subscribe(ToggleHighlight);
        }
    }

    private void OnDrop(GameObject other)
    {
        if (other == gameObject && isTriggered)
        {
            EventAggregator.BloodGroupSticker.Publish(bloodGroup);
        }

        GetComponent<RectTransform>().anchoredPosition = rectTransform;
    }
    
    private void ToggleHighlight(BloodGroup correctBloodGroup)
    {
        if (bloodGroup == correctBloodGroup)
        {
            GetComponent<Image>().color = Color.green;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BloodGroupSticker"))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("BloodGroupSticker"))
        {
            isTriggered = false;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
        
        if (GameMode.IsTraining)
        {
            EventAggregator.HighlightCorrectBloodGroupSticker.Unsubscribe(ToggleHighlight);
        }
    }
}
