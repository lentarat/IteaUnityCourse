using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _runSpeed;
    public float RunSpeed { get => _runSpeed; set => _runSpeed = value; }
    [SerializeField] private float _walkSpeed;
    public float WalkSpeed { get => _walkSpeed; set => _walkSpeed = value; }
    [SerializeField] private float _jumpForce;
    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
    [SerializeField] private float _crouchSpeed;
    public float CrouchSpeed{ get => _crouchSpeed; set => _crouchSpeed = value; }
    [SerializeField] private float _shiftSpeed;
    public float ShiftSpeed { get => _shiftSpeed; set => _shiftSpeed = value; }

    public RunState RunState = new RunState();
    public WalkState WalkState = new WalkState();
    public CrouchState CrouchState = new CrouchState();
    public JumpState JumpState = new JumpState();

    private IPlayerMovementState _currentState;
    
    private void Start()
    {
        _currentState = WalkState;
    }
    void Update()
    {
        _currentState = _currentState.DoState(this);
    }
}
