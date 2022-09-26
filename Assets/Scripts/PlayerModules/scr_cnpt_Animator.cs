using System.Collections;
using UnityEngine;
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

    }

    private void Update()
    {
        moveDirection = InputManager.Instance.playerInput.actions["Movement"].ReadValue<Vector2>();
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
    
    private void ChangeLight()
    {
        light.intensity = formBehavior._currentForm.lightIntensity;
    }

    private void SetSprite()
    {
        spriteRenderer.sprite = formBehavior._currentForm.sprite;
        StartCoroutine(ShowFormChangeEffect());
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
