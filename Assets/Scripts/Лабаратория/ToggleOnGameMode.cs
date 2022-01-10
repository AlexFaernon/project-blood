using UnityEngine;

public class ToggleOnGameMode : MonoBehaviour
{
    [SerializeField] private GameMode gameMode;
    
    private void Awake()
    {
        if (CurrentGameMode.GameMode == gameMode)
        {
            gameObject.SetActive(false);
        }
    }
}
