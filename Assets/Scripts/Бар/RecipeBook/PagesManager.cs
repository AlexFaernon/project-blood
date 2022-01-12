using UnityEngine;

public static class PagesManager
{
    public static int pageNumber { get; private set; }

    public static Food.Cocktail GetPage(PageSide pageSide)
    {
        return pageSide == PageSide.Left ? Recipes.Cocktails[pageNumber] : Recipes.Cocktails[pageNumber + 1];
    }

    public static void ChangePage(PageSide pageSide)
    {
        if (pageSide == PageSide.Left)
        {
            if (pageNumber - 2  >= 0)
            {
                pageNumber -= 2;
            }
        }
        else
        {
            if (pageNumber + 2 < Recipes.Cocktails.Count - 1)
            {
                pageNumber += 2;
            }
        }
        
        Debug.Log(pageNumber);
    }
}

public enum PageSide
{
    Left,
    Right
}
