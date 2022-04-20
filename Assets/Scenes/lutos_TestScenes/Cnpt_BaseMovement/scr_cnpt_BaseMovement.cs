using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class scr_cnpt_BaseMovement : MonoBehaviour
{
    //Inpt_cnpt_Input _input;
    //PlayerInput _input;
    Rigidbody2D _rb;
    scr_cnpt_FormBehavior formBehavior;

    [SerializeField] private float _jumpPower = 5f;//
    [SerializeField] private float _moveSpeed = 5f;//
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .01f;//

    public Transform groundChecker;
    public LayerMask whatIsGround;
    [SerializeField] private float groundCheckRadius = 0.17f;

    InputManager input;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        //_input = new Inpt_cnpt_Input();
        //_input = GetComponent<PlayerInput>();
        formBehavior = GetComponent<scr_cnpt_FormBehavior>();

        input = InputManager.instance;


        //_input.Slime.Jump.performed += context => formBehavior._currentForm.Jump(_rb, _jumpPower);
        input.playerInput.actions["Jump"].performed += context => formBehavior._currentForm.Jump(_rb, _jumpPower);



    }

    //private void OnEnable()
    //{
    //    _input.Enable();
    //}

    //private void OnDisable()
    //{
    //    _input.Disable();
    //}

    void FixedUpdate()
    {
        //Vector2 moveDirection = _input.Slime.Movement.ReadValue<Vector2>();
        Vector2 moveDirection = input.playerInput.actions["Movement"].ReadValue<Vector2>();


        //float moveDirection = _input.Slime.HorizontalMovement.ReadValue<float>();

        formBehavior._currentForm.Move(_rb, moveDirection, _moveSpeed, movementSmoothing);
    }

    //bool CheckIfOverlap(Transform checker, float radius, LayerMask mask)
    //{
    //    bool state = false;

    //    Collider2D[] Colliders = Physics2D.OverlapCircleAll(checker.position, radius, mask);
    //    for (int i = 0; i < Colliders.Length; i++)
    //    {
    //        if (Colliders[i].gameObject != gameObject)
    //        {
    //            state = true;
    //            break;
    //        }
    //    }
    //    return state;
    //}
}
