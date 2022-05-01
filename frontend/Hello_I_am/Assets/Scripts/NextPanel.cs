using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPanel : MonoBehaviour
{
    public GameObject panel1;
    public GameObject panel2;

    public void nextPanel()
    {
        bool is_1_Active = panel1.activeSelf;
        bool is_2_Active = panel2.activeSelf;
        
        if(is_1_Active)
        {
            panel1.SetActive(!is_1_Active);
            panel2.SetActive(!is_2_Active);
        }
    }
}
