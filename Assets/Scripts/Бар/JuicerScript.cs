using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JuicerScript : MonoBehaviour
{
    [SerializeField] private Image glassColor;
    private readonly Color pineapple = new Color(240f/255, 234f/255, 78f/255, 0.5f);
    private readonly Color lime = new Color(119f/255, 255f/255, 13f/255, 0.5f);
    private readonly Color orange = new Color(255f/255, 138f/255, 0, 0.5f);
    private readonly Color apple = new Color(255f/255, 9f/255, 9f/255, 0.5f);
    private readonly Color lemon = new Color(255f/255, 202f/255, 33f/255, 0.5f);
    private readonly Color celery = new Color(163f/255, 255f/255, 90f/255, 0.5f);
    void Awake()
    {
        EventAggregator.OnJuicerDrop.Subscribe(SetCurrentFruit);
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
        glassColor.color = TableManager.CurrentJuicerFruit switch
        {
            Food.Fruits.Lime => lime,
            Food.Fruits.Lemon => lemon,
            Food.Fruits.Apple => apple,
            Food.Fruits.Orange => orange,
            Food.Fruits.Pineapple => pineapple,
            Food.Fruits.Celery => celery,
            null => Color.white,
            _ => glassColor.color
        };
    }

    private void OnDestroy()
    {
        EventAggregator.OnJuicerDrop.Unsubscribe(SetCurrentFruit);
    }
}
