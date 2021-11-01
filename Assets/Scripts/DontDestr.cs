using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestr : MonoBehaviour
{
    public static DontDestr Instance;
    void Awake()
    {
        Inst();
    }

    void Inst()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Instance)
        {
            Destroy(gameObject);
        }
    }
}
