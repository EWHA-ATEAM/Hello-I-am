using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Redpanda : MonoBehaviour
{
    private Animator redpanda;
    private bool CapsLockOn = false;
    // Start is called before the first frame update
    void Start()
    {
        redpanda = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.CapsLock))
        {
            CapsLockOn = !CapsLockOn;
        }
        if (redpanda.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            redpanda.SetBool("scratch", false);
            redpanda.SetBool("jumpinplace", false);
            redpanda.SetBool("idletoseat", false);
            redpanda.SetBool("lietoseat", false);
            redpanda.SetBool("lietoseat", false);
            redpanda.SetBool("run", false);
            redpanda.SetBool("runattack", false);
            redpanda.SetBool("dig", false);
            redpanda.SetBool("eat", false);
            redpanda.SetBool("attack", false);
            redpanda.SetBool("walkleft", false);
            redpanda.SetBool("walkright", false);
            redpanda.SetBool("walk", false);
            redpanda.SetBool("sneak", false);
            redpanda.SetBool("sneakleft", false);
            redpanda.SetBool("sneakright", false);
            redpanda.SetBool("trot", false);
            redpanda.SetBool("trotleft", false);
            redpanda.SetBool("trotright", false);
        }
        if (redpanda.GetCurrentAnimatorStateInfo(0).IsName("stand"))
        {
            redpanda.SetBool("idletostand", false);
            redpanda.SetBool("standtoidle", false);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("jump", false);
            redpanda.SetBool("sneak", false);
        }
        if (redpanda.GetCurrentAnimatorStateInfo(0).IsName("run"))
        {
            redpanda.SetBool("idletostand", false);
            redpanda.SetBool("standtoidle", false);
            redpanda.SetBool("idle", false);
        }
        if (redpanda.GetCurrentAnimatorStateInfo(0).IsName("trot"))
        {
            redpanda.SetBool("scratch", false);
        }
        if (redpanda.GetCurrentAnimatorStateInfo(0).IsName("scratch"))
        {
            redpanda.SetBool("run", false);
        }
        if (redpanda.GetCurrentAnimatorStateInfo(0).IsName("walk"))
        {
        }
        if (redpanda.GetCurrentAnimatorStateInfo(0).IsName("jump"))
        {
            redpanda.SetBool("runleft", false);
            redpanda.SetBool("runright", false);
        }
        if (redpanda.GetCurrentAnimatorStateInfo(0).IsName("seat"))
        {
            redpanda.SetBool("seattolie", false);
            redpanda.SetBool("seattoidle", false);
        }
        if (redpanda.GetCurrentAnimatorStateInfo(0).IsName("lie"))
        {
            redpanda.SetBool("lietosleep", false);
            redpanda.SetBool("lietoseat", false);
        }
        if (redpanda.GetCurrentAnimatorStateInfo(0).IsName("sleep"))
        {
            redpanda.SetBool("sleeptolie", false);
            redpanda.SetBool("seattolie", false);
            redpanda.SetBool("lietosleep", false);
            redpanda.SetBool("idletoseat", false);
        }
        if (redpanda.GetCurrentAnimatorStateInfo(0).IsName("growl"))
        {
            redpanda.SetBool("hit", false);
        }
        if ((Input.GetKeyUp(KeyCode.W))||(Input.GetKeyUp(KeyCode.S))||(Input.GetKeyUp(KeyCode.D))||(Input.GetKeyUp(KeyCode.A))||(Input.GetKeyUp(KeyCode.R))
            ||(Input.GetKeyUp(KeyCode.E))||(Input.GetKeyUp(KeyCode.F))||(Input.GetKeyUp(KeyCode.Space))||(Input.GetKeyUp(KeyCode.C)))
        {
            redpanda.SetBool("idle", true);
            redpanda.SetBool("walk", false);
            redpanda.SetBool("lookright", false);
            redpanda.SetBool("lookleft", false);
            redpanda.SetBool("scratch", false);
            redpanda.SetBool("backward", false);
            redpanda.SetBool("standlookleft", false);
            redpanda.SetBool("standlookright", false);
            redpanda.SetBool("trot", false);
            redpanda.SetBool("eat", false);
            redpanda.SetBool("attack", false);
            redpanda.SetBool("jump", false);
            redpanda.SetBool("dig", false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            redpanda.SetBool("walk", true);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("growl", false);
        }
        if ((Input.GetKeyDown(KeyCode.W)) && (CapsLockOn == true))
        {
            redpanda.SetBool("idle", false);
            redpanda.SetBool("trot", true);
            redpanda.SetBool("walk", false);
            redpanda.SetBool("run", false);
            redpanda.SetBool("growl", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            redpanda.SetBool("backward", true);
            redpanda.SetBool("idle", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            redpanda.SetBool("lookright", true);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("stand", false);
            redpanda.SetBool("standlookright", true);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            redpanda.SetBool("lookleft", true);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("stand", false);
            redpanda.SetBool("standlookleft", true);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            redpanda.SetBool("scratch", true);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("run", true);
            redpanda.SetBool("trot", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            redpanda.SetBool("idletostand", true);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("stand", false);
            redpanda.SetBool("standtoidle", true);
            redpanda.SetBool("run", false);
            redpanda.SetBool("runleft", false);
            redpanda.SetBool("runright", false);
            redpanda.SetBool("jump", true);
        }
        if ((Input.GetKeyDown(KeyCode.Space)) && (CapsLockOn == true))
        {
            redpanda.SetBool("idle", false);
            redpanda.SetBool("jumpinplace", true);
            redpanda.SetBool("idletostand", false);
            redpanda.SetBool("standtoidle", false);
            redpanda.SetBool("jump", true);
        }
        if (Input.GetKeyDown("down"))
        {
            redpanda.SetBool("idle", false);
            redpanda.SetBool("idletoseat", true);
            redpanda.SetBool("seat", false);
            redpanda.SetBool("seattolie", true);
            redpanda.SetBool("lietosleep", true);
        }
        if (Input.GetKeyDown("up"))
        {
            redpanda.SetBool("sleeptolie", true);
            redpanda.SetBool("sleep", false);
            redpanda.SetBool("lietoseat", true);
            redpanda.SetBool("seattoidle", true);
            redpanda.SetBool("seat", false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            redpanda.SetBool("eat", true);
            redpanda.SetBool("idle", false);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            redpanda.SetBool("attack", true);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("runattack", true);
            redpanda.SetBool("run", false);
            redpanda.SetBool("runleft", false);
            redpanda.SetBool("runright", false);
            redpanda.SetBool("trot", false);
            redpanda.SetBool("trotleft", false);
            redpanda.SetBool("trotright", false);
            redpanda.SetBool("growl", false);
            redpanda.SetBool("jumpinplace", false);
            redpanda.SetBool("sneak", false);
            redpanda.SetBool("sneakleft", false);
            redpanda.SetBool("sneakright", false);
        }
        if ((Input.GetKeyDown(KeyCode.F)) && (CapsLockOn == true))
        {
            redpanda.SetBool("runattack", true);
            redpanda.SetBool("run", false);
            redpanda.SetBool("runleft", false);
            redpanda.SetBool("runright", false);
            redpanda.SetBool("trot", false);
            redpanda.SetBool("trotright", false);
            redpanda.SetBool("trotleft", false);
            redpanda.SetBool("jumpinplace", false);
        }
        if ((Input.GetKeyUp(KeyCode.F)) && (CapsLockOn == true))
        {
            redpanda.SetBool("runattack", false);
            redpanda.SetBool("run", true);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            redpanda.SetBool("idle", false);
            redpanda.SetBool("dig", true);
        }
        if ((Input.GetKey(KeyCode.LeftControl)))
        {
            redpanda.SetBool("sneak", true);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("growl", false);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            redpanda.SetBool("sneak", false);
            redpanda.SetBool("growl", true);
            redpanda.SetBool("idle", false);
        }
        if ((Input.GetKeyDown(KeyCode.A)))
        {
            redpanda.SetBool("walkleft", true);
            redpanda.SetBool("walk", false);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("sneak", false);
            redpanda.SetBool("lookleft", false);
            redpanda.SetBool("sneakleft", true);
        }
        if ((Input.GetKeyDown(KeyCode.D)))
        {
            redpanda.SetBool("walkright", true);
            redpanda.SetBool("walk", false);
            redpanda.SetBool("sneak", false);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("sneakright", true);
            redpanda.SetBool("lookright", false);
        }
        if ((Input.GetKeyUp(KeyCode.A))||(Input.GetKeyUp(KeyCode.D)))
        {
            redpanda.SetBool("walk", true);
            redpanda.SetBool("sneak", true);
            redpanda.SetBool("walkleft", false);
            redpanda.SetBool("walkright", false);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("sneakright", false);
            redpanda.SetBool("sneakleft", false);
            redpanda.SetBool("runleft", false);
            redpanda.SetBool("runright", false);
            redpanda.SetBool("run", true);
            redpanda.SetBool("trotleft", false);
            redpanda.SetBool("trotright", false);
            redpanda.SetBool("trot", true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            redpanda.SetBool("growl", false);
            redpanda.SetBool("hit", true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            redpanda.SetBool("growl", false);
            redpanda.SetBool("die", true);
        }
        if ((Input.GetKeyDown(KeyCode.A)) && (CapsLockOn == true))
        {
            redpanda.SetBool("lookleft", true);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("walkleft", false);
            redpanda.SetBool("walk", false);
            redpanda.SetBool("runleft", true);
            redpanda.SetBool("run", false);
            redpanda.SetBool("trotleft", true);
            redpanda.SetBool("trot", false);
        }
        if ((Input.GetKeyDown(KeyCode.D)) && (CapsLockOn == true))
        {
            redpanda.SetBool("lookright", true);
            redpanda.SetBool("idle", false);
            redpanda.SetBool("walkright", false);
            redpanda.SetBool("walk", false);
            redpanda.SetBool("runright", true);
            redpanda.SetBool("run", false);
            redpanda.SetBool("trotright", true);
            redpanda.SetBool("trot", false);
        }
    }
}
