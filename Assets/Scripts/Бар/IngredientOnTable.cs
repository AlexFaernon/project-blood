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
        
        switch (isTriggered)
        {
            case OnTrigger.None:
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
        if (ingredient.Fruit == null || ingredient.Fruit == Food.Fruits.Celery)
        {
            rectTransform.anchoredPosition = originalPos;
            return;
        }
        
        EventAggregator.OnBoardDrop.Publish(ingredient);
        TableManager.RemoveIngredientByName(name);
        ingredient = null;
    }

    private void Juicer()
    {
        if (ingredient.Fruit == null)
        {
            rectTransform.anchoredPosition = originalPos;
            return;
        }
        
        EventAggregator.OnJuicerDrop.Publish(ingredient);
        TableManager.RemoveIngredientByName(name);
        ingredient = null;
    }

    private void Shaker()
    {
        if (ingredient.Miscellaneous == null)
        {
            rectTransform.anchoredPosition = originalPos;
            return;
        }
        
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
            SaveDataScript.SaveIngredients();
        }
        else
        {
            Food.Ingredients[ingredient.Miscellaneous] += 1;
            SaveDataScript.SaveIngredients();
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

            gameObject.tag = ingredient.Fruit == Food.Fruits.Celery ? "Celery" : "Fruit";
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
            
            gameObject.tag = "Miscellaneous";
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = other.gameObject.tag switch
        {
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
        Board,
        Juicer,
        Fridge,
        Shaker
    }
}
