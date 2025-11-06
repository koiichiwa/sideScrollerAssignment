using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterJump : MonoBehaviour 
{
    [SerializeField] private CharacterMovementState playerMovementState;
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float jumpForce = 6;

    private float playerHalfHeight;

    private void Start()
    {
        playerHalfHeight = spriteRenderer.bounds.extents.y;
    }

    private bool isGrounded;
    void Update ()
    {
            if (Input.GetButtonDown("Jump") && GetIsGrounded()) {
            playerMovementState.SetMoveState(CharacterMovementState.MoveState.Jump);
            Jump();
        }
    }

    private bool GetIsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, playerHalfHeight + 0.1f, LayerMask.GetMask("Ground"));

    }
    private void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

}
