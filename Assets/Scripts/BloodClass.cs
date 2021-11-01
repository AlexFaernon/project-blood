using System.Collections.Generic;
using System.Linq;

public static class BloodClass
{
    public static List<BloodSample> BloodSamples { get; private set; } = new List<BloodSample>
    {
        new BloodSample(BloodGroup.A, Rh.Negative, Quality.Anemia),
        new BloodSample(BloodGroup.Zero, Rh.Positive, Quality.Normal)
    };
    

    public static IEnumerable<BloodSample> AnalyzedBloodSamples =>
        BloodSamples.Where(x => x.IsClassified && x != CurrentBloodSample);

    public static IEnumerable<BloodSample> UnknownBloodSamples =>
        BloodSamples.Where(x => !x.IsClassified && x != CurrentBloodSample);
    
    public static BloodSample CurrentBloodSample { get; private set; }

    public static void ChangeBloodSample(BloodSample bloodSample)
    {
        if (CurrentBloodSample != null)
        {
            CurrentBloodSample.IsSeparated = false;
        }

        CurrentBloodSample = bloodSample;
    }

    public static BloodSample GetSampleByNumber(string name)
    {
        var number = int.Parse(name);
        return UnknownBloodSamples.ToArray()[number];
    }
}

public class BloodSample
{
    public readonly BloodGroup BloodGroup;
    public readonly Rh Rh;
    public readonly Quality Quality;

    public BloodGroup? ExpectedBloodGroup = null;
    public Rh? ExpectedRh = null;
    public Quality? ExpectedQuality = null;

    public bool IsSeparated;

    public bool IsClassified => ExpectedBloodGroup != null && ExpectedRh != null && ExpectedQuality != null;

    public BloodSample(BloodGroup bloodGroup, Rh rh, Quality quality)
    {
        BloodGroup = bloodGroup;
        Rh = rh;
        Quality = quality;
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

public enum Quality
{
    Normal,
    Anemia
}