using UnityEngine;
using UnityEngine.SceneManagement;

public class JuiceGlassScript : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originalPos;
    private bool isTriggered;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
    }

    private void OnDrop(GameObject other)
    {
        if (other != gameObject) return;

        if (isTriggered)
        {
            if (TableManager.CurrentJuicerFruit != null)
            {
                TableManager.AddIngredientToShaker(new Food.Ingredient((Food.Fruits)TableManager.CurrentJuicerFruit,
                    Food.Condition.Juice));

                TableManager.CurrentJuicerFruit = null;
                SaveDataScript.SaveCurrentJuicerFruit();

                SceneManager.LoadScene("Bar");
            }
        }

        rectTransform.anchoredPosition = originalPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shaker"))
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Shaker"))
        {
            isTriggered = false;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }
}
