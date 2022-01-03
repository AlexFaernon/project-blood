using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideBookPageScript : MonoBehaviour
{
    [SerializeField] private PageSide pageSide;
    [SerializeField] private GameObject textOnly;

    private void Awake()
    {
        if (GuideBookManager.GuideBookTemplate == GuideBookTemplate.TextOnly)
        {
            textOnly.SetActive(true);
        }
    }

    public void OnClick()
    {
        if (pageSide == PageSide.Left)
        {
            GuideBookManager.PageNumber -= 1;
        }
        else
        {
            GuideBookManager.PageNumber += 1;
        }

        SceneManager.LoadScene("GuideBook");
    }
}
