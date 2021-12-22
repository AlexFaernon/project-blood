using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JuicerScript : MonoBehaviour
{
    [SerializeField] private GameObject Glass;
    private Image glassColor;
    private readonly Color pineapple = new Color(240f/255, 234f/255, 78f/255);
    private readonly Color lime = new Color(119f/255, 255f/255, 13f/255);
    private readonly Color orange = new Color(255f/255, 138f/255, 0);
    private readonly Color apple = new Color(255f/255, 9f/255, 9f/255);
    private readonly Color lemon = new Color(255f/255, 202f/255, 33f/255);
    private readonly Color celery = new Color(163f/255, 255f/255, 90f/255);
    void Awake()
    {
        EventAggregator.OnJuicerDrop.Subscribe(SetCurrentFruit);
        glassColor = Glass.GetComponent<Image>();
        if (TableManager.CurrentJuicerFruit != null)
        {
            JuiceFruit();
        }
    }

    private void SetCurrentFruit(Food.Ingredient ingredient)
    {
        TableManager.CurrentJuicerFruit = ingredient.Fruit;
        SaveDataScript.SaveCurrentJuicerFruit();
        
        SceneManager.LoadScene("Bar");
    }

    private void JuiceFruit()
    {
        switch (TableManager.CurrentJuicerFruit)
        {
            case Food.Fruits.Lime:
                glassColor.color = lime;
                break;
            case Food.Fruits.Lemon:
                glassColor.color = lemon;
                break;
            case Food.Fruits.Apple:
                glassColor.color = apple;
                break;
            case Food.Fruits.Orange:
                glassColor.color = orange;
                break;
            case Food.Fruits.Pineapple:
                glassColor.color = pineapple;
                break;
            case Food.Fruits.Celery:
                glassColor.color = celery;
                break;
            case null:
                glassColor.color = Color.white;
                break;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.OnJuicerDrop.Unsubscribe(SetCurrentFruit);
    }
}
