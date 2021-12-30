using System;
using TMPro;
using UnityEngine;

public class StatisticRow : MonoBehaviour
{
    [SerializeField] private TMP_Text stars;
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

        stars.text = record.Stars.ToString();
        wanted.text = record.Wanted.ToString();
        given.text = record.Given.ToString();
    }
}
