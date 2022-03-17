using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cnpt_BaseMovement : MonoBehaviour
{
    Inpt_cnpt_Slime _input;
    Rigidbody2D _rb;

    [SerializeField] private float _jumpPower = 5f;
    [SerializeField] private float _moveSpeed = 5f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .01f;


    public Transform groundChecker;
    public LayerMask whatIsGround;
    [SerializeField] private float groundCheckRadius = 0.17f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = new Inpt_cnpt_Slime();

        _input.Slime.Jump.performed += context => Jump();
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }

    void FixedUpdate()
    {
        float moveDirection = _input.Slime.HorizontalMovement.ReadValue<float>();
        Move(moveDirection);

    }

    void Move(float moveDirection)
    {
        Debug.Log(moveDirection);
        Vector2 targetVelocity = new Vector3(moveDirection * _moveSpeed * 10f, _rb.velocity.y);
        Vector2 velocity = Vector2.zero;
        _rb.velocity = Vector2.SmoothDamp(_rb.velocity, targetVelocity, ref velocity, movementSmoothing);
    }

    void Jump()
    {
        if(CheckIfOverlap(groundChecker, groundCheckRadius, whatIsGround))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpPower);
        }
    }

    bool CheckIfOverlap(Transform checker, float radius, LayerMask mask) 
    {
        bool state = false;
        
        Collider2D[] Colliders = Physics2D.OverlapCircleAll(checker.position, radius, mask);
        Debug.Log(Colliders);
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
