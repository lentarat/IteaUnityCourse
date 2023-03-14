using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private AnimationController _animController;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    private Vector2 _movementInput;
    private readonly float xJumpVelocityThreshold = 2f;
    private bool _isJumping;
    private bool _isRunning;
    private bool _isGrounded;

    private void Update()
    {
        GetInput();
        CheckForFlip();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void GetInput()
    {
        _movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        if (Input.GetKey(KeyCode.Space))
        {
            _isJumping = true;
        }
        else
        {
            _isJumping = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _isRunning = true;
        }
        else
        {
            _isRunning = false;
        }
    }
    
    private void Move()
    {
        if (_isJumping && _isGrounded)
        {
            Jump();
        }
        else
        {
            if (_movementInput == Vector2.zero && _isGrounded)
            {
                Idle();
            }
            else if (_isRunning && _isGrounded)
            {
                Run();
            }
            else
            {
                Walk();
            }
        }
    }
    private void Idle()
    {
        _animController.ChangeAnimationState(_animController.Idle);
    }
    
    private void Walk()
    {
        _rigidbody.AddForce(_walkSpeed * _movementInput);
        if (_isGrounded)
        {
            _animController.ChangeAnimationState(_animController.Walk);
        }
        else
        {
            if (_rigidbody.velocity.x > xJumpVelocityThreshold)
            {
                _rigidbody.velocity = new Vector2(xJumpVelocityThreshold, _rigidbody.velocity.y);
            }
            else if (_rigidbody.velocity.x < -xJumpVelocityThreshold)
            {
                _rigidbody.velocity = new Vector2(-xJumpVelocityThreshold, _rigidbody.velocity.y);
            }
        }
    }
    private void Run()
    {
        _rigidbody.AddForce(_runSpeed * _movementInput);
        _animController.ChangeAnimationState(_animController.Run);
    }
    private void Jump()
    {
        _rigidbody.AddForce(_jumpForce * Vector2.up, ForceMode2D.Impulse);
        _animController.ChangeAnimationState(_animController.Jump);
    }

    private void CheckForFlip()
    {
        if (_rigidbody.velocity.x > 0f)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isGrounded = true;
            _rigidbody.drag = 15f;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _isGrounded = false;
            _rigidbody.drag = 0f;
        }
    }
}
