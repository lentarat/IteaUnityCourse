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
    [SerializeField] AudioManager _audioManager;

    [SerializeField] private float xJumpVelocityThreshold;

    private readonly PlayerAnimations _playerAnimations = new PlayerAnimations(); // краще присвоювати тут чи в awake?

    private LayerMask _groundLayer;
    private Vector2 _movementInput;
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
    }
    private void FixedUpdate()
    {
        if (_playerStats.Health <= 0f)
        {
            return;
        }
        Move();
    }
    private void GetInput()
    {
        _movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        CheckForFlip();
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
        _audioManager.Pause();
        _animController.ChangeAnimationState(_playerAnimations.IdleAnimation);
        _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    
    private void Walk()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        _rigidbody.AddForce(_playerStats.WalkSpeed * _movementInput);
        if (_isGrounded)
        {
            _audioManager.Play("Walk");
            _animController.ChangeAnimationState(_playerAnimations.WalkAnimation);
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
        _animController.ChangeAnimationState(_playerAnimations.RunAnimation);
        //if (!_runSfx.isPlaying)
        //{
        //    _runSfx.Play();
        //}
        _audioManager.Play("Run");
    }
    private void Jump()
    {
        _rigidbody.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        _rigidbody.AddForce(_playerStats.JumpForce * Vector2.up, ForceMode2D.Impulse);
        _animController.ChangeAnimationState(_playerAnimations.JumpAnimation);
    }

    private void CheckForFlip()
    {
        if(_movementInput.x > 0f)
        {
            _spriteRenderer.flipX = false;
        }
        else if(_movementInput.x < 0f)
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
            _audioManager.Pause();
        }
    }
}
