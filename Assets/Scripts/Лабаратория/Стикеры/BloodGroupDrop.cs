using System;
using UnityEngine;
using UnityEngine.UI;

public class BloodGroupDrop : MonoBehaviour
{
    [SerializeField] private Sprite sprite0;
    [SerializeField] private Sprite spriteA;
    [SerializeField] private Sprite spriteB;
    [SerializeField] private Sprite spriteAB;
    private Image image;
    private void Awake()
    {
        image = GetComponent<Image>();
        
        if (BloodClass.CurrentBloodSample != null)
            ChangeSticker(BloodClass.CurrentBloodSample?.BloodGroupSticker);
        
        EventAggregator.BloodGroupSticker.Subscribe(ChangeSticker);
        if (GameMode.IsTraining)
        {
            EventAggregator.OnTrainingCheck.Subscribe(OnTrainingCheck);
        }
    }

    private void ChangeSticker(BloodGroup? bloodGroup)
    {
        BloodClass.CurrentBloodSample.BloodGroupSticker = bloodGroup;
        
        image.color = Color.white;
        switch (BloodClass.CurrentBloodSample.BloodGroupSticker)
        {
            case BloodGroup.Zero:
                image.sprite = sprite0;
                break;
            case BloodGroup.A:
                image.sprite = spriteA;
                break;
            case BloodGroup.B:
                image.sprite = spriteB;
                break;
            case BloodGroup.AB:
                image.sprite = spriteAB;
                break;
            case null:
                image.color = new Color(0,0,0,0);
                break;
        }
    }
    
    private void OnTrainingCheck()
    {
        if (BloodClass.CurrentBloodSample.BloodGroup == BloodClass.CurrentBloodSample.BloodGroupSticker)
        {
            image.color = Color.green;
        }
        else
        {
            image.color = Color.red;
            EventAggregator.HighlightCorrectBloodGroupSticker.Publish(BloodClass.CurrentBloodSample.BloodGroup);
        }
    }

    private void OnDestroy()
    {
        EventAggregator.BloodGroupSticker.Unsubscribe(ChangeSticker);
        
        if (GameMode.IsTraining)
        {
            EventAggregator.OnTrainingCheck.Unsubscribe(OnTrainingCheck);
        }
    }
}
