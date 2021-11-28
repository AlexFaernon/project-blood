using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Package : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private BloodSample bloodSample;
    private bool isTriggered;
    
    private void Awake()
    {
        if (Food.CurrentPackage == null)
        {
            gameObject.SetActive(false);
            return;
        }

        bloodSample = Food.CurrentPackage;
        text.text =
            bloodSample.BloodGroupSticker.ToString() + bloodSample.RhSticker + '\n' + bloodSample.QualitySticker;
        EventAggregator.OnDrop.Subscribe(OnDrop);
    }

    private void OnDrop(GameObject other)
    {
        if (other != gameObject || !isTriggered)
        {
            return;
        }

        Food.CurrentPackage = null;
        SceneManager.LoadScene("Bar");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isTriggered = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        isTriggered = false;
    }

    private void OnDestroy()
    {
        EventAggregator.OnDrop.Unsubscribe(OnDrop);
    }
}
