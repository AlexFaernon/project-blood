using UnityEngine;
using UnityEngine.UI;

public class CheckButton : MonoBehaviour
{
    [SerializeField] private GameObject confirmScreen;
    private Button button;

    public void OnClick()
    {
        confirmScreen.SetActive(true);
    }
    private void Awake()
    {
        button = GetComponent<Button>();
        button.interactable = false;
    }

    private void Update()
    {
        if (BloodClass.CurrentBloodSample == null)
            return;
        
        if (BloodClass.CurrentBloodSample.IsClassified)
        {
            if (!button.interactable)
                button.interactable = true;
        }
    }
}
