using System;

public static class Resources
{
    public const int SamplePrice = 200;
    //todo saved
    public static int Money = 100000;
    public static int Samples => BloodClass.BloodSamples.Count;
    public static bool[] ToggleSampleShop { get; private set; } = { true, true, true, true, true, true };

    private const int StartPackagesAmount = 1;

    public static void ResetSamples()
    {
        ToggleSampleShop = new[] { true, true, true, true, true, true };
    }
    
    public static void CreateFirstSamples()
    {
        var random = new Random();
        for (var i = 0; i < StartPackagesAmount; i++)
        {
            BloodClass.GenerateRandomSample(random);
        }
        SaveDataScript.SaveBlood();
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
        SaveDataScript.SaveMoney();
        return true;
    }
}
