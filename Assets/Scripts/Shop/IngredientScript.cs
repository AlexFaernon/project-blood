using UnityEngine;
using UnityEngine.SceneManagement;

public class IngredientScript : MonoBehaviour
{
    [SerializeField] private Type type;
    [SerializeField] private Food.Fruits fruits;
    [SerializeField] private Food.Miscellaneous miscellaneous;
    [SerializeField] private int price;
    private bool isTriggered;
    private RectTransform rectTransform;
    private Vector2 originalPos;

    private void Awake()
    {
        EventAggregator.OnDrop.Subscribe(OnDrop);
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
    }

    private void OnDrop(GameObject other)
    {
        if (other != gameObject)
        {
            return;
        }
        
        if (isTriggered)
        {
            if (Resources.BuyIngredient(price))
            {
                if (type == Type.Fruit)
                {
                    Food.Ingredients[fruits] += 1;
                }
                else
                {
                    Food.Ingredients[miscellaneous] += 1;
                }
                SaveDataScript.SaveIngredients();
            }

            SceneManager.LoadScene("Shop");
        }
        rectTransform.anchoredPosition = originalPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }
    
    private enum Type
    {
        Miscellaneous,
        Fruit
    }
}
