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
    public override void Move(Rigidbody2D rb, float moveDirection, float moveSpeed, float movementSmoothing)
    {
        if (moveDirection == 0)
            rb.gravityScale = 0.65f;
        else
            rb.gravityScale = 0;

        Vector2 targetVelocity = new Vector3(moveDirection * moveSpeed * 10f, moveDirection * moveSpeed * 10f);
        Vector2 velocity = Vector2.zero;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
    }
}
