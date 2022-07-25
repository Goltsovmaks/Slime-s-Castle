using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class scr_cnpt_Animator : MonoBehaviour
{
    scr_cnpt_FormBehavior formBehavior;
    private SpriteRenderer spriteRenderer;
   // private light2d light2D;

    public GameObject formChangeEffect;

    Vector2 moveDirection;

    private void Awake()
    {
        formBehavior = GetComponent<scr_cnpt_FormBehavior>();
        spriteRenderer = GetComponent <SpriteRenderer>();
       // light2D = GetComponent<light2d>();

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
    
    private void ChangeLight()
    {
       // light.intensity = formBehavior._currentForm.lightIntensity;
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
        scr_cnpt_FormBehavior.FormIsChanged += ChangeLight;
    }
    private void OnDisable()
    {
        scr_cnpt_FormBehavior.FormIsChanged -= SetSprite;
        scr_cnpt_FormBehavior.FormIsChanged -= ChangeLight;
    }
}
