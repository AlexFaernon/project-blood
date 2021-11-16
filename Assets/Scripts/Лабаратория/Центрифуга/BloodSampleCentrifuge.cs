using UnityEngine;
using UnityEngine.SceneManagement;
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
            return;
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
                Debug.Log("trigger");
                BloodClass.CurrentBloodSample.IsSeparated = true;
                SceneManager.LoadScene("Centrifuge");
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
