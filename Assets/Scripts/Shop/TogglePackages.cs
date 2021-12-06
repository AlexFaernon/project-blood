using System;
using UnityEngine;

public class TogglePackages : MonoBehaviour
{
    [SerializeField] private GameObject packages;
    private void Awake()
    {
        if (Shop.ToggleIngredients) return;
        packages.SetActive(true);
        gameObject.SetActive(false);
    }
}
