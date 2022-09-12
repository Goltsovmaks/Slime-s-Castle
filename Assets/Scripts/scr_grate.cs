using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class scr_grate : scr_grate_abstract
{
    private Transform exit2;

    private scr_grate()
    {
        slimeSlipAnimationName = "grateSlipAnimation";
    }

    protected override void Start()
    {
        base.Start();
        exit2 = transform.GetChild(1);
    }

    protected override IEnumerator Teleport()
    {
        scr_Player.instance.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        InputManager.instance.playerInput.actions.FindActionMap("Slime").Disable();

        

        //yield return new WaitForSeconds(secondsWaitUntillTeleportation);

        if (CheckIfPlayerIsCloserToPoint1())
        {
            scr_Player.instance.transform.position = exit2.position;
            animator.Play("SeepRight");
        }
        else
        {
            scr_Player.instance.transform.position = exit1.position;
            animator.Play("SeepLeft");
        }

        //play another part of animation?
        yield return new WaitForSeconds(2f/3f);
        scr_Player.instance.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        InputManager.instance.playerInput.actions.FindActionMap("Slime").Enable();
    }

    private bool CheckIfPlayerIsCloserToPoint1()
    {
        Vector3 playerPosition = scr_Player.instance.transform.position;

        float exit1Distance = Mathf.Sqrt(Mathf.Pow((playerPosition - exit1.position).x,2f) + Mathf.Pow((playerPosition - exit1.position).y,2f));
        float exit2Distance = Mathf.Sqrt(Mathf.Pow((playerPosition - exit2.position).x, 2f) + Mathf.Pow((playerPosition - exit2.position).y, 2f));

        return exit1Distance <= exit2Distance;
    }
}



