using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;



public class CameraPermission : MonoBehaviour
{
    void Start()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))

        {
            Permission.RequestUserPermission(Permission.Camera);
        }
    }
}