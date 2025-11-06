using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Animator animator;
    private Vector2 movement;

    private float xPosLastFrame;
    void Update()
    {
        FlipCharacterX();
        HandleMovement();
    }
    private void FlipCharacterX()
    {
        if (transform.position.x > xPosLastFrame)
        {
            spriteRenderer.flipX = false;
        }
        else if (transform.position.x < xPosLastFrame)
        {
            spriteRenderer.flipX = true;
        }

        xPosLastFrame = transform.position.x;
    }

    private void HandleMovement()

    {
        float input = Input.GetAxisRaw("Horizontal");
        movement.x = input * speed * Time.deltaTime;
        transform.Translate(movement);
        
    }
}
