using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_SlimeAttack : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private CapsuleCollider2D capsuleCollider2D;

    private bool canAttack = true;

    private void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        capsuleCollider2D = gameObject.GetComponent<CapsuleCollider2D>();
        scr_EventSystem.instance.slimeHasAttacked.AddListener(SlimeAttack);
    }

    private void OnDestroy()
    {
        scr_EventSystem.instance.slimeHasAttacked.RemoveListener(SlimeAttack);
    }

    private void SlimeAttack()
    {
        if (canAttack)
        {
            StartCoroutine(EnableAttackColliderAndSprite());
        }
    }

    IEnumerator EnableAttackColliderAndSprite()
    {
        canAttack = false;

        spriteRenderer.enabled = true;
        capsuleCollider2D.enabled = true;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.enabled = false;
        capsuleCollider2D.enabled = false;

        canAttack = true;
    }
}
