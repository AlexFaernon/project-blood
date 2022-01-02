using System;
using System.Collections.Generic;
using System.Linq;

public static class BloodClass
{
    //todo saved
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

    public static void LoadBloodSamples(List<BloodSample> bloodSamples)
    {
        BloodSamples = bloodSamples;
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

    public static void GenerateRandomSample(Random random)
    {
        if (BloodSamples.Count == 9)
        {
            throw new ArgumentOutOfRangeException("too many blood samples");
        }
        var group = (BloodGroup)random.Next(4);
        var rh = (Rh)random.Next(2);
        var quality = (BloodQuality)random.Next(2);
        BloodSamples.Add(new BloodSample(group, rh, quality));
    }

    public static void RemoveAnalyzedPackage(BloodSample bloodSample)
    {
        BloodSamples.Remove(bloodSample);
        SaveDataScript.SaveBlood();
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
    public BloodQuality? BloodQualitySticker = null;

    public bool IsAnalyzed;

    public bool IsSeparated;
    public bool IsCurrent => BloodClass.CurrentBloodSample == this;

    public bool IsClassified => BloodGroupSticker != null && RhSticker != null && BloodQualitySticker != null;
    public bool ClassificationDone;

    public BloodSample(BloodGroup bloodGroup, Rh rh, BloodQuality bloodQuality)
    {
        BloodGroup = bloodGroup;
        Rh = rh;
        BloodQuality = bloodQuality;
    }

    public override string ToString()
    {
        return BloodGroup + (Rh == Rh.Negative ? "-" : "+") + (BloodQuality == BloodQuality.Normal ? "норм" : "анем");
    }

    public override bool Equals(object obj)
    {
        if (!(obj is BloodSample other))
        {
            return false;
        }

        if (other.IsAnalyzed && IsAnalyzed)
        {
            return other.BloodGroup == BloodGroup && other.Rh == Rh && other.BloodQuality == BloodQuality &&
                   other.BloodGroupSticker == BloodGroupSticker && other.RhSticker == RhSticker &&
                   other.BloodQualitySticker == BloodQualitySticker;
        }
        
        return other.BloodGroup == BloodGroup && other.Rh == Rh && other.BloodQuality == BloodQuality;
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
            hashCode = (hashCode * 397) ^ BloodQualitySticker.GetHashCode();
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