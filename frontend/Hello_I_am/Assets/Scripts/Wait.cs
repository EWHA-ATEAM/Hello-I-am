using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : MonoBehaviour
{
    public float timer;
    public int waitingTime;
    public GameObject hand1;
    public GameObject hand2;
    public GameObject hand3;
    public GameObject flash;
    public GameObject button;

    /*
    public void Start()
    {
        timer = 0;
        waitingTime = 2;
    }
    */

    public void Update()
    {
        timer += Time.deltaTime;

        if (hand1.activeSelf == true)
        {
            if (timer > waitingTime)
            {
                //Action
                flash.SetActive(true);
                hand1.SetActive(false);
                hand2.SetActive(true);
                timer = 0;
            }
        }

        else if (hand2.activeSelf == true)
        {
            if (timer > waitingTime)
            {
                //Action
                flash.SetActive(true);
                hand2.SetActive(false);
                hand3.SetActive(true);
                timer = 0;
            }
        }

        else if (hand3.activeSelf == true)
        {
            if (timer > waitingTime)
            {
                //Action
                flash.SetActive(true);
                hand3.SetActive(false);
                button.SetActive(true);
                timer = 0;
            }
        }

        
    }
}
