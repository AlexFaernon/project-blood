using UnityEngine;
using UnityEngine.UI;

public class RecipeBookCocktail : MonoBehaviour
{
    [SerializeField] private Image cocktailColor;
    [SerializeField] private Image pieces;
    [SerializeField] private Image peel;
    [SerializeField] private PageSide pageSide;
    [SerializeField] private Sprite lemonPeel;
    [SerializeField] private Sprite limePeel;
    [SerializeField] private Sprite orangePeel;
    [SerializeField] private Sprite applePeel;
    [SerializeField] private Sprite lemonPieces;
    [SerializeField] private Sprite limePieces;
    [SerializeField] private Sprite orangePieces;
    [SerializeField] private Sprite applePieces;
    [SerializeField] private Sprite pineapplePieces;

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
        var color = cocktail.GetColor();
        cocktailColor.color = new Color(color.r, color.g, color.b, 0.5f);

        foreach (var ingredient in cocktail.Ingredients)
        {
            if (ingredient.Fruit != null)
            {
                if (ingredient.Condition == Food.Condition.Peel)
                {
                    peel.gameObject.SetActive(true);
                }
                else if (ingredient.Condition == Food.Condition.Pieces)
                {
                    pieces.gameObject.SetActive(true);
                }
                
                switch (ingredient.Fruit)
                {
                    case Food.Fruits.Lime:
                        peel.sprite = limePeel;
                        pieces.sprite = limePieces;
                        break;
                    case Food.Fruits.Lemon:
                        peel.sprite = lemonPeel;
                        pieces.sprite = lemonPieces;
                        break;
                    case Food.Fruits.Apple:
                        peel.sprite = applePeel;
                        pieces.sprite = applePieces;
                        break;
                    case Food.Fruits.Orange:
                        peel.sprite = orangePeel;
                        pieces.sprite = orangePieces;
                        break;
                    case Food.Fruits.Pineapple:
                        pieces.sprite = pineapplePieces;
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
