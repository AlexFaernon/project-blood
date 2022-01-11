using TMPro;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        text.text = Resources.Money.ToString();
    }
}
