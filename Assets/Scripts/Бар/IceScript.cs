using System;
using UnityEngine;

public class IceScript : MonoBehaviour
{
    private bool isTriggered;
    private void Awake()
    {
        EventAggregator.OnDrop.Subscribe(OnDrop);
    }

    private void OnDrop(GameObject other)
    {
        if (gameObject != other || !isTriggered) return;
        
        TableManager.AddIngredientToShaker(new Food.Ingredient(Food.Miscellaneous.Ice));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shaker"))
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
