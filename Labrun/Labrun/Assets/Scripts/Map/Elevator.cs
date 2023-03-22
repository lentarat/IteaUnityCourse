using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Elevator : MonoBehaviour
{
    //private Light2D _light;
    //private float _slowDownEffectModifier;
    [SerializeField] private Transform _firstPoint;
    [SerializeField] private Transform _secondPoint;
    [SerializeField] private bool _oneWayElevator;
    private Vector3 _from;
    private Vector3 _to;

    [SerializeField] private float _speed;
    private Vector3 _direction;
    private bool _goingInverse;
    private void Start()
    {
        _from = _firstPoint.position;
        _to = _secondPoint.position;
        transform.position = _from;
        _direction = _to - _from;
    }
    private void SetDirection()
    {
        if (_goingInverse)
        {
            _to = _firstPoint.position;
            _from = _secondPoint.position;
            
        }
        else
        {
            _to = _secondPoint.position;
            _from = _firstPoint.position;
        }
        _direction = _to - _from;
    }
    private void Go()
    {
        transform.position += _speed * _direction;
        if (Vector3.Distance(transform.position, _to) < 0.1f)
        {
            if (_oneWayElevator)
            {
                Destroy(this);
            }
            _goingInverse = !_goingInverse;
            SetDirection();
        }
    }
    private void FixedUpdate()
    {
        Go();
    }
}
