using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Package : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
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
        text.text =
            bloodSample.BloodGroupSticker.ToString() + bloodSample.RhSticker + '\n' + bloodSample.BloodQualitySticker;
        EventAggregator.OnDrop.Subscribe(OnDrop);
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
