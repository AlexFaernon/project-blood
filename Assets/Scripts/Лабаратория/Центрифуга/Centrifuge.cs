using UnityEngine;
using UnityEngine.UI;

public class Centrifuge : MonoBehaviour
{
    [SerializeField] private Sprite centrifugeWithSampleSprite;

    private void Awake()
    {
        EventAggregator.SampleDropOnCentrifuge.Subscribe(OnDrop);
    }

    private void OnDrop()
    {
        GetComponent<Image>().sprite = centrifugeWithSampleSprite;
    }

    private void OnDestroy()
    {
        EventAggregator.SampleDropOnCentrifuge.Unsubscribe(OnDrop);
    }
}
