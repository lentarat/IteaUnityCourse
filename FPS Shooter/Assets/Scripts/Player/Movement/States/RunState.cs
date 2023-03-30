using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : IPlayerMovementState
{
    public IPlayerMovementState DoState(PlayerMovement playerMovement)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Debug.Log("RunState to walk!");
            return playerMovement.WalkState;
        }
        else
        {
            //Debug.Log("RunState to run!");
            Run(playerMovement);
            return playerMovement.RunState;
        } 
    }
    private void Run(PlayerMovement playerMovement)
    {
        Vector3 velocityVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMovement.transform.position += playerMovement.RunSpeed * Time.deltaTime * velocityVector;
    }
}
