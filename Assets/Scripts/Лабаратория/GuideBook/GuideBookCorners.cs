using UnityEngine;

public class GuideBookCorners : MonoBehaviour
{
    [SerializeField] private PageSide pageSide;

    private void Awake()
    {
        if (pageSide == PageSide.Left)
        {
            if (GuideBookManager.PageNumber <= 0)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (GuideBookManager.PageNumber + 1 >= GuideBookManager.Pages.Length - 1)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
