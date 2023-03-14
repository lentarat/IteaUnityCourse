using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;
    private readonly int _walkAnimState;
    private Vector3 _movementInput;
    private bool _isJumping;

    private void Update()
    {
        GetMoveInput();
    }
    private void FixedUpdate()
    {
        GetJumpInput();
    }
    private void GetMoveInput()
    {

        _movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            Run();
            return;
        }
        if (_movementInput.x != 0f)
        {
            Walk();
        }
    }
    private void GetJumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJumping = true;
            Jump();
        }
    }
   
    private void Walk()
    {
        transform.position += Time.deltaTime * _walkSpeed * _movementInput;
    }
    private void Run()
    {
        transform.position += Time.deltaTime * _runSpeed * _movementInput;
    }
    private void Jump()
    {
        //зробити жамп без фізики
        //transform.position += Time.deltaTime * _jumpForce * _movementInput;
        _rigidbody.AddForce(Time.deltaTime * _jumpForce * Vector2.up, ForceMode2D.Impulse);
    }
}
