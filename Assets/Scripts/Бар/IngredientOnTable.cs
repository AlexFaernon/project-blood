using System;
using UnityEngine;
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
    private bool isTriggered;

    private void Awake()
    {
        ingredient = TableManager.GetIngredientByNumber(name);

        if (ingredient == null)
        {
            gameObject.SetActive(false);
            return;
        }
        
        ChangeSprite(ingredient);
    }

    private void ChangeSprite(Food.Ingredient ingredient)
    {
        var image = GetComponent<Image>();
        if (ingredient.Fruit != null)
        {
            switch (ingredient.Fruit)
            {
                case Food.Fruits.Apple:
                    image.sprite = apple;
                    break;
                case Food.Fruits.Pineapple:
                    image.sprite = pineapple;
                    break;
                case Food.Fruits.Lemon:
                    image.sprite = lemon;
                    break;
                case Food.Fruits.Lime:
                    image.sprite = lime;
                    break;
                case Food.Fruits.Orange:
                    image.sprite = orange;
                    break;
            }
        }
        else
        {
            switch (ingredient.Miscellaneous)
            {
                case Food.Miscellaneous.Pepper:
                    image.sprite = pepper;
                    break;
                case Food.Miscellaneous.Honey:
                    image.sprite = honey;
                    break;
                case Food.Miscellaneous.Coffee:
                    image.sprite = coffee;
                    break;
                case Food.Miscellaneous.Carnation:
                    image.sprite = carnation;
                    break;
                case Food.Miscellaneous.Celery:
                    image.sprite = celery;
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
    }
}
