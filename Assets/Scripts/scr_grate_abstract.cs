using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class scr_grate_abstract : MonoBehaviour
{
    [SerializeField] protected bool playerIsClose = false;
    [SerializeField] protected float secondsWaitUntillTeleportation = 2f;
    [SerializeField] protected float secondsWaitAfterTeleportation = 2f;

    protected string slimeSlipAnimationName;

    protected Transform exit1;

    protected virtual void Start()
    {
        InputManager.instance.playerInput.actions["GrateInteraction"].performed += Interact;
        exit1 = transform.GetChild(0);
    }

    protected void OnDestroy()
    {
        InputManager.instance.playerInput.actions["GrateInteraction"].performed -= Interact;
    }

    protected virtual void Interact(InputAction.CallbackContext context)
    {
        if (playerIsClose && scr_Player.instance.GetComponent<scr_cnpt_FormBehavior>()._currentForm.GetType().ToString() == "scr_cnpt_Slime")
        {
            InputManager.instance.playerInput.actions.FindActionMap("Slime").Disable();
            scr_Player.instance.GetComponent<Animator>().Play(slimeSlipAnimationName);
            StartCoroutine(Teleport());
        }
    }

    protected virtual IEnumerator Teleport()
    {
        yield return new WaitForSeconds(secondsWaitUntillTeleportation);
        scr_Player.instance.transform.position = exit1.position;
        //play another part of animation?
        yield return new WaitForSeconds(secondsWaitAfterTeleportation);
        InputManager.instance.playerInput.actions.FindActionMap("Slime").Enable();
    }


    protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
        }

    }
}
