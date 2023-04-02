using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IPlayerMovementState
{
    public IPlayerMovementState DoState(PlayerMovement playerMovement)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return playerMovement.JumpState;
        }
        else if (playerMovement.InputVector == Vector3.zero)
        {
            return playerMovement.IdleState;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            return playerMovement.WalkState;
        }
        else
        {
            Run(playerMovement);
            return playerMovement.RunState;
        } 
    }
    private void Run(PlayerMovement playerMovement)
    {
        if (playerMovement.Rigidbody.velocity.magnitude > playerMovement.MaxRunSpeed)
        {
            playerMovement.Rigidbody.velocity = playerMovement.Rigidbody.velocity.normalized * playerMovement.MaxRunSpeed;
        }
    }
}
