using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentPackage : MonoBehaviour
{
    private bool isTriggered;
    private Vector2 originalPos;
    private RectTransform rectTransform;
    void Awake()
    {
        if (BloodClass.CurrentBloodSample == null)
        {
            gameObject.SetActive(false);
        }
        
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
    }

    void OnDrop(GameObject other)
    {
        if (gameObject != other)
        {
            return;
        }
        
        if (isTriggered)
        {
            BloodClass.CurrentBloodSample.IsSeparated = false;
            SceneManager.LoadScene("Lab");
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
