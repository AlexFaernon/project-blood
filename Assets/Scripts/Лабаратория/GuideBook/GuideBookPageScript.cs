using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GuideBookPageScript : MonoBehaviour
{
    [SerializeField] private PageSide pageSide;
    [SerializeField] private Image page;

    private void Awake()
    {
        page.sprite = GuideBookManager.GetPage(pageSide);
    }

    public void OnClick()
    {
        if (pageSide == PageSide.Left)
        {
            GuideBookManager.PageNumber -= 2;
        }
        else
        {
            GuideBookManager.PageNumber += 2;
        }

        SceneManager.LoadScene("GuideBook");
    }
}
