using UnityEngine;

public class scr_cnpt_Slime : scr_cnpt_Form_Abstract
{
    public scr_cnpt_Slime(scr_cnpt_FormBehavior formBehavior)
    {
        sprite = Resources.Load<Sprite>("Slime");
        this.formBehavior = formBehavior;
    }

    public float interactionRadius = 0.3f;

    public static bool isPipeCrawling = false;

    public override void Skill_1()
    {
        scr_EventSystem.instance.slimeHasAttacked.Invoke();

        if (GetInteractableObjects(formBehavior.gameObject.transform, interactionRadius, 
            LayerMask.GetMask("InteractableObjects")).Length != 0)
        {
            Collider2D[] targets = GetInteractableObjects(formBehavior.gameObject.transform, 
                interactionRadius, LayerMask.GetMask("InteractableObjects"));
            if (targets[0].gameObject.GetComponent<IPickable>() == null)
            {
                Destroy(targets[0].gameObject);
            }
            else
            {
                PickObject(targets[0].gameObject);
            }
        }
        else
        {
            DropCurrentPickedObject();
        }
    }

    public override void Skill_2()
    {
        
    }

    public override void Move(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed, 
        float movementSmoothing)
    {
        if (isPipeCrawling)
        {
            Vector2 velocity = Vector2.zero;
            Vector2 targetVelocity;
            rb.gravityScale = 0f;
            targetVelocity = new Vector3(moveDirection.x * moveSpeed * 0.75f, 
                moveDirection.y * moveSpeed * 0.75f);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 
                movementSmoothing);
        }
        else
        {
            rb.gravityScale = 0.65f;
            base.Move(rb, moveDirection, moveSpeed, movementSmoothing);
        }
        
    }

    public override void Jump(Rigidbody2D rb, float jumpPower)
    {
        if (!isPipeCrawling)
        {
            base.Jump(rb, jumpPower);
        }
    }

    public override void StopUsingCurrentForm()
    {
        DropCurrentPickedObject();
    }

    public void PickObject(GameObject target)
    {
        DropCurrentPickedObject();

        target.GetComponent<IPickable>().StartInteraction();

        target.transform.parent = formBehavior.gameObject.transform;
        target.transform.position = new Vector3(formBehavior.gameObject.transform.position.x,
            formBehavior.gameObject.transform.position.y + 0.25f,
            formBehavior.gameObject.transform.position.z);
        
        scr_Player.currentPickedObject = target;
    }

    public void DropCurrentPickedObject()
    {
        if (scr_Player.currentPickedObject != null)
        {
            scr_Player.currentPickedObject.GetComponent<IPickable>().StopInteraction();

            scr_Player.currentPickedObject = null;
        }
    }

    
}
