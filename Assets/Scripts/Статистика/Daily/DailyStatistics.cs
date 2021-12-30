using System;
using System.Collections.Generic;
using Unity.Collections;

public static class DailyStatistics
{
    //todo save
    public static List<StatisticRecord> Records = new List<StatisticRecord>();
    private static List<StatisticRecord>.Enumerator enumerator;
    public static void AddRecord(OrderStars stars, BloodSample wanted, BloodSample given)
    {
        Records.Add(new StatisticRecord(stars, wanted, given));
    }

    public static StatisticRecord GetRecord()
    {
        if (enumerator.MoveNext())
        {
            return enumerator.Current;
        }

        return null;
    }

    public static void SetEnumerator()
    {
        enumerator = Records.GetEnumerator();
    }
    
    public static void ResetRecords()
    {
        Records = new List<StatisticRecord>();
    }
}

[Serializable]
public class StatisticRecord
{
    public readonly OrderStars Stars;
    public readonly BloodSample Wanted;
    public readonly BloodSample Given;

    public StatisticRecord(OrderStars stars, BloodSample wanted, BloodSample given)
    {
        Stars = stars;
        Wanted = wanted;
        Given = given;
    }
}