using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnClickStatistics : MonoBehaviour
{
    public void LoadNewDay()
    {
        SceneManager.LoadScene("DayStart");
    }
    public void Leave()
    {
        throw new NotImplementedException();
    }
}
