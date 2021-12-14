using System;
using System.Collections.Generic;
using System.Linq;

public static class BloodClass
{
    public static List<BloodSample> BloodSamples { get; private set; } = new List<BloodSample>();

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

    public static BloodSample GetUnknownSampleByNumber(string name)
    {
        var number = int.Parse(name);
        if (number < UnknownBloodSamples.Count())
        {
            return UnknownBloodSamples.ToArray()[number];
        }

        return null;
    }
    
    public static BloodSample GetAnalyzedSampleByNumber(string name)
    {
        var number = int.Parse(name);
        if (number < AnalyzedBloodSamples.Count())
        {
            return AnalyzedBloodSamples.ToArray()[number];
        }

        return null;
    }

    public static void ClearSamplesList()
    {
        BloodSamples = new List<BloodSample>();
    }

    public static void GenerateRandomSample()
    {
        if (BloodSamples.Count == 10)
        {
            throw new ArgumentOutOfRangeException("too many blood samples");
        }
        var random = new Random();
        var group = (BloodGroup)random.Next(4);
        var rh = (Rh)random.Next(2);
        var quality = (BloodQuality)random.Next(2);
        BloodSamples.Add(new BloodSample(group, rh, quality));
    }
}

[Serializable]
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

    public override bool Equals(object obj)
    {
        if (!(obj is BloodSample other))
        {
            return false;
        }

        return other.BloodGroup == BloodGroup && other.Rh == Rh && other.BloodQuality == BloodQuality;
    }

    protected bool Equals(BloodSample other)
    {
        return BloodGroup == other.BloodGroup && Rh == other.Rh && BloodQuality == other.BloodQuality && BloodGroupSticker == other.BloodGroupSticker && RhSticker == other.RhSticker && QualitySticker == other.QualitySticker && IsAnalyzed == other.IsAnalyzed && IsSeparated == other.IsSeparated && ClassificationDone == other.ClassificationDone;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = (int)BloodGroup;
            hashCode = (hashCode * 397) ^ (int)Rh;
            hashCode = (hashCode * 397) ^ (int)BloodQuality;
            hashCode = (hashCode * 397) ^ BloodGroupSticker.GetHashCode();
            hashCode = (hashCode * 397) ^ RhSticker.GetHashCode();
            hashCode = (hashCode * 397) ^ QualitySticker.GetHashCode();
            hashCode = (hashCode * 397) ^ IsAnalyzed.GetHashCode();
            hashCode = (hashCode * 397) ^ IsSeparated.GetHashCode();
            hashCode = (hashCode * 397) ^ ClassificationDone.GetHashCode();
            return hashCode;
        }
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