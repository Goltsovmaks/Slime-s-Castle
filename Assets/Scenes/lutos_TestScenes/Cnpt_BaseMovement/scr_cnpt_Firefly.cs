using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cnpt_Firefly : scr_cnpt_Form_Abstract
{
    private int jumpsLeft = 2;
    private float glideSpeed = 1f;
    //public scr_cnpt_Firefly(float jumpPower, float moveSpeed) : base(jumpPower, moveSpeed)
    //{
    //    _jumpPower = jumpPower;
    //    _moveSpeed = moveSpeed;
    //}

    public override void Move(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed, float movementSmoothing)
    {
        Vector2 velocity = Vector2.zero;
        Vector2 targetVelocity;

        if (holdSkillisActive)
        {
            rb.gravityScale = 0;
            targetVelocity = new Vector3(moveDirection.x * moveSpeed, -glideSpeed);
        }
        else
        {
            rb.gravityScale = 0.65f;
            targetVelocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y);
        }
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
    }

    public override void Jump(Rigidbody2D rb, float jumpPower)
    {
        bool isGrounded = CheckIfOverlap(rb.transform.GetChild(2).transform, overlapRadius, LayerMask.GetMask("Platforms"));
        if (!holdSkillisActive)
        {
            if (isGrounded)
            {
                jumpsLeft = 1;
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            }
            else if (jumpsLeft > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                jumpsLeft -= 1;
            }
        }
        
    }
}
