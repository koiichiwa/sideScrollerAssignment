using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class CharacterMovementState : MonoBehaviour
{
    [SerializeField] private CharacterMovementState playerMovement;
    public enum MoveState
    {
        Idle,

        Walk_Right,

        Jump,
    }

    public MoveState CurrentMoveState { get; private set; }

    [SerializeField] private Animator animator;

    [SerializeField] private Rigidbody2D rigidBody;

    private const string idleAnim = "Idle";

    private const string walkRightAnim = "Walk_Right";

    private const string jumpAnim = "Jump";

    public static Action<MoveState> OnPlayerMoveStateChanged;
    private float xPosLastFrame;

    private void Update()
    {
        if (transform.position.x == xPosLastFrame && rigidBody.linearVelocity.y == 0)
        {
            SetMoveState(MoveState.Idle);
        }
        else if (transform.position.x == xPosLastFrame && rigidBody.linearVelocity.y == 0)
        {
            SetMoveState(MoveState.Walk_Right);

        }

        xPosLastFrame = transform.position.x;
    }

    public void SetMoveState(MoveState moveState)
    {
        if (moveState == CurrentMoveState) return;

        switch (moveState)
        {
            case MoveState.Idle:
                HandleIdle();
                break;

            case MoveState.Walk_Right:
                HandleWalk_Right();
                break;

            case MoveState.Jump:
                HandleJump();
                break;

            default:
                Debug.LogError($"Invalid movement state: {moveState}");
                break;
        }

        OnPlayerMoveStateChanged?.Invoke(moveState);
        CurrentMoveState = moveState;
    }

    private void HandleIdle()
    {
        animator.Play(idleAnim);
    }
    private void HandleWalk_Right()
    {
        animator.Play(walkRightAnim);

    }
    private void HandleJump()
    {
        animator.Play(jumpAnim);

    }
}
