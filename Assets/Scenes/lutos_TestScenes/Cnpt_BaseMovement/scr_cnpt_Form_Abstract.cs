using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class scr_cnpt_Form_Abstract : MonoBehaviour
{
    //protected float _jumpPower;
    //protected float _moveSpeed;
    //[Range(0, .3f)] [SerializeField] private float movementSmoothing = .01f;

    //public scr_cnpt_Form_Abstract(float jumpPower, float moveSpeed)
    //{
    //    _jumpPower = jumpPower;
    //    _moveSpeed = moveSpeed;
    //}

    public virtual void Move(Rigidbody2D rb, Vector2 moveDirection, float moveSpeed, float movementSmoothing)
    {
        Vector2 targetVelocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y);
        Vector2 velocity = Vector2.zero;
        rb.velocity = Vector2.SmoothDamp(rb.velocity, targetVelocity, ref velocity, movementSmoothing);
    }

    public virtual void Jump(Rigidbody2D rb, float jumpPower)//, bool isGrounded
    {
        bool isGrounded = CheckIfOverlap(rb.transform.GetChild(0).transform, 0.17f, LayerMask.NameToLayer("Platforms"));
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    public virtual void Skill_1_hold()
    {
        Debug.Log("That's my first skill, hold the button to use it");
    }

    public bool CheckIfOverlap(Transform checker, float radius, LayerMask mask)
    {
        bool state = false;

        Collider2D[] Colliders = Physics2D.OverlapCircleAll(checker.position, radius, mask);
        for (int i = 0; i < Colliders.Length; i++)
        {
            if (Colliders[i].gameObject != gameObject)
            {
                state = true;
                break;
            }
        }
        return state;
    }

}
