using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatisticRow : MonoBehaviour
{
    //todo name and review
    [SerializeField] private TMP_Text customerName;
    [SerializeField] private TMP_Text review;
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

        switch (record.Stars)
        {
            case OrderStars.NoStars:
                oneStar.color = Color.clear;
                twoStar.color = Color.clear;
                threeStar.color = Color.clear;
                break;
            case OrderStars.OneStar:
                twoStar.color = Color.clear;
                threeStar.color = Color.clear;
                break;
            case OrderStars.TwoStars:
                threeStar.color = Color.clear;
                break;
            case OrderStars.ThreeStars:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        wanted.text = record.Wanted.ToString();
        given.text = record.Given.ToString();
    }
}
