using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovement : MonoBehaviour
{
    private delegate void _stringDel(string who);
    private static event _stringDel hiDel = null, byeDel = null, sumDel = null;
    private void Hello(string s)
    {
        Debug.Log($"Hello{s}");
    }
    private void Bye(string s)
    {
       Debug.Log($"Bye{s}");
    }

    private void Start()
    {
        
        hiDel += Bye;
        byeDel += Hello;
        sumDel += hiDel - byeDel;
        sumDel?.Invoke("strongsman");
        
    }
    //    [SerializeField] private Rigidbody2D _rigidbody;
    //    [SerializeField] private float _speed;
    //    [SerializeField] private float _jumpForce;
    //    private Vector2 _direction;
    //    void Update()
    //    {
    //        GetInput();
    //    }
    //    private void FixedUpdate()
    //    {
    //        Move();
    //    }

    //    private void GetInput()
    //    {
    //        _direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * _jumpForce);
    //    }
    //    private void Move()
    //    {
    //        if (_direction != Vector2.zero)
    //        {
    //            _rigidbody.AddForce(_direction * _speed);
    //        }
    //    }
}
