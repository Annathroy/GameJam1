using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionAsset InputActions;

    private InputAction moveAction;
    private InputAction jumpAction;

    private float moveAmount;
    private Rigidbody2D playerRigidbody;

    public float walkSpeed = 5f;
    public float jumpPower = 5f;

    [Header("Ground check")] 
    public Transform groundCheckPosition;
    public Vector2 groundCheckSize = new Vector2(0.5f, 0.5f);
    public LayerMask groundLayer;

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
    }

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveAmount = moveAction.ReadValue<Vector2>().x;

        Moving();
        
        if (jumpAction.WasPressedThisFrame() && isGrounded())
        {
            Jump();
        }
    }

    private void Moving()
    {
        playerRigidbody.linearVelocity = new Vector2(moveAmount * walkSpeed, playerRigidbody.linearVelocity.y);
    }

    private void Jump()
    {
        //playerRigidbody.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        playerRigidbody.linearVelocity = new Vector2(playerRigidbody.linearVelocity.x, jumpPower);
    }

    private bool isGrounded()
    {
        if (Physics2D.OverlapBox(groundCheckPosition.position, groundCheckSize, 0, groundLayer))
        {
            return true;
        }

        return false;
    }
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheckPosition.position, groundCheckSize);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlatformLeftAndRight platform))
        {
            transform.SetParent(other.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out PlatformLeftAndRight platform))
        {
            transform.SetParent(null);
        }
    }
}
