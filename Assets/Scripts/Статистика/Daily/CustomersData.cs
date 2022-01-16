using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public static class CustomerData
{
    public static List<CustomerAvatar> Avatars = new List<CustomerAvatar>();
    public static int CurrentSpriteNumber;
    public static string[] Names;
    public static string[] ZeroStarReviews;
    public static string[] OneStarReviews;
    public static string[] TwoStarsReviews;
    public static string[] ThreeStarsReviews;
    private static readonly Random random = new Random();

    public static void RandomizeAvatar()
    {
        CurrentSpriteNumber = random.Next(Avatars.Count);
    }
    
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

public class CustomerAvatar
{
    public readonly Sprite Normal;
    public readonly Sprite Angry;
    public readonly Sprite Happy;

    public CustomerAvatar(Sprite normal, Sprite angry, Sprite happy)
    {
        Normal = normal;
        Angry = angry;
        Happy = happy;
    }
}