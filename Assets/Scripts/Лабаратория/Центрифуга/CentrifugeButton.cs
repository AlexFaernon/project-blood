using UnityEngine;
using UnityEngine.SceneManagement;

public class CentrifugeButton : MonoBehaviour
{
    public void OnDrop()
    {
        BloodClass.CurrentBloodSample.IsSeparated = true;
        SceneManager.LoadScene("Centrifuge");
    }
}
