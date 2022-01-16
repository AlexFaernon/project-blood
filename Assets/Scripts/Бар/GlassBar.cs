using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlassBar : MonoBehaviour
{
    [SerializeField] private Image cocktailColor;
    [SerializeField] private Image pieces;
    [SerializeField] private Image peel;
    [SerializeField] private Sprite lemonPeel;
    [SerializeField] private Sprite limePeel;
    [SerializeField] private Sprite orangePeel;
    [SerializeField] private Sprite applePeel;
    [SerializeField] private Sprite lemonPieces;
    [SerializeField] private Sprite limePieces;
    [SerializeField] private Sprite orangePieces;
    [SerializeField] private Sprite applePieces;
    [SerializeField] private Sprite pineapplePieces;
    private Triggers triggers;
    private RectTransform rectTransform;
    private Vector2 originalPos;
    
    private void Awake()
    {
        if (!TableManager.IsGlassActive)
        {
            gameObject.SetActive(false);
        }

        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        EventAggregator.MakeCocktail.Subscribe(OnCocktail);
        EventAggregator.OnDrop.Subscribe(OnDrop);
        ChangeSprite();
    }

    private void OnDrop(GameObject other)
    {
        if (other != gameObject) return;
        
        StartCoroutine(OnDropCoroutine());
    }
    
    private IEnumerator OnDropCoroutine()
    {
        switch (triggers)
        {
            case Triggers.Hole:
                TableManager.ClearCocktail();
                SceneManager.LoadScene("Bar");
                yield break;
            case Triggers.Customer:
                if (!TableManager.IsPackageInShaker)
                {
                    Debug.Log("Blood doko???");
                    rectTransform.anchoredPosition = originalPos;
                    yield break;
                }
                EventAggregator.SellCocktail.Publish(TableManager.CurrentCocktail);
                TableManager.ClearCocktail();
                
                TableManager.IsGlassActive = false;
                SaveDataScript.SaveIsGlassActive();
                
                TableManager.RemovePackage();
                
                cocktailColor.gameObject.SetActive(false);
                peel.gameObject.SetActive(false);
                pieces.gameObject.SetActive(false);
                Destroy(GetComponent<Image>());
                
                yield return new WaitForSeconds(2);

                SceneManager.LoadScene("Bar");
                yield break;
            default:
                rectTransform.anchoredPosition = originalPos;
                break;
        }
    }
    
    private void OnCocktail(Food.Cocktail cocktail)
    {
        TableManager.CurrentCocktail = cocktail;
        SaveDataScript.SaveCurrentCocktail();
        SceneManager.LoadScene("Bar");
    }

    private void ChangeSprite()
    {
        if (TableManager.CurrentCocktail == null) return;
        
        cocktailColor.gameObject.SetActive(true);
        cocktailColor.color = TableManager.CurrentCocktail.GetColor();

        if (TableManager.CurrentCocktail.IsShitted || TableManager.CurrentCocktail.PureBlood)
        {
            return;
        }
        
        foreach (var ingredient in TableManager.CurrentCocktail.Ingredients)
        {
            if (ingredient.Fruit != null)
            {
                if (ingredient.Condition == Food.Condition.Peel)
                {
                    peel.gameObject.SetActive(true);
                }
                else if (ingredient.Condition == Food.Condition.Pieces)
                {
                    pieces.gameObject.SetActive(true);
                }
                
                switch (ingredient.Fruit)
                {
                    case Food.Fruits.Lime:
                        peel.sprite = limePeel;
                        pieces.sprite = limePieces;
                        break;
                    case Food.Fruits.Lemon:
                        peel.sprite = lemonPeel;
                        pieces.sprite = lemonPieces;
                        break;
                    case Food.Fruits.Apple:
                        peel.sprite = applePeel;
                        pieces.sprite = applePieces;
                        break;
                    case Food.Fruits.Orange:
                        peel.sprite = orangePeel;
                        pieces.sprite = orangePieces;
                        break;
                    case Food.Fruits.Pineapple:
                        pieces.sprite = pineapplePieces;
                        break;
                }
            }
        }
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
