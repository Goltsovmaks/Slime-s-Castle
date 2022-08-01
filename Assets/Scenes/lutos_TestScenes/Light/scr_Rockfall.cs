using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_Rockfall : MonoBehaviour
{
    public string requiredTriggerID;

    private Animator animator;

    void Start()
    {
        scr_EventSystem.instance.playerTriggerEnter.AddListener(Rockfall);
        animator = gameObject.GetComponent<Animator>();
    }


    private void Rockfall(TriggerType triggerType, string id)
    {
        if (triggerType == TriggerType.objectTrigger)
        {
            if (id == requiredTriggerID)
            {
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                animator.Play("anim_Rockfall");
            }
        }

    }

    private void OnDestroy()
    {
        scr_EventSystem.instance.playerTriggerEnter.RemoveListener(Rockfall);
    }

}
