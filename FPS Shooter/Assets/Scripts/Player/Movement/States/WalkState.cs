using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IPlayerMovementState
{
    public IPlayerMovementState DoState(PlayerMovement playerMovement)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Debug.Log("WalkState to jump!");
            return playerMovement.JumpState;
        }
        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            //Debug.Log("WalkState to run!");
            return playerMovement.RunState;
        }
        else
        {
            //Debug.Log("WalkState to walk!");
            Walk(playerMovement);
            return playerMovement.WalkState;
        }
    }
    private void Walk(PlayerMovement playerMovement)
    {
        Vector3 velocityVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMovement.transform.position += playerMovement.WalkSpeed * Time.deltaTime * velocityVector;
    }
}
