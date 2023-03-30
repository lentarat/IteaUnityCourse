using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _crouchSpeed;
    [SerializeField] private float _shiftSpeed;

    private IPlayerMovementState _currentState;
    public RunState RunState = new RunState();
    public WalkState WalkState = new WalkState();
    public CrouchState CrouchState = new CrouchState();
    public JumpState JumpState = new JumpState();

    private void Start()
    {
        _currentState = WalkState;
    }
    void Update()
    {
        _currentState = _currentState.DoState(this);
    }
}
