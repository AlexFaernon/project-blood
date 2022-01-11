using TMPro;
using UnityEngine;

public class PaperScript : MonoBehaviour
{
    private TMP_Text paperText;
    private void Start()
    {
        paperText = GetComponent<TMP_Text>();
        paperText.text = CustomersClass.CurrentCustomer.Blood;
    }
}
