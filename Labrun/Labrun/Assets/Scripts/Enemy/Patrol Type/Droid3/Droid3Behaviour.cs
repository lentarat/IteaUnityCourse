using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid3Behaviour : PatrolDroid
{
    void Start()
    {
        AssignComponents();
        _animator.Play("Idle");
        AdjustPointsYCoordinate();
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Chase();
        }
        else
        {
            Patrol();
        }
    }
    public void Patrol()
    {
        Move();
    }
    //override public void Move()
    //{
    
    //}
    override public void Seek()
    {
        
    }
    

}
