using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Droid3Behaviour : PatrolDroid
{
   //[SerializeField] private Light2D _light;
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
        Seek();
        //Debug.DrawRay(transform.localPosition+Vector3.up*0.5f, -transform.right,Color.cyan);
        //Debug.DrawRay(transform.localPosition + Vector3.up * 0.5f, (_playerPosition.position - transform.position).normalized, Color.cyan);
        //Debug.Log(Vector2.Angle((_playerPosition.position - transform.position).normalized, -transform.right));
    }
    //override public void Move()
    //{
    
    //}
    //override public void Seek()
    //{
    //    Physics2D.Raycast(transform.position, _playerPosition,)
    //}
    

}
