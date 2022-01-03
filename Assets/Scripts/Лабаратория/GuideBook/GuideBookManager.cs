using UnityEngine.SceneManagement;

public static class GuideBookManager
{
    public static int PageNumber; //0-2 первый и второй разделы

    public static GuideBookTemplate GuideBookTemplate
    {
        get
        {
            if (PageNumber >= 0 && PageNumber < 4)
            {
                return GuideBookTemplate.TextOnly;
            }

            return GuideBookTemplate.PictureText;
        }
    }
}

public static class GuideBookText
{
    public static string[] Pages;
    public static string GetPage => Pages[GuideBookManager.PageNumber];
}

public enum GuideBookTemplate
{
    TextOnly,
    PictureText
}