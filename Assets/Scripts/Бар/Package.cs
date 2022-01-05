using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Package : MonoBehaviour
{
    [SerializeField] private TMP_Text label;
    private BloodSample bloodSample;
    private bool isOnShaker;
    private bool isOnFridge;
    private RectTransform rectTransform;
    private Vector2 originalPos;
    
    private void Awake()
    {
        if (TableManager.CurrentPackage == null || TableManager.IsPackageInShaker)
        {
            gameObject.SetActive(false);
            return;
        }

        rectTransform = GetComponent<RectTransform>();
        originalPos = rectTransform.anchoredPosition;
        bloodSample = TableManager.CurrentPackage;
        EventAggregator.OnDrop.Subscribe(OnDrop);
        SetText();
    }
    
    private void SetText()
    {
        var text =
            (bloodSample.BloodGroupSticker == BloodGroup.Zero ? "0" : bloodSample.BloodGroupSticker.ToString()) +
            (bloodSample.RhSticker == Rh.Negative ? "-" : "+") + '\n' +
            (bloodSample.BloodQuality == BloodQuality.Normal ? "Норм" : "Анем");
        label.text = text;
    }

    private void OnDrop(GameObject other)
    {
        if (isOnShaker)
        {
            Debug.Log("Blood");
            TableManager.IsPackageInShaker = true;
            SceneManager.LoadScene("Bar");
            return;
        }

        if (isOnFridge)
        {
            TableManager.CurrentPackage = null;
            SceneManager.LoadScene("Bar");
            return;
        }

        rectTransform.anchoredPosition = originalPos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Fridge"))
        {
            isOnFridge = true;
            return;
        }

        if (other.CompareTag("Shaker"))
        {
            isOnShaker = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Fridge"))
        {
            isOnFridge = false;
            return;
        }

        if (other.CompareTag("Shaker"))
        {
            isOnShaker = false;
        }
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }
}
