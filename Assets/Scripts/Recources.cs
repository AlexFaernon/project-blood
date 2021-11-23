

public static class Recources
{
    public const int SamplePrice = 200;
    public static int Money = 100000;
    public static int Samples => BloodClass.BloodSamples.Count;
    public static bool[] ToggleSample = { true, true, true, true, true, true };

    public static void CreateFirstSamples()
    {
        for (var i = 0; i < 4; i++)
        {
            BloodClass.ClearSamplesList();
            BloodClass.GenerateRandomSample();
        }
    }

    public static bool BuySample()
    {
        if (Money < SamplePrice)
        {
            return false;
        }

        Money -= SamplePrice;
        BloodClass.GenerateRandomSample();
        return true;
    }
}
