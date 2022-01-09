using UnityEngine;

public class ToggleOnTraining : MonoBehaviour
{
    private void Awake()
    {
        if (CurrentGameMode.GameMode == GameMode.Training)
        {
            gameObject.SetActive(false);
        }
    }
}
