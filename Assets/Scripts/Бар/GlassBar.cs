using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlassBar : MonoBehaviour
{
    private Triggers triggers;
    
    private void Awake()
    {
        if (!TableManager.IsGlassActive)
        {
            gameObject.SetActive(false);
        }
        
        EventAggregator.MakeCocktail.Subscribe(OnCocktail);
        EventAggregator.OnDrop.Subscribe(OnDrop);
        ChangeSprite();
    }

    private void OnDrop(GameObject other)
    {
        if (other != gameObject) return;

        switch (triggers)
        {
            case Triggers.Hole:
                TableManager.ClearCocktail();
                SceneManager.LoadScene("Bar");
                break;
            case Triggers.Customer:
                EventAggregator.SellCocktail.Publish(TableManager.CurrentCocktail);
                TableManager.ClearCocktail();
                TableManager.IsGlassActive = false;
                TableManager.RemovePackage();
                SceneManager.LoadScene("Bar");
                break;
        }
    }
    
    private void OnCocktail(Food.Cocktail cocktail)
    {
        TableManager.CurrentCocktail = cocktail;
        SceneManager.LoadScene("Bar");
    }

    private void ChangeSprite()
    {
        if (TableManager.CurrentCocktail == null) return;
        
        if (TableManager.CurrentCocktail.IsShitted)
        {
            GetComponent<Image>().color = Color.black;
            return;
        }
        
        GetComponent<Image>().color = Color.red;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hole"))
        {
            triggers = Triggers.Hole;
            return;
        }

        if (other.CompareTag("Customer"))
        {
            triggers = Triggers.Customer;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hole") || other.CompareTag("Customer"))
        {
            triggers = Triggers.None;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.MakeCocktail.Unsubscribe(OnCocktail);
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }

    private enum Triggers
    {
        None,
        Hole,
        Customer
    }
}
