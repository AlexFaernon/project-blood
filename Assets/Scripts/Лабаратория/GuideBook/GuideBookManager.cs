using UnityEngine;

public static class GuideBookManager
{
    private static int pageNumber;

    public static int PageNumber
    {
        get => pageNumber;

        set
        {
            if (value < Pages.Length - 1 && value >= 0)
            {
                pageNumber = value;
            }
        }
    }

    public static Sprite[] Pages;

    public static Sprite GetPage(PageSide pageSide)
    {
        return pageSide == PageSide.Left ? Pages[PageNumber] : Pages[PageNumber + 1];
    }
}