using System.Collections.Generic;

public static class TrainingStatistics
{
    private static List<TrainingResult> results = new List<TrainingResult>();
    public static int ResultsCount => results.Count;
    private static List<TrainingResult>.Enumerator enumerator;

    public static void AddResult(BloodSample bloodSample)
    {
        results.Add(new TrainingResult(bloodSample));
    }
    
    public static TrainingResult GetResult()
    {
        if (enumerator.MoveNext())
        {
            return enumerator.Current;
        }

        return null;
    }

    public static void SetEnumerator()
    {
        enumerator = results.GetEnumerator();
    }

    public static void Reset()
    {
        results = new List<TrainingResult>();
    }
}

public class TrainingResult
{
    public readonly BloodSample Given;
    public readonly BloodSample Analyzed;
    public bool IsCorrect => Given.Equals(Analyzed);

    public TrainingResult(BloodSample bloodSample)
    {
        Given = bloodSample;
        Analyzed = new BloodSample((BloodGroup)bloodSample.BloodGroupSticker, (Rh)bloodSample.RhSticker,
            (BloodQuality)bloodSample.BloodQualitySticker);
    }
}