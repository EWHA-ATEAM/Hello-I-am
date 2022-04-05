using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polarbear : MonoBehaviour
{
    private Animator polarbear;
    public float gravity;
    private bool Speed1 = true;
    private bool Speed2 = false;
    private bool Speed3 = false;


    // Start is called before the first frame update
    void Start()
    {
        polarbear = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        /*
        if (polarbear.GetCurrentAnimatorStateInfo(0).IsName("idle2"))
        {
            polarbear.SetBool("trotting", false);
            polarbear.SetBool("walk", false);
            polarbear.SetBool("running", false);
            polarbear.SetBool("wakeup", false);
            polarbear.SetBool("sniffs", false);
            polarbear.SetBool("sniffing", false);
            polarbear.SetBool("eat", false);
            polarbear.SetBool("hit", false);
        }
        if (polarbear.GetCurrentAnimatorStateInfo(0).IsName("roar"))
        {
            polarbear.SetBool("doubleswipe", false);
            polarbear.SetBool("swipeleft", false);
            polarbear.SetBool("swiperight",false);
            polarbear.SetBool("hit", false);
        }
        if (polarbear.GetCurrentAnimatorStateInfo(0).IsName("sleep"))
        {
            polarbear.SetBool("lay", false);
        }
        */
        if (Input.GetKeyDown(KeyCode.E))
        {
            polarbear.SetBool("idle2", false);
            polarbear.SetBool("eat", true);
        }
         if (Input.GetKeyDown(KeyCode.Space))
        {
            polarbear.SetBool("lay", true);
            polarbear.SetBool("idle2", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            polarbear.SetBool("sleep", false);
            polarbear.SetBool("wakeup", true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            polarbear.SetBool("backward", true);
            polarbear.SetBool("idle2", false);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            polarbear.SetBool("idle2", true);
            polarbear.SetBool("backward", false);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            polarbear.SetBool("idle2", false);
            polarbear.SetBool("sniffs", true);
        }
        if ((Input.GetKeyDown(KeyCode.R))&&(Speed1==true))
        {
            polarbear.SetBool("sniffing", true);
            polarbear.SetBool("walk", false);
        }
        if ((Input.GetKeyUp(KeyCode.R)) && (Speed1 == true))
        {
            polarbear.SetBool("walk", true);
            polarbear.SetBool("sniffing", false);
        }
        if ((Input.GetKeyDown(KeyCode.L)) && (Speed1 == true))
        {
            polarbear.SetBool("look", true);
            polarbear.SetBool("walk", false);
        }
        if ((Input.GetKeyUp(KeyCode.L)) && (Speed1 == true))
        {
            polarbear.SetBool("walk", true);
            polarbear.SetBool("look", false);
        }
        if ((Input.GetKeyDown(KeyCode.W))&&(Speed1==true))
        {
            polarbear.SetBool("walk", true);
            polarbear.SetBool("idle2", false);
            polarbear.SetBool("roar", false);
        }
        if ((Input.GetKeyUp(KeyCode.W))&&(Speed1==true))
        {
            polarbear.SetBool("idle2", true);
            polarbear.SetBool("walk", false);
        }
        if ((Input.GetKeyDown(KeyCode.A)) && (Speed1 == true))
        {
            polarbear.SetBool("walkleft", true);
            polarbear.SetBool("walk", false);
        }
        if ((Input.GetKeyUp(KeyCode.A)) && (Speed1 == true))
        {
            polarbear.SetBool("walkleft", false);
            polarbear.SetBool("walk", true);
        }
        if ((Input.GetKeyDown(KeyCode.D)) && (Speed1 == true))
        {
            polarbear.SetBool("walkright", true);
            polarbear.SetBool("walk", false);
        }
        if ((Input.GetKeyUp(KeyCode.D)) && (Speed1 == true))
        {
            polarbear.SetBool("walkright", false);
            polarbear.SetBool("walk", true);
        }
        if ((Input.GetKeyDown(KeyCode.W)) && (Speed2 == true))
        {
            polarbear.SetBool("trotting", true);
            polarbear.SetBool("idle2", false);
            polarbear.SetBool("roar", false);
        }
        if ((Input.GetKeyUp(KeyCode.W)) && (Speed2 == true))
        {
            polarbear.SetBool("idle2", true);
            polarbear.SetBool("trotting", false);

        }
        if ((Input.GetKeyDown(KeyCode.A))&& (Speed2 == true))
        {
            polarbear.SetBool("trotleft", true);
            polarbear.SetBool("trotting", false);
        }
        if ((Input.GetKeyUp(KeyCode.A)) && (Speed2 == true))
        {
            polarbear.SetBool("trotleft", false);
            polarbear.SetBool("trotting", true);
        }
        if ((Input.GetKeyDown(KeyCode.D)) && (Speed2 == true))
        {
            polarbear.SetBool("trotright", true);
            polarbear.SetBool("trotting", false);
        }
        if ((Input.GetKeyUp(KeyCode.D)) && (Speed2 == true))
        {
            polarbear.SetBool("trotright", false);
            polarbear.SetBool("trotting", true);
        }
        if ((Input.GetKeyDown(KeyCode.W)) && (Speed3 == true))
        {
            polarbear.SetBool("running", true);
            polarbear.SetBool("idle2", false);
            polarbear.SetBool("roar", false);
        }
        if ((Input.GetKeyUp(KeyCode.W)) && (Speed3 == true))
        {
            polarbear.SetBool("idle2", true);
            polarbear.SetBool("running", false);
        }
        if ((Input.GetKeyDown(KeyCode.A)) && (Speed3 == true))
        {
            polarbear.SetBool("runleft", true);
            polarbear.SetBool("running", false);
        }
        if ((Input.GetKeyUp(KeyCode.A)) && (Speed3 == true))
        {
            polarbear.SetBool("running", true);
            polarbear.SetBool("runleft", false);
        }
        if ((Input.GetKeyDown(KeyCode.D)) && (Speed3 == true))
        {
            polarbear.SetBool("runright", true);
            polarbear.SetBool("running", false);
        }
        if ((Input.GetKeyUp(KeyCode.D)) && (Speed3 == true))
        {
            polarbear.SetBool("running", true);
            polarbear.SetBool("runright", false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            polarbear.SetBool("idle2", false);
            polarbear.SetBool("roar", true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            polarbear.SetBool("doubleswipe", true);
            polarbear.SetBool("roar", false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            polarbear.SetBool("swipeleft", true);
            polarbear.SetBool("roar", false);
        }
        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            polarbear.SetBool("swiperight", true);
            polarbear.SetBool("roar", false);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            polarbear.SetBool("hit", true);
            polarbear.SetBool("idle2", false);
            polarbear.SetBool("roar", false);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            polarbear.SetBool("die", true);
            polarbear.SetBool("roar", false);
        }
    }

    public void onCilckMotion()
    {
        polarbear.SetTrigger("heartTrigger");
    }
}

