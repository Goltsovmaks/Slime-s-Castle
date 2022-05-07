using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    public Transform TargetObject;
    private Rigidbody2D RB2D;
    public float speed;
    public float agroDistance;
    private bool isAgro;
    private bool movingright;
    private Animator animator;
    public float rayDist = 1f;
    void Start()
    {
        movingright = true;
        RB2D=GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isAgro = false;
        Physics2D.queriesStartInColliders = false;
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, TargetObject.position);

        if (distToPlayer < agroDistance)
        {
            isAgro = true;
            StartHunting();
            speed = 4; 
        }
        else
        {
            speed = 2;
            isAgro = false;
            StopHunting();
        }

        if (!movingright)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position , transform.localScale.x *  Vector2.right, rayDist);
            if (hit.collider != null)
            {
                RB2D.velocity = Vector2.up * 8;
            }
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position , transform.localScale.x *  Vector2.left, rayDist);
            if (hit.collider != null)
            {
                RB2D.velocity = Vector2.up * 8;
            }
        }
        
    }
    void StartHunting()
    {
        animator.SetBool("Agro",isAgro);
        transform.Translate(Vector2.right*(-speed)*Time.deltaTime);
        if(TargetObject.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0,0,0);
            movingright = true;
        }
        else
        {
            movingright = false;
            transform.eulerAngles = new Vector3(0,-180,0);
        } 
    }
    void StopHunting()
    {
        animator.SetBool("Agro",isAgro);
        transform.Translate(Vector2.right*(-speed)*Time.deltaTime);
        
        if (transform.position.x >= -18f && movingright)
        {
            movingright = true;
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else if (transform.position.x <= -12f)
        {
            movingright = false;
            transform.eulerAngles = new Vector3(0,-180,0);
        }
        else
        {
            movingright = true;
        }
    }
    private void OnDrawGizmos()
    { 
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * rayDist);
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.left * rayDist);
    }
    
}
