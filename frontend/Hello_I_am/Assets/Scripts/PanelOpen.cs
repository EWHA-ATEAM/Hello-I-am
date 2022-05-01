using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PanelOpen : MonoBehaviour
{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    // public GameObject Panel3;
    public void OpenPanel()
    {
        bool is_1_Active = Panel1.activeSelf;
        bool is_2_Active = Panel2.activeSelf;
        bool is_3_Active = Panel3.activeSelf;

        if(is_1_Active)
        {
            Panel1.SetActive(!is_1_Active);
            Panel2.SetActive(!is_2_Active);
            Panel3.SetActive(is_3_Active);
        }
        else if(is_2_Active)
        {
            Panel1.SetActive(is_1_Active);
            Panel2.SetActive(!is_2_Active);
            Panel3.SetActive(!is_3_Active);
        }
        else if (is_3_Active)
        {
            Panel1.SetActive(!is_1_Active);
            Panel2.SetActive(is_2_Active);
            Panel3.SetActive(!is_3_Active);
        }
    }
}
