using UnityEngine;
using UnityEngine.UI;

public class RhDrop : MonoBehaviour
{
    [SerializeField] private Sprite spriteNegative;
    [SerializeField] private Sprite spritePositive;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        
        if (BloodClass.CurrentBloodSample != null)
            ChangeSticker(BloodClass.CurrentBloodSample.RhSticker);
        
        EventAggregator.RhSticker.Subscribe(ChangeSticker);
        if (CurrentGameMode.GameMode == GameMode.Training)
        {
            EventAggregator.OnTrainingCheck.Subscribe(OnTrainingCheck);
        }
    }

    private void ChangeSticker(Rh? rh)
    {
        BloodClass.CurrentBloodSample.RhSticker = rh;
        
        image.color = Color.white;
        switch (BloodClass.CurrentBloodSample.RhSticker)
        {
            case Rh.Negative:
                image.sprite = spriteNegative;
                break;
            case Rh.Positive:
                image.sprite = spritePositive;
                break;
            case null:
                image.color = new Color(0,0,0,0);
                break;
        }
    }
    
    private void OnTrainingCheck()
    {
        if (BloodClass.CurrentBloodSample.Rh == BloodClass.CurrentBloodSample.RhSticker)
        {
            image.color = Color.green;
        }
        else
        {
            image.color = Color.red;
            EventAggregator.HighlightCorrectRhSticker.Publish(BloodClass.CurrentBloodSample.Rh);
        }
    }

    private void OnDestroy()
    {
        EventAggregator.RhSticker.Unsubscribe(ChangeSticker);
        if (CurrentGameMode.GameMode == GameMode.Training)
        {
            EventAggregator.OnTrainingCheck.Unsubscribe(OnTrainingCheck);
        }
    }
}