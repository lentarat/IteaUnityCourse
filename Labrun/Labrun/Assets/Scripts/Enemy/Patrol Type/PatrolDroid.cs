//public interface IPatrol
//{
//    void Patrol();
//    //void Move();
//    //void Seek();
//    //void Detect();
//    //void Chase();
//}

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public abstract class PatrolDroid : MonoBehaviour
{
    public Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody;
    private Transform _playerTransform;
    private BoxCollider2D _boxCollider;

    [SerializeField] float yOffsetOfRoutePoints;
    [SerializeField] private float _speed;

    private Vector2[] _routePoints;
    private Vector3 _direction;
    private float _angle;
    private int _currentPointIndex = 1;
    private bool goingInverse;
    public void AssignComponents()
    {
        _animator = gameObject.GetComponent<Animator>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _boxCollider = gameObject.GetComponent<BoxCollider2D>();
        _playerTransform = GameObject.FindWithTag("Player").transform;
    }

    public void AdjustPointsYCoordinate()
    {
        Transform[] tempTransforms = gameObject.GetComponentsInChildren<Transform>();
        List<Vector2> tempRoutePoints = new List<Vector2>();
        foreach (var go in tempTransforms)
        {
            if (go.CompareTag("RoutePoint"))
            {
                
                tempRoutePoints.Add(new Vector2( go.position.x, Physics2D.Raycast(go.position, Vector2.down).point.y + yOffsetOfRoutePoints));
                Destroy(go.gameObject);
            }
        }
        _routePoints = tempRoutePoints.ToArray();
        transform.position = _routePoints[0];
        _direction = _routePoints[1] - _routePoints[0];
        if (_direction.x > 0f)
        {
            _spriteRenderer.flipX = true;
        }
        else
        {
            _spriteRenderer.flipX = false;
        }
    }
    public void Move()
    {
        //if (_rigidbody.IsAwake())
        //{
        //    _rigidbody.Sleep();
        //    _boxCollider.enabled = false;
        //}
        if (Vector2.Distance(transform.position, _routePoints[_currentPointIndex]) < 0.1f)
        {
            float tempAngle = 0f;
            if (_currentPointIndex == _routePoints.Length - 1)
            {
                goingInverse = true; 
                _spriteRenderer.flipX = false;
            }
            else if (_currentPointIndex == 0)
            {
                goingInverse = false;
                _spriteRenderer.flipX = true;
            }

            if (goingInverse)
            {
                _direction = _routePoints[_currentPointIndex - 1] - _routePoints[_currentPointIndex];
                _currentPointIndex--;

                if (_direction.y > 0.1f)
                {
                    tempAngle = -Vector2.Angle(Vector2.left, _direction);
                }
                else if (_direction.y < -0.1f)
                {
                    tempAngle = Vector2.Angle(Vector2.left, _direction);
                }
                else
                {
                    tempAngle = 0f;
                }
            }
            else
            {
                _direction = _routePoints[_currentPointIndex + 1] - _routePoints[_currentPointIndex];
                _currentPointIndex++;
                if (_direction.y > 0.1f)
                {
                    tempAngle = Vector2.Angle(Vector2.right, _direction);
                }
                else if (_direction.y < -0.1f)
                {
                    tempAngle = -Vector2.Angle(Vector2.right, _direction);
                }
                else
                {
                    tempAngle = 0f;
                }
            }
            StartCoroutine(RotateAngle(tempAngle));
        }
        transform.position += Time.deltaTime * _speed * _direction.normalized;
    }
    public abstract void Seek();
    public void Chase()
    {
        //if (_rigidbody.IsSleeping())
        //{
        //    _rigidbody.WakeUp();
        //    _boxCollider.enabled = true;
        //}
        //_direction = transform.position - _playerTransform.position;
        //_rigidbody.AddForce(Time.deltaTime * _speed * _direction);
    }
    private IEnumerator RotateAngle(float toAngle)
    {
        if (toAngle > _angle)
        {
            while (toAngle > _angle)
            {
                _angle += Time.deltaTime * 100f;
                transform.rotation = Quaternion.Euler(0f, 0f, _angle);
                yield return null;
            }
        }
        else
        {
            while (toAngle < _angle)
            {
                _angle -= Time.deltaTime * 100f;
                transform.rotation = Quaternion.Euler(0f, 0f, _angle);
                yield return null;
            }
        }
        yield return null;
    }
}
