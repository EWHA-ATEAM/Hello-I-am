using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Camera_Panel;
    public GameObject Speech_Panel;
    public GameObject Back_Panel;

    public void OpenPanel()
    {
        bool is_camera_Active = Camera_Panel.activeSelf;
        bool is_speech_Active = Speech_Panel.activeSelf;
        bool is_back_Active = Back_Panel.activeSelf;


        if (is_camera_Active)
        {
            Debug.Log("카메라 팬넬 ㅇㅋ");
            Camera_Panel.SetActive(!is_camera_Active);
            Speech_Panel.SetActive(!is_speech_Active);
        }
        else if (is_speech_Active)
        {
            Debug.Log("스피치 팬넬 ㅇㅋ");
            Speech_Panel.SetActive(!is_speech_Active);
            Back_Panel.SetActive(!is_back_Active);
        }
    }
}
