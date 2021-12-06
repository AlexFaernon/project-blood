using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiscScript : MonoBehaviour
{
    [SerializeField] private Food.Miscellaneous ingredient;
    private RectTransform rectTransform;
    private Vector2 originalPos;
    private bool isTriggered;
    
    private void Awake()
    {
        if (Food.Ingredients[ingredient] == 0)
        {
            gameObject.SetActive(false);
            return;
        }
        EventAggregator.OnDrop.Subscribe(OnDrop);
        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
    }

    private void OnDrop(GameObject other)
    {
        if (gameObject != other)
        {
            return;
        }
        
        if (isTriggered)
        {
            EventAggregator.OnMiscDrop.Publish(ingredient);
            Food.Ingredients[ingredient] -= 1;
            SceneManager.LoadScene("Fridge");
            return;
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
}
