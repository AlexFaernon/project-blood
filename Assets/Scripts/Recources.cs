

public static class Recources
{
    public const int SamplePrice = 200;
    public static int Money = 100000;
    public static int Samples => BloodClass.BloodSamples.Count;
    public static bool[] ToggleSampleShop = { true, true, true, true, true, true };

    private const int StartPackagesAmount = 3;

    public static void CreateFirstSamples()
    {
        BloodClass.ClearSamplesList();
        
        for (var i = 0; i < StartPackagesAmount; i++)
        {
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
