using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerMovementState
{
    public IPlayerMovementState DoState(PlayerMovement playerMovement)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            return playerMovement.JumpState;
        }
        else if (playerMovement.InputVector != Vector3.zero)
        {
            return playerMovement.WalkState;
        }
        else
        {
            Idle();
            return playerMovement.IdleState;
        }
    }
    private void Idle()
    {
    
    }
}
