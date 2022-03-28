using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class scr_cnpt_Form_Abstract : MonoBehaviour
{
    public bool holdSkillisActive;
    protected float overlapRadius = 0.17f;
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
        bool isGrounded = CheckIfOverlap(rb.transform.GetChild(2).transform, overlapRadius, LayerMask.GetMask("Platforms"));

        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }

    public virtual void Skill_1()
    {
        Debug.Log("*Fireball sound*");
    }

    public virtual void Skill_2()
    {
        Debug.Log("*Heal sound*");
    }

    protected bool CheckIfOverlap(Transform checker, float radius, LayerMask mask)
    {
        return Physics2D.OverlapCircleAll(checker.position, radius, mask).Length != 0;
        //bool state = false;

        //Collider2D[] colliders = Physics2D.OverlapCircleAll(checker.position, radius, mask);
        //if (colliders.Length != 0)
        //{
        //    state = true;
        //}
        ////for (int i = 0; i < Colliders.Length; i++)
        ////{
        ////    if (Colliders[i].gameObject != gameObject)
        ////    {
        ////        state = true;
        ////        break;
        ////    }
        ////}
        //return state;
    }
    protected bool CheckIfOverlap(Transform[] checkers, float radius, LayerMask mask)
    {
        bool isOverlap = false;

        foreach (var checker in checkers)
        {
            isOverlap = isOverlap || Physics2D.OverlapCircleAll(checker.position, radius, mask).Length != 0;
        }
        return isOverlap;
        //bool state = false;

        //Collider2D[] colliders = Physics2D.OverlapCircleAll(checker.position, radius, mask);
        //if (colliders.Length != 0)
        //{
        //    state = true;
        //}
        ////for (int i = 0; i < Colliders.Length; i++)
        ////{
        ////    if (Colliders[i].gameObject != gameObject)
        ////    {
        ////        state = true;
        ////        break;
        ////    }
        ////}
        //return state;
    }

}
