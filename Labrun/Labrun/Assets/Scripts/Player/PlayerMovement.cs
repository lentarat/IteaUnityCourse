using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private AnimationController _animController;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private LayerMask _groundLayer;
    private Vector2 _movementInput;
    private readonly float xJumpVelocityThreshold = 2f;
    private bool _isJumping;
    private bool _isRunning;
    private bool _isGrounded;
    private void Awake()
    {
        _groundLayer = LayerMask.NameToLayer("Ground");
    }

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
        Debug.Log(Time.time);
        _animController.ChangeAnimationState(_animController.Idle);
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    
    private void Walk()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        _rigidbody.AddForce(_playerStats.WalkSpeed * _movementInput);
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
        _rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        _rigidbody.AddForce(_playerStats.RunSpeed * _movementInput);
        _animController.ChangeAnimationState(_animController.Run);
    }
    private void Jump()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        _rigidbody.AddForce(_playerStats.JumpForce * Vector2.up, ForceMode2D.Impulse);
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
        if (collision.gameObject.layer == _groundLayer)
        {
            _isGrounded = true;
            _rigidbody.drag = 15f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _groundLayer)
        {
            _isGrounded = false;
            _rigidbody.drag = 0f;
        }
    }
}
