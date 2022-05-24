using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextText : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject square;
    public GameObject button1;
    public GameObject button2;

    public void nextText()
    {
        bool is_1_Active = text1.activeSelf;
        bool is_2_Active = text2.activeSelf;
        bool is_3_Active = text3.activeSelf;
        bool is_sq_Active = square.activeSelf;
        bool is_butt1_Active = button1.activeSelf;
        bool is_butt2_Active = button2.activeSelf;

        if (is_1_Active)
        {
            text1.SetActive(!is_1_Active);
            text2.SetActive(!is_2_Active);
            text3.SetActive(!is_3_Active);
            square.SetActive(!is_sq_Active);
            button1.SetActive(!is_butt1_Active);
            button2.SetActive(!is_butt2_Active);
        }
    }
}
