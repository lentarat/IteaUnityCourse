using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : IPlayerMovementState
{
    public IPlayerMovementState DoState(PlayerMovement playerMovement)
    {
        //if (playerMovement.OnGround && !(Input.GetKey(KeyCode.Space) || Input.GetKeyUp(KeyCode.Space)))
        //{
        //    return playerMovement.WalkState;
        //}
        //else
        if (Input.GetKey(KeyCode.Space) || Input.GetKeyUp(KeyCode.Space))
        {
            Jump(playerMovement);
            return playerMovement.JumpState;
        }
        else
        {
            return playerMovement.IdleState;
        }
        
    }
    private void Jump(PlayerMovement playerMovement)
    {
        Debug.Log(playerMovement.OnGround);
        if (playerMovement.OnGround)
        { 
            Ray ray = new Ray(playerMovement.transform.position, -playerMovement.transform.up);
            RaycastHit[] colliders = Physics.SphereCastAll(ray, 0.5f);
            {
                foreach (RaycastHit item in colliders)
                {
                    if (item.collider.gameObject.layer == playerMovement.GroundLayer)
                    {
                        playerMovement.OnGround = false;
                        playerMovement.Rigidbody.velocity += Time.fixedDeltaTime * playerMovement.JumpForce * Vector3.up;
                    }
                }
            }
        }
    }
}
