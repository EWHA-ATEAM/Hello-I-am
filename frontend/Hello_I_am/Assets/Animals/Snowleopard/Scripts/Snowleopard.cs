using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowleopard : MonoBehaviour {
    Animator snowleopard;
    public float time;
    IEnumerator coroutine;
    // Use this for initialization
    void Start() {
        snowleopard = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        time += 0.01f;
        if (Input.GetKey(KeyCode.H))
        {
            time = 0;
            snowleopard.SetBool("growl", false);
            snowleopard.SetBool("hit", true);
        }
        if (time > 0.5f)
        {
            snowleopard.SetBool("growl", true);
            snowleopard.SetBool("hit", false);
        }
        if ((Input.GetKeyUp(KeyCode.W)) || (Input.GetKeyUp(KeyCode.RightControl)) || (Input.GetKeyUp(KeyCode.E))|| (Input.GetKeyUp(KeyCode.AltGr)) || (Input.GetKeyUp(KeyCode.RightShift)) || (Input.GetKeyUp(KeyCode.A)) || (Input.GetKeyUp(KeyCode.D)))
        {
            snowleopard.SetBool("idle", true);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("sneak", false);
            snowleopard.SetBool("sneakleft", false);
            snowleopard.SetBool("sneakright", false);
            snowleopard.SetBool("getup", false);
            snowleopard.SetBool("attack2", false);
            snowleopard.SetBool("attack3", false);
            snowleopard.SetBool("eat", false);
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            snowleopard.SetBool("growl", true);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("sneak", false);
            snowleopard.SetBool("sneakleft", false);
            snowleopard.SetBool("sneakright", false);
            snowleopard.SetBool("getup", false);
            snowleopard.SetBool("attack2", false);
            snowleopard.SetBool("attack3", false);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            snowleopard.SetBool("walk", true);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("idlelay", false);
            snowleopard.SetBool("getup", false);
            snowleopard.SetBool("sneak", false);
            snowleopard.SetBool("sneakleft", false);
            snowleopard.SetBool("sneakright", false);
            snowleopard.SetBool("growl", false);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            snowleopard.SetBool("turnleft", true);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("sneak", false);
            snowleopard.SetBool("sneakleft", false);
            snowleopard.SetBool("sneakright", false);
            snowleopard.SetBool("growl", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            snowleopard.SetBool("turnright", true);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("sneak", false);
            snowleopard.SetBool("sneakleft", false);
            snowleopard.SetBool("sneakright", false);
            snowleopard.SetBool("growl", false);
        }
        if ((Input.GetKey(KeyCode.RightShift)) && (Input.GetKeyDown(KeyCode.W)))
        {
            snowleopard.SetBool("trot", true);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("idle", false);
        }
        if ((Input.GetKey(KeyCode.RightShift)) && (Input.GetKeyDown(KeyCode.A)))
        {
            snowleopard.SetBool("trotleft", true);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
        }
        if ((Input.GetKey(KeyCode.RightShift)) && (Input.GetKeyDown(KeyCode.D)))
        {
            snowleopard.SetBool("trotright", true);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
        }
        if ((Input.GetKey(KeyCode.RightControl)) && (Input.GetKeyDown(KeyCode.W)))
        {
            snowleopard.SetBool("run", true);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
        }
        if ((Input.GetKey(KeyCode.RightControl)) && (Input.GetKeyDown(KeyCode.A)))
        {
            snowleopard.SetBool("runleft", true);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("trot", false);
        }
        if ((Input.GetKey(KeyCode.RightControl)) && (Input.GetKeyDown(KeyCode.D)))
        {
            snowleopard.SetBool("runright", true);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("trot", false);
        }
        if ((Input.GetKey(KeyCode.AltGr)) && (Input.GetKeyDown(KeyCode.W)))
        {
            snowleopard.SetBool("sneak", true);
            snowleopard.SetBool("sneakleft", false);
            snowleopard.SetBool("sneakright", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("getup", false);
            snowleopard.SetBool("attack1", false);
            snowleopard.SetBool("attack2", false);
            snowleopard.SetBool("attack3", false);
            snowleopard.SetBool("growl", false);
        }
        if ((Input.GetKey(KeyCode.AltGr)) && (Input.GetKeyDown(KeyCode.A)))
        {
            snowleopard.SetBool("sneakleft", true);
            snowleopard.SetBool("sneak", false);
            snowleopard.SetBool("sneakright", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("getup", false);
            snowleopard.SetBool("attack1", false);
            snowleopard.SetBool("attack2", false);
            snowleopard.SetBool("attack3", false);
            snowleopard.SetBool("growl", false);
        }
        if ((Input.GetKey(KeyCode.AltGr)) && (Input.GetKeyDown(KeyCode.D)))
        {
            snowleopard.SetBool("sneakright", true);
            snowleopard.SetBool("sneakleft", false);
            snowleopard.SetBool("sneak", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("getup", false);
            snowleopard.SetBool("attack1", false);
            snowleopard.SetBool("attack2", false);
            snowleopard.SetBool("attack3", false);
            snowleopard.SetBool("growl", false);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            snowleopard.SetBool("lay", true);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("idlelay", true);
            snowleopard.SetBool("sleeping", false);
            if (time > 5)
            {
                snowleopard.SetBool("getup", false);
                snowleopard.SetBool("idlelay", true);
                snowleopard.SetBool("lay", false);
                snowleopard.SetBool("sleep", false);
            }
            if ((Input.GetKey(KeyCode.L))&&(time > 2))
            {
                snowleopard.SetBool("getup", true);
                snowleopard.SetBool("idlelay", false);
                snowleopard.SetBool("lay", false);
                snowleopard.SetBool("sleep", false);
                time = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            snowleopard.SetBool("sleeping", false);
            snowleopard.SetBool("idlelay", false);
            snowleopard.SetBool("getup", true);
        }
        if (Input.GetKey(KeyCode.R))
        {
            snowleopard.SetBool("idlelay", false);
            snowleopard.SetBool("sleep", true);
            snowleopard.SetBool("getup", false);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            snowleopard.SetBool("jump", true);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("trotleft", false);
            StartCoroutine("run");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            snowleopard.SetBool("attack1", true);
            snowleopard.SetBool("jump", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("sneak", false);
            snowleopard.SetBool("sneakleft", false);
            snowleopard.SetBool("sneakright", false);
            snowleopard.SetBool("hit", false);
            StartCoroutine("run");
        }
        if ((Input.GetKeyDown(KeyCode.G))&&(time>1))
        {
            snowleopard.SetBool("attack3", true);
            snowleopard.SetBool("growl", false);
            snowleopard.SetBool("jump", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("attack1", false);
            snowleopard.SetBool("attack2", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("sneak", false);
            snowleopard.SetBool("sneakleft", false);
            snowleopard.SetBool("sneakright", false);
            snowleopard.SetBool("hit", false);
            time = 0;
        }
        if ((Input.GetKeyDown(KeyCode.G))&&(time>0))
        {
            snowleopard.SetBool("attack2", true);
            snowleopard.SetBool("growl", false);
            snowleopard.SetBool("attack1", false);
            snowleopard.SetBool("attack3", false);
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("jump", false);
            snowleopard.SetBool("run", false);
            snowleopard.SetBool("walk", false);
            snowleopard.SetBool("runleft", false);
            snowleopard.SetBool("runright", false);
            snowleopard.SetBool("turnleft", false);
            snowleopard.SetBool("turnright", false);
            snowleopard.SetBool("trot", false);
            snowleopard.SetBool("trotright", false);
            snowleopard.SetBool("trotleft", false);
            snowleopard.SetBool("sneak", false);
            snowleopard.SetBool("sneakleft", false);
            snowleopard.SetBool("sneakright", false);
            snowleopard.SetBool("hit", false);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            snowleopard.SetBool("idle", false);
            snowleopard.SetBool("eat", true);
        }
        if (Input.GetKey(KeyCode.Keypad0))
        {
            snowleopard.SetBool("die", true);
            snowleopard.SetBool("growl", false);
        }

    }
    IEnumerator run()
    {
        yield return new WaitForSeconds(0.5f);
        snowleopard.SetBool("run", true);
        snowleopard.SetBool("jump", false);
        snowleopard.SetBool("attack1", false);
    }
}
