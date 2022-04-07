using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cnpt_Animator : MonoBehaviour
{
    public Sprite[] spriteArray;
    scr_cnpt_FormBehavior formBehavior;
    private SpriteRenderer spriteRenderer;
    public Sprite spriteTest;

    private void Awake()
    {
        formBehavior = GetComponent<scr_cnpt_FormBehavior>();
        spriteRenderer = GetComponent <SpriteRenderer>();

        //formBehavior.NextForm().per

    }
    //private void OnEnable()
    //{
    //    scr_cnpt_FormBehavior.FormIsChanged += SetSprite;
    //}
    //private void OnDisable()
    //{
    //    scr_cnpt_FormBehavior.FormIsChanged -= SetSprite;
    //}

    //private void SetSprite()
    //{
    //    spriteRenderer.sprite = formBehavior._currentForm.sprite;
    //    //spriteRenderer.sprite = spriteTest;
    //}
}
