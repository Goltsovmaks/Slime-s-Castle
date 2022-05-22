using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cnpt_Spider : scr_cnpt_Form_Abstract
{
    public GameObject SpiderWebShot;
    public scr_cnpt_Spider(scr_cnpt_FormBehavior formBehavior)
    {
        sprite = Resources.Load<Sprite>("Spider");
        this.formBehavior = formBehavior;
        //animator = anim;

        SpiderWebShot = formBehavior.transform.GetChild(4).gameObject;
    }

    public override void Skill_1()
    {
        //Vector2 direction = InputManager.instance.playerInput.actions["Movement"].ReadValue<Vector2>();
        GameObject web = Instantiate(SpiderWebShot,formBehavior.transform.position, formBehavior.transform.rotation);
        web.SetActive(true);
        web.GetComponent<Scr_SpiderWebShot>().Shot();
    }

    public override void Skill_2()
    {
        Debug.Log("*Heal sound*");
    }


    public override void Jump(Rigidbody2D rb, float jumpPower)
    {
        bool isGrounded = CheckIfOverlap(rb.transform.GetChild(2).transform, overlapRadius, LayerMask.GetMask("Platforms"));

        if (isGrounded && !(holdSkillisActive && IsTouchingPlatform(rb)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
    public override void Move(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed, float movementSmoothing)
    {

        Vector2 velocity = Vector2.zero;
        Vector2 targetVelocity;

        if (holdSkillisActive && IsTouchingPlatform(rb))
        {
            rb.gravityScale = 0;
            targetVelocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
        else
        {
            rb.gravityScale = 0.65f;
            targetVelocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y);

        }

        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
    }
    private bool IsTouchingPlatform(Rigidbody2D rb)
    {
        Transform[] checkers = new Transform[] {
            rb.transform.GetChild(0),
            rb.transform.GetChild(1),
            rb.transform.GetChild(3)
        };

        return CheckIfOverlap(checkers, overlapRadius, LayerMask.GetMask("Platforms"));
    }
}
