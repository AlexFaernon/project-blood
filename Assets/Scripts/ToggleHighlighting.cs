using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleHighlighting : MonoBehaviour
{
    [SerializeField] private List<string> tags = new List<string>();

    private void Awake()
    {
        EventAggregator.ToggleHighlightingOn.Subscribe(ToggleHighlightingOn);
        EventAggregator.ToggleHighlightingOff.Subscribe(ToggleHighlightingOff);
    }
    
    private void ToggleHighlightingOn(GameObject other)
    {
        if (tags.Contains(other.tag))
        {
            var outline = gameObject.AddComponent<Outline>();
            outline.effectColor = Color.red;
            outline.effectDistance = new Vector2(3,3);
            outline.useGraphicAlpha = false;
        }
    }

    private void ToggleHighlightingOff()
    {
        if (gameObject.TryGetComponent(out Outline outline))
        {
            Destroy(outline);
        }
    }

    private void OnDestroy()
    {
        EventAggregator.ToggleHighlightingOn.Unsubscribe(ToggleHighlightingOn);
        EventAggregator.ToggleHighlightingOff.Unsubscribe(ToggleHighlightingOff);
    }
}
