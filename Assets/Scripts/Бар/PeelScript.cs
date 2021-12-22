using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PeelScript : MonoBehaviour
{
    private RectTransform rectTransform;
    private Vector2 originalPos;
    private bool isTriggered;
    private void Awake()
    {
        if (!TableManager.IsPeelActive)
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
            TableManager.AddIngredientToShaker(new Food.Ingredient((Food.Fruits)TableManager.CurrentBoardFruit,
                Food.Condition.Peel));
            
            TableManager.IsPeelActive = false;
            SaveDataScript.SaveIsPeelActive();
            
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
