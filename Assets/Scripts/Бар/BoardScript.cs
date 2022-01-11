using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoardScript : MonoBehaviour
{
    [SerializeField] private GameObject pieces;
    [SerializeField] private GameObject peel;
    private Image piecesImage;
    private Image peelImage;
    public static readonly Color pineapple = new Color(240f/255, 234f/255, 78f/255);
    public static readonly Color lime = new Color(119f/255, 255f/255, 13f/255);
    public static readonly Color orange = new Color(255f/255, 138f/255, 0);
    public static readonly Color apple = new Color(255f/255, 9f/255, 9f/255);
    public static readonly Color lemon = new Color(255f/255, 202f/255, 33f/255);

    private void Awake()
    {
        if (!TableManager.IsPeelActive && !TableManager.IsPiecesActive)
        {
            TableManager.CurrentBoardFruit = null;
            SaveDataScript.SaveCurrentBoardFruit();
        }
        EventAggregator.OnBoardDrop.Subscribe(SetCurrentFruit);
        
        piecesImage = pieces.GetComponent<Image>();
        peelImage = peel.GetComponent<Image>();
        if (TableManager.CurrentBoardFruit != null)
        {
            ChangeColor();
        }
    }

    private void SetCurrentFruit(Food.Ingredient ingredient)
    {
        TableManager.CurrentBoardFruit = ingredient.Fruit;
        SaveDataScript.SaveCurrentBoardFruit();
        
        TableManager.IsPeelActive = true;
        SaveDataScript.SaveIsPeelActive();
        
        TableManager.IsPiecesActive = true;
        SaveDataScript.SaveIsPiecesActive();
        
        SceneManager.LoadScene("Bar");
    }

    private void ChangeColor()
    {
        switch (TableManager.CurrentBoardFruit)
        {
            case Food.Fruits.Lime:
                peelImage.color = lime;
                piecesImage.color = lime;
                break;
            case Food.Fruits.Lemon:
                peelImage.color = lemon;
                piecesImage.color = lemon;
                break;
            case Food.Fruits.Apple:
                peelImage.color = apple;
                piecesImage.color = apple;
                break;
            case Food.Fruits.Orange:
                peelImage.color = orange;
                piecesImage.color = orange;
                break;
            case Food.Fruits.Pineapple:
                peel.SetActive(false);
                TableManager.IsPeelActive = false;
                SaveDataScript.SaveIsPeelActive();
                piecesImage.color = pineapple;
                break;
        }
    }

    

    private void OnDestroy()
    {
        EventAggregator.OnBoardDrop.Unsubscribe(SetCurrentFruit);
    }
}
