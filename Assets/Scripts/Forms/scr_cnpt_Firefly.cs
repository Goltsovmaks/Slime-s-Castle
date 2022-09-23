using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cnpt_Firefly : scr_cnpt_Form_Abstract
{
    private int jumpsLeft = 1;
    private float glideSpeed = 2f;


    //private bool isGrounded = false;


    public scr_cnpt_Firefly(scr_cnpt_FormBehavior formBehavior)
    {
        sprite = Resources.Load<Sprite>("Firefly");
        lightIntensity = 1.1f;
        this.formBehavior = formBehavior;
    }

    public override void Move(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed, float movementSmoothing)
    {
        Vector2 velocity = Vector2.zero;
        Vector2 targetVelocity;
        rb.gravityScale = 0.65f;

        if (holdSkillisActive && rb.velocity.y < 0)
        {
            //rb.gravityScale = 0;
            targetVelocity = new Vector3(moveDirection.x * moveSpeed, -glideSpeed);
            //targetVelocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y);
            //rb.position = new Vector2(rb.position.x, rb.position.y - 1f * Time.deltaTime);
        }
        else
        {
            //rb.gravityScale = 0.65f;
            targetVelocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y);
        }
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);

        if (isGrounded)
        {
            jumpsLeft = 1;
        }

        isGrounded = CheckIfOverlap(rb.transform.GetChild(2).transform, overlapRadius, LayerMask.GetMask("Platforms"));
    }

    public override void Jump(Rigidbody2D rb, float jumpPower)
    {
        //bool isGrounded = CheckIfOverlap(rb.transform.GetChild(2).transform, overlapRadius, LayerMask.GetMask("Platforms"));

        if (isGrounded)
        {
            //jumpsLeft = 1;
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
        else if (jumpsLeft > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            jumpsLeft -= 1;
        }

    }

    //========================================================================================//

    public float interactionRadius = 0.3f;
    public override void Skill_1()
    {
        if (GetInteractableObjects(formBehavior.gameObject.transform, interactionRadius, LayerMask.GetMask("InteractableObjects")).Length != 0)
        {
            Collider2D[] targets = GetInteractableObjects(formBehavior.gameObject.transform, interactionRadius, LayerMask.GetMask("InteractableObjects"));
            if (targets[0].gameObject.GetComponent<IPickable>() == null)
            {
                //Получить плюшки за что-то съеденное
                Debug.Log("Съел " + targets[0].gameObject);
                Object.Destroy(targets[0].gameObject);
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
    //========================================================================================//
}
