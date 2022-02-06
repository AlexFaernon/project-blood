using UnityEngine;
using UnityEngine.UI;

public class CloseHelp : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => gameObject.SetActive(false));
    }
}
