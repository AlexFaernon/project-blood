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
        var cocktails = Recipes.Cocktails;
        var currentPackage = TableManager.CurrentPackage;

        if (!TableManager.IsPackageInShaker)
        {
            if (TableManager.Shaker.Count == 0)
            {
                return;
            }
            
            EventAggregator.MakeCocktail.Publish(Food.Cocktail.GetBadCocktail(currentPackage.BloodGroup,
                currentPackage.Rh, currentPackage.BloodQuality));
            TableManager.ClearShaker();
            return;
        }

        if (TableManager.Shaker.Count == 0)
        {
            EventAggregator.MakeCocktail.Publish(Food.Cocktail.GetPureBlood(currentPackage.BloodGroup,
                currentPackage.Rh, currentPackage.BloodQuality));
            return;
        }

        foreach (var cocktail in cocktails)
        {
            if (TableManager.Shaker.SetEquals(cocktail.Ingredients))
            {
                Debug.Log(cocktail.Name);
                if (cocktail.BloodSample.Equals(currentPackage))
                {
                    Debug.Log("Nice blood");
                    EventAggregator.MakeCocktail.Publish(cocktail);
                    return;
                }
            }
        }
        
        EventAggregator.MakeCocktail.Publish(Food.Cocktail.GetBadCocktail(currentPackage.BloodGroup,
            currentPackage.Rh, currentPackage.BloodQuality));
        TableManager.ClearShaker();
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
