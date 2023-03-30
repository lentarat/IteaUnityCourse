using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IPlayerMovementState
{
    public IPlayerMovementState DoState(PlayerMovement playerMovement)
    {
        return playerMovement.RunState;
    }
}
