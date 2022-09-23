using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.Universal;


public class scr_cnpt_Animator : MonoBehaviour
{
    scr_cnpt_FormBehavior formBehavior;
    private SpriteRenderer spriteRenderer;
    private Light2D light;

    public GameObject formChangeEffect;

    Vector2 moveDirection;

    private void Awake()
    {
        formBehavior = GetComponent<scr_cnpt_FormBehavior>();
        spriteRenderer = GetComponent <SpriteRenderer>();
        light = GetComponent<Light2D>();

        //formBehavior.NextForm().per

    }

    private void Update()
    {
        moveDirection = InputManager.instance.playerInput.actions["Movement"].ReadValue<Vector2>();
        //FlipSprite();
        Flip();
    }

    void Flip()
    {
        if (moveDirection.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1f,1f);
        }
        else if (moveDirection.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1f,1f);
        }
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
        light.intensity = formBehavior._currentForm.lightIntensity;
        //some other parameteres
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
