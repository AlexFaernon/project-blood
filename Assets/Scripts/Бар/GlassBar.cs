using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlassBar : MonoBehaviour
{
    public Triggers triggers;
    
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
        
        if (TableManager.CurrentCocktail.isShitted)
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
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Hole"))
        {
            triggers = Triggers.None;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.MakeCocktail.Unsubscribe(OnCocktail);
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }
    
    public enum Triggers
    {
        None,
        Hole,
        Customer
    }
}
