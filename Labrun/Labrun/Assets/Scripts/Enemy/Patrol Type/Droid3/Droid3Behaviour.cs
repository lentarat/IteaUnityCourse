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
        Patrol();
        
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
        //зробити бекграунд чорним, а ліхтар - це меш, який контролює alpha
    }
    

}
