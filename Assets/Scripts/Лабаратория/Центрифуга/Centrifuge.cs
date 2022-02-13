using UnityEngine;
using UnityEngine.UI;

public class Centrifuge : MonoBehaviour
{
    [SerializeField] private Sprite centrifugeWithSampleSprite;
    [SerializeField] private Button button;

    private void Awake()
    {
        EventAggregator.SampleDropOnCentrifuge.Subscribe(OnDrop);
    }

    private void OnDrop()
    {
        GetComponent<Image>().sprite = centrifugeWithSampleSprite;
        button.interactable = true;
    }

    private void OnDestroy()
    {
        EventAggregator.SampleDropOnCentrifuge.Unsubscribe(OnDrop);
    }
}
