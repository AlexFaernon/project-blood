using UnityEngine;

public class GlassFridge : MonoBehaviour
{
    private bool isTriggered;

    private void Awake()
    {
        EventAggregator.OnDrop.Subscribe(OnDrop);
    }

    private void OnDrop(GameObject other)
    {
        if (gameObject != other || !isTriggered) return;
        
        TableManager.IsGlassActive = true;
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
