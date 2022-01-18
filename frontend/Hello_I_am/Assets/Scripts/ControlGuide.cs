using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGuide : MonoBehaviour
{
    [SerializeField]
    private GameObject Guide;

    private void Awake()
    {
        if (AppManager.instance.visited == 0)
        {
            Guide.SetActive(true);
        }
    }

    public void closeGuide()
    {
        if (AppManager.instance.visited == 0)
        {
            AppManager.instance.visited = 1;
            PlayerPrefs.SetInt("Visited", 1);
        }
        Guide.SetActive(false);
    }
}
