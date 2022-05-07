using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPlatform : MonoBehaviour
{
    [SerializeField] [Range(0, 30f)] private float force;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("MovableCube"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(rb.velocity.x, force);
            anim.SetBool("Active", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("MovableCube"))
        {
            anim.SetBool("Active", false);
        }
    }
}
