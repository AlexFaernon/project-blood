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
        if (TableManager.GetPositionByName(name) != Vector2.zero)
        {
            rectTransform.anchoredPosition = TableManager.GetPositionByName(name);
        }
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
        ChangeSprite(ingredient);
    }

    private void OnDrop(GameObject other)
    {
        if (gameObject != other)
        {
            return;
        }

        switch (isTriggered)
        {
            case OnTrigger.None:
                originalPos = rectTransform.anchoredPosition;
                break;
            case OnTrigger.Forbidden:
                rectTransform.anchoredPosition = originalPos;
                break;
            case OnTrigger.Board:
                Board();
                break;
            case OnTrigger.Juicer:
                Juicer();
                break;
            case OnTrigger.Fridge:
                ToFridge();
                break;
            default:
                throw new ArgumentOutOfRangeException();
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

    private void ChangeSprite(Food.Ingredient ingredient)
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
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = OnTrigger.None;
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
        if (ingredient != null)
        {
            TableManager.SetPositionByName(name, originalPos);
        }
    }

    private enum OnTrigger
    {
        None,
        Forbidden,
        Board,
        Juicer,
        Fridge
    }
}
