using System.Collections.Generic;
using System.Linq;

public static class BloodClass
{
    public static List<BloodSample> BloodSamples { get; } = new List<BloodSample>
    {
        new BloodSample(BloodGroup.Zero, Rh.Negative, BloodQuality.Anemia),
        new BloodSample(BloodGroup.A, Rh.Positive, BloodQuality.Normal)
    };
    

    public static IEnumerable<BloodSample> AnalyzedBloodSamples =>
        BloodSamples.Where(x => x.ClassificationDone);

    public static IEnumerable<BloodSample> UnknownBloodSamples =>
        BloodSamples.Where(x => !x.ClassificationDone);
    
    public static BloodSample CurrentBloodSample { get; private set; }

    public static void ChangeCurrentBloodSample(BloodSample bloodSample)
    {
        if (CurrentBloodSample != null)
        {
            CurrentBloodSample.IsSeparated = false;
        }

        CurrentBloodSample = bloodSample;
    }

    public static void ClearCurrentBloodSample()
    {
        CurrentBloodSample = null;
    }

    public static BloodSample GetSampleByNumber(string name)
    {
        var number = int.Parse(name);
        if (number < UnknownBloodSamples.Count())
        {
            return UnknownBloodSamples.ToArray()[number];
        }

        return null;
    }
}

public class BloodSample
{
    public readonly BloodGroup BloodGroup;
    public readonly Rh Rh;
    public readonly BloodQuality BloodQuality;

    public BloodGroup? BloodGroupSticker = null;
    public Rh? RhSticker = null;
    public BloodQuality? QualitySticker = null;

    public bool IsAnalyzed;

    public bool IsSeparated;
    public bool IsCurrent => BloodClass.CurrentBloodSample == this;

    public bool IsClassified => BloodGroupSticker != null && RhSticker != null && QualitySticker != null;
    public bool ClassificationDone;

    public BloodSample(BloodGroup bloodGroup, Rh rh, BloodQuality bloodQuality)
    {
        BloodGroup = bloodGroup;
        Rh = rh;
        BloodQuality = bloodQuality;
    }
}

public enum BloodGroup
{
    Zero,
    A,
    B,
    AB
}

public enum Rh
{
    Positive,
    Negative
}

public enum BloodQuality
{
    Normal,
    Anemia
}