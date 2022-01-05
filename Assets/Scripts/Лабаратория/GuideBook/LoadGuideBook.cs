using UnityEngine;

public class LoadGuideBook : MonoBehaviour
{
    private void Awake()
    {
        GuideBookManager.Pages = UnityEngine.Resources.LoadAll<Sprite>("GuideBook");
    }
}
