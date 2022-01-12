using UnityEngine;

public class BookCornerScript : MonoBehaviour
{
    [SerializeField] private PageSide pageSide;

    private void Awake()
    {
        if (pageSide == PageSide.Left)
        {
            if (PagesManager.pageNumber <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (PagesManager.pageNumber + 1 >= Recipes.Cocktails.Count - 1)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
