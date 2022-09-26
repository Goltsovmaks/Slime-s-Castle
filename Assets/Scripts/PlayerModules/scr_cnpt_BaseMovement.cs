using UnityEngine;
using UnityEngine.InputSystem;

public class scr_cnpt_BaseMovement : MonoBehaviour
{
    Rigidbody2D _rb;
    scr_cnpt_FormBehavior formBehavior;

    [SerializeField] private float _jumpPower = 5f;
    [SerializeField] private float _moveSpeed = 5f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .01f;

    public Transform groundChecker;
    public LayerMask whatIsGround;
    [SerializeField] private float groundCheckRadius = 0.17f;

    InputManager input;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        formBehavior = GetComponent<scr_cnpt_FormBehavior>();

        input = InputManager.Instance;
        input.playerInput.actions["Jump"].performed += Jump;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        formBehavior._currentForm.Jump(_rb, _jumpPower);
    }

    private void OnDestroy()
    {
        input.playerInput.actions["Jump"].performed -= Jump;
    }

    void FixedUpdate()
    {
        Vector2 moveDirection = input.playerInput.actions["Movement"].ReadValue<Vector2>();
        formBehavior._currentForm.Move(_rb, moveDirection, _moveSpeed, movementSmoothing);
    }
}
