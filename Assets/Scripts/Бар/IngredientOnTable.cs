using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IngredientOnTable : MonoBehaviour
{
    [SerializeField] private Sprite pepper;
    [SerializeField] private Sprite honey;
    [SerializeField] private Sprite coffee;
    [SerializeField] private Sprite carnation;
    [SerializeField] private Sprite apple;
    [SerializeField] private Sprite lemon;
    [SerializeField] private Sprite lime;
    [SerializeField] private Sprite pineapple;
    [SerializeField] private Sprite orange;
    [SerializeField] private Sprite celery;
    private Food.Ingredient ingredient;
    private OnTrigger isTriggered;
    private RectTransform rectTransform;
    private Vector2 originalPos;

    private void Awake()
    {
        ingredient = TableManager.GetIngredientByNumber(name);

        if (ingredient == null)
        {
            gameObject.SetActive(false);
            return;
        }

        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
        ChangeSprite();
    }

    private void OnDrop(GameObject other)
    {
        if (gameObject != other)
        {
            return;
        }

        if (isTriggered != OnTrigger.Forbidden)
        {
            originalPos = rectTransform.anchoredPosition;
        }
        
        switch (isTriggered)
        {
            case OnTrigger.Forbidden:
                rectTransform.anchoredPosition = originalPos;
                break;
            case OnTrigger.Board:
                Board();
                break;
            case OnTrigger.Juicer:
                Juicer();
                break;
            case OnTrigger.Shaker:
                Shaker();
                break;
            case OnTrigger.Fridge:
                ToFridge();
                break;
        }
    }

    private void Board()
    {
        if (ingredient.Fruit == null || ingredient.Fruit == Food.Fruits.Celery) return;
        
        EventAggregator.OnBoardDrop.Publish(ingredient);
        TableManager.RemoveIngredientByName(name);
        ingredient = null;
    }

    private void Juicer()
    {
        if (ingredient.Fruit == null) return;
        
        EventAggregator.OnJuicerDrop.Publish(ingredient);
        TableManager.RemoveIngredientByName(name);
        ingredient = null;
    }

    private void Shaker()
    {
        if (ingredient.Miscellaneous == null) return;
        
        TableManager.AddIngredientToShaker(ingredient);
        TableManager.RemoveIngredientByName(name);
        ingredient = null;
        SceneManager.LoadScene("Bar");
    }
    
    private void ToFridge()
    {
        TableManager.RemoveIngredientByName(name);
        if (ingredient.Fruit != null)
        {
            Food.Ingredients[ingredient.Fruit] += 1;
        }
        else
        {
            Food.Ingredients[ingredient.Miscellaneous] += 1;
        }

        ingredient = null;
        SceneManager.LoadScene("Bar");
    }
    
    private void ChangeSprite()
    {
        var image = GetComponent<Image>();
        if (ingredient.Fruit != null)
        {
            image.sprite = ingredient.Fruit switch
            {
                Food.Fruits.Apple => apple,
                Food.Fruits.Pineapple => pineapple,
                Food.Fruits.Lemon => lemon,
                Food.Fruits.Lime => lime,
                Food.Fruits.Orange => orange,
                Food.Fruits.Celery => celery,
                _ => image.sprite
            };
        }
        else
        {
            image.sprite = ingredient.Miscellaneous switch
            {
                Food.Miscellaneous.Pepper => pepper,
                Food.Miscellaneous.Honey => honey,
                Food.Miscellaneous.Coffee => coffee,
                Food.Miscellaneous.Carnation => carnation,
                _ => image.sprite
            };
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = other.gameObject.tag switch
        {
            "IngredientsForbidden" => OnTrigger.Forbidden,
            "Board" => OnTrigger.Board,
            "Fridge" => OnTrigger.Fridge,
            "Juicer" => OnTrigger.Juicer,
            "Shaker" => OnTrigger.Shaker,
            _ => isTriggered
        };
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = OnTrigger.None;
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }

    private enum OnTrigger
    {
        None,
        Forbidden,
        Board,
        Juicer,
        Fridge,
        Shaker
    }
}
