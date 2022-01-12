using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticRow : MonoBehaviour
{
    //todo name and review
    [SerializeField] private TMP_Text customerName;
    [SerializeField] private TMP_Text review;
    [SerializeField] private Image avatar;
    [SerializeField] private Image oneStar;
    [SerializeField] private Image twoStar;
    [SerializeField] private Image threeStar;
    [SerializeField] private TMP_Text wanted;
    [SerializeField] private TMP_Text given;
    
    private StatisticRecord record;
    
    private void Awake()
    {
        record = DailyStatistics.GetRecord();

        if (record == null)
        {
            gameObject.SetActive(false);
            return;
        }

        customerName.text = CustomerData.GetRandomName();
        avatar.sprite = record.Avatar;
        
        switch (record.Stars)
        {
            case OrderStars.NoStars:
                review.text = CustomerData.GetRandomZeroStarReview();
                oneStar.color = Color.clear;
                twoStar.color = Color.clear;
                threeStar.color = Color.clear;
                break;
            case OrderStars.OneStar:
                review.text = CustomerData.GetRandomOneStarReview();
                twoStar.color = Color.clear;
                threeStar.color = Color.clear;
                break;
            case OrderStars.TwoStars:
                review.text = CustomerData.GetRandomTwoStarsReview();
                threeStar.color = Color.clear;
                break;
            case OrderStars.ThreeStars:
                review.text = CustomerData.GetRandomThreeStarsReview();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        wanted.text = record.Wanted.ToString();
        given.text = record.Given.ToString();
    }
}
