using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class scr_grate_abstract : MonoBehaviour
{
    [SerializeField] protected bool playerIsClose = false;
    [SerializeField] protected float secondsWaitUntillTeleportation = 2f;
    [SerializeField] protected float secondsWaitAfterTeleportation = 2f;

    protected string slimeSlipAnimationName;
    public AnimationClip animationClip;

    protected Transform exit1;

    [SerializeField] protected Animator animator;


    protected virtual void Start()
    {
        InputManager.Instance.playerInput.actions["Interaction"].performed += Interact;
        exit1 = transform.GetChild(0);
        animator = GetComponent<Animator>();
    }

    protected void OnDestroy()
    {
        InputManager.Instance.playerInput.actions["Interaction"].performed -= Interact;
    }

    protected virtual void Interact(InputAction.CallbackContext context)
    {
        if (playerIsClose && scr_Player.instance.GetComponent<scr_cnpt_FormBehavior>()._currentForm.GetType().ToString() == "scr_cnpt_Slime")
        {
            StartCoroutine(Teleport());
        }
    }

    protected virtual IEnumerator Teleport()
    {
        scr_Player.instance.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        InputManager.Instance.playerInput.actions.FindActionMap("Slime").Disable();

        yield return new WaitForSeconds(secondsWaitUntillTeleportation);
        scr_Player.instance.transform.position = exit1.position;
        scr_Player.instance.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        InputManager.Instance.playerInput.actions.FindActionMap("Slime").Enable();
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
