using System;
using TMPro;
using UnityEngine;

public class ChangeButtonText : MonoBehaviour
{
    [SerializeField] private TMP_Text tmpText;

    private void Awake()
    {
        if (CurrentGameMode.GameMode == GameMode.Game)
        {
            tmpText.text = "Новый день";
        }
    }
}
