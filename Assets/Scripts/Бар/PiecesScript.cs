using UnityEngine;
using UnityEngine.SceneManagement;

public class PiecesScript : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originalPos;
    private bool isTriggered;
    private void Awake()
    {
        if (!TableManager.IsPiecesActive)
        {
            gameObject.SetActive(false);
        }
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.OnDrop.Subscribe(OnDrop);
    }

    private void OnDrop(GameObject other)
    {
        if (other != gameObject) return;

        if (isTriggered)
        {
            Debug.Log(TableManager.CurrentBoardFruit + "Pieces");
            TableManager.AddIngredientToShaker(new Food.Ingredient((Food.Fruits)TableManager.CurrentBoardFruit,
                Food.Condition.Pieces));
            TableManager.IsPiecesActive = false;
            SceneManager.LoadScene("Bar");
            return;
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
