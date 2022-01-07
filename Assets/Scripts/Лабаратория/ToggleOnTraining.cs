using UnityEngine;

public class ToggleOnTraining : MonoBehaviour
{
    private void Awake()
    {
        if (GameMode.IsTraining)
        {
            gameObject.SetActive(false);
        }
    }
}
