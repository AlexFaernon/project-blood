using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PaperScript : MonoBehaviour
{
    private TMP_Text paperText;
    private void Awake()
    {
        paperText = GetComponent<TMP_Text>();
        paperText.text = CustomersClass.CurrentCustomer.Blood;
    }
}
