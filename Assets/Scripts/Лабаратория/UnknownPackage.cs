using UnityEngine;
using UnityEngine.SceneManagement;

public class UnknownPackage : MonoBehaviour
{
    [SerializeField] private GameObject helpScreen;
    
    private bool IsTriggered;
    private Vector2 originalPos;
    private RectTransform rectTransform;
    public BloodGroup BloodGroup;
    public Rh Rh;
    public BloodQuality BloodQuality;
    void Awake()
    {
        var sample = BloodClass.GetUnknownSampleByNumber(name);

        if (sample == null)
        {
            gameObject.SetActive(false);
            return;
        }
        
        BloodGroup = sample.BloodGroup;
        Rh = sample.Rh;
        BloodQuality = sample.BloodQuality;
        
        if (sample.IsCurrent)
        {
            gameObject.SetActive(false);
            return;
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
        IsTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IsTriggered = false;
    }
    
    void OnDrop(GameObject other)
    {
        if (gameObject == other)
        {
            helpScreen.SetActive(false);
            
            if (IsTriggered)
            {
                BloodClass.ChangeCurrentBloodSample(BloodClass.GetUnknownSampleByNumber(name));
                TabletCircles.ClearTablet();
                SceneManager.LoadScene("Lab");
            }
            
            rectTransform.anchoredPosition = originalPos;
        }
    }
}