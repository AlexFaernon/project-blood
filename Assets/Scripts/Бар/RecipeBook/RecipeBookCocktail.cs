using System;
using UnityEngine;
using UnityEngine.UI;

public class RecipeBookCocktail : MonoBehaviour
{
    [SerializeField] private Image cocktailColor;
    [SerializeField] private Image pieces;
    [SerializeField] private Image peel;
    [SerializeField] private PageSide pageSide;

    private void Awake()
    {
        if (pageSide == PageSide.Left)
        {
            EventAggregator.RecipeBookCocktailLeft.Subscribe(ChangeSprite);
        }
        else
        {
            EventAggregator.RecipeBookCocktailRight.Subscribe(ChangeSprite);
        }
    }
    
    private void ChangeSprite(Food.Cocktail cocktail)
    {
        cocktailColor.color = cocktail.GetColor();

        foreach (var ingredient in cocktail.Ingredients)
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

    private void OnDestroy()
    {
        if (pageSide == PageSide.Left)
        {
            EventAggregator.RecipeBookCocktailLeft.Unsubscribe(ChangeSprite);
        }
        else
        {
            EventAggregator.RecipeBookCocktailRight.Unsubscribe(ChangeSprite);
        }
    }
}
