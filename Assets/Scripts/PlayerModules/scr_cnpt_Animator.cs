using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cnpt_Animator : MonoBehaviour
{
    scr_cnpt_FormBehavior formBehavior;
    private SpriteRenderer spriteRenderer;

    public GameObject formChangeEffect;

    Vector2 moveDirection;

    private void Awake()
    {
        formBehavior = GetComponent<scr_cnpt_FormBehavior>();
        spriteRenderer = GetComponent <SpriteRenderer>();

        //formBehavior.NextForm().per

    }

    private void Update()
    {
        moveDirection = InputManager.instance.playerInput.actions["Movement"].ReadValue<Vector2>();
        FlipSprite();
    }

    void FlipSprite()
    {
        if (moveDirection.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (moveDirection.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }
    

    private void SetSprite()
    {
        spriteRenderer.sprite = formBehavior._currentForm.sprite;
        StartCoroutine(ShowFormChangeEffect());
        
        //spriteRenderer.sprite = spriteTest;

    }

    IEnumerator ShowFormChangeEffect()
    {
        formChangeEffect.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        formChangeEffect.SetActive(false);
    }


    private void OnEnable()
    {
        scr_cnpt_FormBehavior.FormIsChanged += SetSprite;
    }
    private void OnDisable()
    {
        scr_cnpt_FormBehavior.FormIsChanged -= SetSprite;
    }
}
