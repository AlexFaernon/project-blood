using UnityEngine;
using UnityEngine.UI;

public class HelpButton : MonoBehaviour
{
    [SerializeField] private GameObject helpScreen;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => helpScreen.SetActive(true));
    }
}
