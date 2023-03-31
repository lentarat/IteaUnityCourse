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
            playerMovement.ShiftDelay = 0f;
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
        Vector3 velocityVector = new Vector3(
            Mathf.Clamp(Input.GetAxis("Horizontal") * playerMovement.AccelerationMultiplier, -1, 1),
            0f,
            Mathf.Clamp(Input.GetAxis("Vertical") * playerMovement.AccelerationMultiplier, -1, 1)
            );
        if (playerMovement.ShiftDelay > 0)
        {
            playerMovement.ShiftDelay -= playerMovement.RunSpeed * Time.deltaTime;
        }
        playerMovement.transform.position += Mathf.Lerp(playerMovement.WalkSpeed, playerMovement.RunSpeed, playerMovement.ShiftDelay) * Time.deltaTime * velocityVector;
        //playerMovement.transform.position += playerMovement.WalkSpeed * Time.deltaTime * velocityVector;
    }
}
