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
        if (gameObject != other || !isTriggered) return;
        
        ShakeShakeShake();
        rectTransform.position = originalPos;
    }

    private void ShakeShakeShake()
    {
        var recipes = Recipes.Cocktails.Keys;

        foreach (var recipe in recipes)
        {
            if (TableManager.Shaker.SetEquals(recipe))
            {
                //todo pure blood
                var cocktail = Recipes.Cocktails[recipe];
                var package = TableManager.CurrentPackage;
                Debug.Log(cocktail.Name);
                if (cocktail.BloodSample.Equals(package))
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
