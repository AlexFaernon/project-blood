using System;
using UnityEngine;

public class LoadCustomerData : MonoBehaviour
{
    private void Awake()
    {
        CustomerData.Names =
            UnityEngine.Resources.Load<TextAsset>("Reviews/Names").text.Split(new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);
        CustomerData.ZeroStarReviews =
            UnityEngine.Resources.Load<TextAsset>("Reviews/ZeroStar").text.Split(new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);
        CustomerData.OneStarReviews =
            UnityEngine.Resources.Load<TextAsset>("Reviews/OneStar").text.Split(new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);
        CustomerData.TwoStarsReviews =
            UnityEngine.Resources.Load<TextAsset>("Reviews/TwoStars").text.Split(new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);
        CustomerData.ThreeStarsReviews =
            UnityEngine.Resources.Load<TextAsset>("Reviews/ThreeStars").text.Split(new[] { "\r\n" },
                StringSplitOptions.RemoveEmptyEntries);
    }
}
