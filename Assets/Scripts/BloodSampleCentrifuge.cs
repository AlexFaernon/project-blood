using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BloodSampleCentrifuge : MonoBehaviour
{
    [SerializeField]private Sprite SeparatedSprite;
    private bool IsDrop;
    private Vector2 originalPos;
    private RectTransform rectTransform;
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
            IsDrop = true;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (IsDrop)
        {
            IsDrop = false;
            rectTransform.anchoredPosition = originalPos;
            Debug.Log("trigger");
            BloodClass.CurrentBloodSample.IsSeparated = true;
            SceneManager.LoadScene("Centrifuge");
        }
    }
}
