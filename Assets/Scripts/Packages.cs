using TMPro;
using UnityEngine;

public class Packages : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private void Awake()
    {
        text.text = Recources.Samples.ToString();
    }
}
