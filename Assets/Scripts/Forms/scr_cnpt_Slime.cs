using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cnpt_Slime : scr_cnpt_Form_Abstract
{
    public float interactionRadius = 0.3f;

    public bool isPipeCrawling = false;

    public scr_cnpt_Slime(scr_cnpt_FormBehavior formBehavior)
    {
        sprite = Resources.Load<Sprite>("Slime");
        this.formBehavior = formBehavior;
    }

    public override void Skill_1()
    {
        //сначала собирать массив, потом проверять на длину 0, ИСПРАВИТЬ
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

    public override void Skill_2()
    {
        Collider2D[] targets = GetInteractableObjects(formBehavior.gameObject.transform, interactionRadius, LayerMask.GetMask("Pipe"));
        if (targets.Length != 0)
        {
            if (!isPipeCrawling)
            {
                StartPipeCrawling(targets[0].gameObject);
            }
            else
            {
                StopPipeCrawling(targets[0].gameObject);
            } 
        }
    }

    public override void Move(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed, float movementSmoothing)
    {
        if (isPipeCrawling)
        {
            Vector2 velocity = Vector2.zero;
            Vector2 targetVelocity;
            rb.gravityScale = 0;
            targetVelocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
            rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
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

    public void StartPipeCrawling(GameObject pipe)
    {
        isPipeCrawling = true;
        Transform entrance = pipe.transform.GetChild(0);
        transform.position = entrance.transform.position;
        //change sprite
        //change collider
    }

    public void StopPipeCrawling(GameObject pipe)
    {
        isPipeCrawling = false;
        Transform exit = pipe.transform.GetChild(1);
        transform.position = exit.transform.position;
        //change sprite
        //change collider
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
