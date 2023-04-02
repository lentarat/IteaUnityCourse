using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IPlayerMovementState
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
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            return playerMovement.RunState;
        }
        else
        {
            Walk(playerMovement);
            return playerMovement.WalkState;
        }
    }
    private void Walk(PlayerMovement playerMovement)
    {
        if(playerMovement.Rigidbody.velocity.magnitude > playerMovement.MaxWalkSpeed)
        {
            playerMovement.Rigidbody.velocity = playerMovement.Rigidbody.velocity.normalized * playerMovement.MaxWalkSpeed;
        }
    }
}
