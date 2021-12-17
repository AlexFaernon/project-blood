

using System;

public static class Resources
{
    public const int SamplePrice = 200;
    public static int Money = 100000;
    public static int Samples => BloodClass.BloodSamples.Count;
    public static bool[] ToggleSampleShop = { true, true, true, true, true, true };

    private const int StartPackagesAmount = 2;

    public static void CreateFirstSamples()
    {
        BloodClass.ClearSamplesList();

        var random = new Random();
        for (var i = 0; i < StartPackagesAmount; i++)
        {
            BloodClass.GenerateRandomSample(random);
        }
    }

    public static bool BuySample()
    {
        if (Money < SamplePrice)
        {
            return false;
        }

        Money -= SamplePrice;
        var random = new Random();
        BloodClass.GenerateRandomSample(random);
        return true;
    }

    public static bool BuyIngredient(int price)
    {
        if (price > Money)
        {
            return false;
        }

        Money -= price;
        return true;
    }
}
