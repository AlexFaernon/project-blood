using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlassBar : MonoBehaviour
{
    [SerializeField] private Image cocktailColor;
    [SerializeField] private Image pieces;
    [SerializeField] private Image peel;
    private Triggers triggers;
    private RectTransform rectTransform;
    private Vector2 originalPos;
    
    private void Awake()
    {
        if (!TableManager.IsGlassActive)
        {
            gameObject.SetActive(false);
        }

        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.MakeCocktail.Subscribe(OnCocktail);
        EventAggregator.OnDrop.Subscribe(OnDrop);
        ChangeSprite();
    }

    private void OnDrop(GameObject other)
    {
        if (other != gameObject) return;

        switch (triggers)
        {
            case Triggers.Hole:
                TableManager.ClearCocktail();
                SceneManager.LoadScene("Bar");
                return;
            case Triggers.Customer:
                if (!TableManager.IsPackageInShaker)
                {
                    Debug.Log("Blood doko???");
                    rectTransform.anchoredPosition = originalPos;
                    return;
                }
                EventAggregator.SellCocktail.Publish(TableManager.CurrentCocktail);
                TableManager.ClearCocktail();
                
                TableManager.IsGlassActive = false;
                SaveDataScript.SaveIsGlassActive();
                
                TableManager.RemovePackage();
                SceneManager.LoadScene("Bar");
                return;
            default:
                rectTransform.anchoredPosition = originalPos;
                break;
        }
    }
    
    private void OnCocktail(Food.Cocktail cocktail)
    {
        TableManager.CurrentCocktail = cocktail;
        SaveDataScript.SaveCurrentCocktail();
        SceneManager.LoadScene("Bar");
    }

    private void ChangeSprite()
    {
        if (TableManager.CurrentCocktail == null) return;
        
        
        cocktailColor.gameObject.SetActive(true);
        if (TableManager.CurrentCocktail.IsShitted)
        {
            cocktailColor.color = Color.black;
            return;
        }
        
        cocktailColor.color = TableManager.CurrentCocktail.GetColor();

        if (TableManager.CurrentCocktail.IsShitted || TableManager.CurrentCocktail.PureBlood)
        {
            return;
        }
        
        foreach (var ingredient in TableManager.CurrentCocktail.Ingredients)
        {
            if (ingredient.Fruit != null)
            {
                var fruitColor = ingredient.Fruit switch
                {
                    Food.Fruits.Lime => BoardScript.lime,
                    Food.Fruits.Lemon => BoardScript.lemon,
                    Food.Fruits.Apple => BoardScript.apple,
                    Food.Fruits.Orange => BoardScript.orange,
                    Food.Fruits.Pineapple => BoardScript.pineapple,
                    _ => Color.white
                };

                switch (ingredient.Condition)
                {
                    case Food.Condition.Peel:
                        peel.gameObject.SetActive(true);
                        peel.color = fruitColor;
                        break;
                    case Food.Condition.Pieces:
                        pieces.gameObject.SetActive(true);
                        pieces.color = fruitColor;
                        break;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hole"))
        {
            triggers = Triggers.Hole;
            return;
        }

        if (other.CompareTag("Customer"))
        {
            triggers = Triggers.Customer;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hole") || other.CompareTag("Customer"))
        {
            triggers = Triggers.None;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.MakeCocktail.Unsubscribe(OnCocktail);
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }

    private enum Triggers
    {
        None,
        Hole,
        Customer
    }
}
