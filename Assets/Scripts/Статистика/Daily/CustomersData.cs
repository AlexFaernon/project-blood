using System;

public static class CustomerData
{
    public static string[] Names;
    public static string[] ZeroStarReviews;
    public static string[] OneStarReviews;
    public static string[] TwoStarsReviews;
    public static string[] ThreeStarsReviews;
    private static readonly Random random = new Random();

    public static string GetRandomName()
    {
        return Names[random.Next(Names.Length)];
    }
    
    public static string GetRandomZeroStarReview()
    {
        return ZeroStarReviews[random.Next(ZeroStarReviews.Length)];
    }
    
    public static string GetRandomOneStarReview()
    {
        return OneStarReviews[random.Next(OneStarReviews.Length)];
    }
    
    public static string GetRandomTwoStarsReview()
    {
        return TwoStarsReviews[random.Next(TwoStarsReviews.Length)];
    }
    
    public static string GetRandomThreeStarsReview()
    {
        return ThreeStarsReviews[random.Next(ThreeStarsReviews.Length)];
    }
}