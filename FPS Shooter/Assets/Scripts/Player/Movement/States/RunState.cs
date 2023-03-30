using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IPlayerMovementState
{
    public IPlayerMovementState DoState(PlayerMovement playerMovement)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("RunState to walk!");
            return playerMovement.WalkState;
        }
        else
        {
            Debug.Log("RunState to run!");
            return playerMovement.RunState;
        } 
    }
}
