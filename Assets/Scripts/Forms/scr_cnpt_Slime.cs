using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cnpt_Slime : scr_cnpt_Form_Abstract
{
    public float interactionRadius = 0.3f;

    public scr_cnpt_Slime(scr_cnpt_FormBehavior formBehavior)
    {
        sprite = Resources.Load<Sprite>("Slime");
        this.formBehavior = formBehavior;
    }

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

    public override void Skill_2()
    {
        Debug.Log("*Heal sound*");
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
