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
    private RectTransform rectTransform;
    private Vector2 originalPos;
    private Image image;

    private bool isOnShaker;
    private bool isOnBoard;
    private bool isOnJuicer;
    private bool isOnFridge;

    private void Awake()
    {
        ingredient = TableManager.GetIngredientByNumber(name);

        if (ingredient == null)
        {
            gameObject.SetActive(false);
            return;
        }
        
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
        ChangeSprite();
        var fitter = GetComponent<AspectRatioFitter>();
        fitter.aspectRatio = image.sprite.rect.width / image.sprite.rect.height;
    }

    private void OnDrop(GameObject other)
    {
        if (gameObject != other)
        {
            return;
        }
        
        if (isOnBoard)
        {
            if (Board()) return;
        }

        if (isOnJuicer)
        {
            if (Juicer()) return;
        }

        if (isOnShaker)
        {
            if (Shaker()) return;
        }

        if (isOnFridge)
        {
            ToFridge();
        }
    }

    private bool Board()
    {
        if (ingredient.Fruit == null || ingredient.Fruit == Food.Fruits.Celery)
        {
            rectTransform.anchoredPosition = originalPos;
            return false;
        }
        
        EventAggregator.OnBoardDrop.Publish(ingredient);
        TableManager.RemoveIngredientByName(name);
        ingredient = null;
        return true;
    }

    private bool Juicer()
    {
        if (ingredient.Fruit == null)
        {
            rectTransform.anchoredPosition = originalPos;
            return false;
        }
        
        EventAggregator.OnJuicerDrop.Publish(ingredient);
        TableManager.RemoveIngredientByName(name);
        ingredient = null;
        return true;
    }

    private bool Shaker()
    {
        if (ingredient.Miscellaneous == null)
        {
            rectTransform.anchoredPosition = originalPos;
            return false;
        }
        
        TableManager.AddIngredientToShaker(ingredient);
        TableManager.RemoveIngredientByName(name);
        ingredient = null;
        SceneManager.LoadScene("Bar");
        return true;
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
        switch (other.tag)
        {
            case "Board":
                isOnBoard = true;
                break;
            case "Juicer":
                isOnJuicer = true;
                break;
            case "Shaker":
                isOnShaker = true;
                break;
            case "Fridge":
                isOnFridge = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Board":
                isOnBoard = false;
                break;
            case "Juicer":
                isOnJuicer = false;
                break;
            case "Shaker":
                isOnShaker = false;
                break;
            case "Fridge":
                isOnFridge = false;
                break;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }
}
