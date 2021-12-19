using System;
using UnityEngine;

public class ShakerScript : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originalPos;
    private bool isTriggered;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.position;
        EventAggregator.OnDrop.Subscribe(OnDrop);
    }

    private void OnDrop(GameObject other)
    {
        if (gameObject != other) return;
        if (isTriggered)
        {
            ShakeShakeShake();
        }
        rectTransform.position = originalPos;
    }

    private void ShakeShakeShake()
    {
        var recipes = Recipes.Cocktails.Keys;

        if (!TableManager.IsPackageInShaker)
        {
            if (TableManager.Shaker.Count == 0)
            {
                return;
            }
            EventAggregator.MakeCocktail.Publish(Food.Cocktail.GetBadCocktail());
            return;
        }

        if (TableManager.Shaker.Count == 0)
        {
            var currentPackage = TableManager.CurrentPackage;
            EventAggregator.MakeCocktail.Publish(Food.Cocktail.GetPureBlood(currentPackage.BloodGroup,
                currentPackage.Rh, currentPackage.BloodQuality));
            return;
        }

        foreach (var recipe in recipes)
        {
            if (TableManager.Shaker.SetEquals(recipe))
            {
                var cocktail = Recipes.Cocktails[recipe];
                var currentPackage = TableManager.CurrentPackage;
                Debug.Log(cocktail.Name);
                if (cocktail.BloodSample.Equals(currentPackage))
                {
                    Debug.Log("Nice blood");
                    EventAggregator.MakeCocktail.Publish(cocktail);
                    TableManager.ClearShaker();
                    return;
                }
            }
        }
        
        EventAggregator.MakeCocktail.Publish(Food.Cocktail.GetBadCocktail());
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Glass"))
        {
            isTriggered = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Glass"))
        {
            isTriggered = true;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }
}
