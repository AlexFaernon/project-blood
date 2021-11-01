using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public Transform prefab;

    public Transform parent;
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    public void OnClick()
    {
        Instantiate(prefab, new Vector3(), Quaternion.identity, parent);
    }
}