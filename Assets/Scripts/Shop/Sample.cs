using UnityEngine;
using UnityEngine.SceneManagement;

public class Sample : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originalPos;
    private bool isTriggered;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
        gameObject.SetActive(Resources.ToggleSampleShop[int.Parse(name)]);
    }

    private void OnDrop(GameObject other)
    {
        if (isTriggered && other == gameObject)
        {
            if (Resources.BuySample())
            {
                Resources.ToggleSampleShop[int.Parse(name)] = false;
                SceneManager.LoadScene("Shop");
                return;
            }
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
