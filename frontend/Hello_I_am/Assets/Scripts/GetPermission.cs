using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;



public class GetPermission : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("permissionCheck");
    }

    IEnumerator permissionCheck()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.Camera))
        {
            Permission.RequestUserPermission(Permission.Camera);
            yield return new WaitForSeconds(0.1f);
            yield return new WaitUntil(() => Application.isFocused == true);

            if (!Permission.HasUserAuthorizedPermission(Permission.Microphone))
            {
                Permission.RequestUserPermission(Permission.Microphone);
            }
        }
    }
}