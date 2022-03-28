using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cnpt_Spider : scr_cnpt_Form_Abstract
{
    //public scr_cnpt_Spider(float jumpPower, float moveSpeed) : base (jumpPower, moveSpeed)
    //{
    //    _jumpPower = jumpPower;
    //    _moveSpeed = moveSpeed;
    //}

    //public override void Jump(Rigidbody2D rb)
    //{

    //    Debug.Log("Я прыгающий павук");
    //}

    public override void Jump(Rigidbody2D rb, float jumpPower)
    {
        //Transform[] checkers = new Transform[] { 
        //    rb.transform.GetChild(0), 
        //    rb.transform.GetChild(1),
        //    rb.transform.GetChild(3)
        //};

        //bool isCrawling = CheckIfOverlap(checkers, overlapRadius, LayerMask.GetMask("Platforms"));
        bool isGrounded = CheckIfOverlap(rb.transform.GetChild(2).transform, overlapRadius, LayerMask.GetMask("Platforms"));

        if (isGrounded && !(holdSkillisActive && IsCrawling(rb)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
    public override void Move(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed, float movementSmoothing)
    {
        //Transform[] checkers = new Transform[] {
        //    rb.transform.GetChild(0),
        //    rb.transform.GetChild(1),
        //    rb.transform.GetChild(3)
        //};

        //bool isCrawling = CheckIfOverlap(checkers, overlapRadius, LayerMask.GetMask("Platforms"));

        Vector2 velocity = Vector2.zero;
        Vector2 targetVelocity;

        if (holdSkillisActive && IsCrawling(rb))
        {
            rb.gravityScale = 0;
            targetVelocity = new Vector3(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        }
        else
        {
            rb.gravityScale = 0.65f;
            targetVelocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y);
            //Vector2 velocity = Vector2.zero;
            //rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
        }

        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
    }
    private bool IsCrawling(Rigidbody2D rb)
    {
        Transform[] checkers = new Transform[] {
            rb.transform.GetChild(0),
            rb.transform.GetChild(1),
            rb.transform.GetChild(3)
        };

        return CheckIfOverlap(checkers, overlapRadius, LayerMask.GetMask("Platforms"));
    }
}
