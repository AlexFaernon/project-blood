using TMPro;
using UnityEngine;

public class TextOnlyScript : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;
    private void Awake()
    {
        textField.text = GuideBookText.GetPage;
    }
}
