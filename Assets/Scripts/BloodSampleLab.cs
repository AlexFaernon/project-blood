using UnityEngine;
using UnityEngine.UI;

public class BloodSampleLab : MonoBehaviour
{
    [SerializeField]private Sprite filledTube;
    [SerializeField] private Sprite separatedTube;
    private void Awake()
    {
        if (BloodClass.CurrentBloodSample != null)
        {
            GetComponent<Image>().sprite = BloodClass.CurrentBloodSample.IsSeparated ? separatedTube : filledTube;
        }
    }
}
