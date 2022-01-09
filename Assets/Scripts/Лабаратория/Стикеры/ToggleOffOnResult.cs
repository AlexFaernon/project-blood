using UnityEngine;
using UnityEngine.UI;

public class ToggleOffOnResult : MonoBehaviour
{
    private Button button; 
    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void Update()
    {
        if (BloodClass.CurrentBloodSample is { ClassificationDone: true })
        {
            button.interactable = false;
        }
    }
}
