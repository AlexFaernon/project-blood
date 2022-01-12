using UnityEngine;
using UnityEngine.UI;

public class BoxSpriteToggle : MonoBehaviour
{
    [SerializeField] private Sprite emptyBox;
    private void Awake()
    {
        if (Shop.ToggleIngredients)
        {
            GetComponent<Image>().sprite = emptyBox;
        }
    }
}
