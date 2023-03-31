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
        Vector3 velocityVector = new Vector3(
            Mathf.Clamp(Input.GetAxis("Horizontal") * playerMovement.AccelerationMultiplier, -1, 1),
            0f,
            Mathf.Clamp(Input.GetAxis("Vertical") * playerMovement.AccelerationMultiplier, -1, 1)
            );
        if(playerMovement.ShiftDelay < 1)
        { 
            playerMovement.ShiftDelay += playerMovement.RunSpeed * Time.deltaTime;
        }
        playerMovement.transform.position += Mathf.Lerp(playerMovement.WalkSpeed, playerMovement.RunSpeed, playerMovement.ShiftDelay) * Time.deltaTime * velocityVector;
    }
}
