using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Rendering.Universal;

public class PatrolDroid : MonoBehaviour
{
    public Animator _animator;

    [SerializeField] private float _yOffsetOfRoutePoints;
    [SerializeField] private float _speed;

    [SerializeField]protected Transform _playerPosition;
    protected Light2D _light;
    private Vector2[] _routePoints;
    private Vector3 _direction;
    private float _angle;
    private int _currentPointIndex = 1;
    private bool _goingInverse;
    private bool _routeIsInverted;
    public void AssignComponents()
    {
        _animator = gameObject.GetComponent<Animator>();
        _playerPosition = FindObjectOfType<PlayerStats>().transform;
        _light = gameObject.GetComponentInChildren<Light2D>();
        //_spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        //_rigidbody = gameObject.GetComponent<Rigidbody2D>();
        //_boxCollider = gameObject.GetComponent<BoxCollider2D>();
        //_playerTransform = GameObject.FindWithTag("Player").transform;
    }

    public void AdjustPointsYCoordinate()
    {
        Transform[] tempTransforms = gameObject.GetComponentsInChildren<Transform>();
        List<Vector2> tempRoutePoints = new List<Vector2>();
        foreach (var go in tempTransforms)
        {
            if (go.CompareTag("RoutePoint"))
            {

                tempRoutePoints.Add(new Vector2(go.position.x, Physics2D.Raycast(go.position, Vector2.down).point.y + _yOffsetOfRoutePoints));
                Destroy(go.gameObject);
            }
        }
        _routePoints = tempRoutePoints.ToArray();
        transform.position = _routePoints[0];
        _direction = _routePoints[1] - _routePoints[0];
        if (_direction.x > 0f)
        {
            transform.rotation = Quaternion.Euler(Vector3.up * 180f);
        }
        else
        {
            _routeIsInverted = true;
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
                _goingInverse = true;
                if (_routeIsInverted)
                {
                    transform.rotation = Quaternion.Euler(Vector3.up * 180f);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(Vector3.zero);
                }
            }
            else if (_currentPointIndex == 0)
            {
                _goingInverse = false;
                if (_routeIsInverted)
                {
                    transform.rotation = Quaternion.Euler(Vector3.zero);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(Vector3.up * 180f);
                }
            }

            if (_goingInverse)
            {
                _direction = _routePoints[_currentPointIndex - 1] - _routePoints[_currentPointIndex];
                _currentPointIndex--;

                if (_direction.y > 0.1f)
                {
                    if (_routeIsInverted)
                    {
                        tempAngle = Vector2.Angle(Vector2.right, _direction);
                    }
                    else
                    {
                        tempAngle = -Vector2.Angle(Vector2.left, _direction);
                    }
                }
                else if (_direction.y < -0.1f)
                {
                    if (_routeIsInverted)
                    {
                        tempAngle = -Vector2.Angle(Vector2.right, _direction);
                    }
                    else
                    {
                        tempAngle = Vector2.Angle(Vector2.left, _direction);
                    }
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
                    if (_routeIsInverted)
                    {
                        tempAngle = -Vector2.Angle(Vector2.left, _direction);
                    }
                    else
                    {
                        tempAngle = Vector2.Angle(Vector2.right, _direction);
                    }
                }
                else if (_direction.y < -0.1f)
                {
                    if (_routeIsInverted)
                    {
                        tempAngle = Vector2.Angle(Vector2.left, _direction);
                    }
                    else
                    {
                        tempAngle = -Vector2.Angle(Vector2.right, _direction);
                    }
                }
                else
                {
                    tempAngle = 0f;
                }
            }

            //if (tempAngle != _angle)
            //{
            StartCoroutine(RotateAngle(tempAngle));
            //}
        }
        transform.position += Time.deltaTime * _speed * _direction.normalized;
    }
    public void Seek()
    {
        if (Vector2.Distance(_playerPosition.position, transform.position) < _light.pointLightOuterRadius &&
            Vector2.Angle((_playerPosition.position - transform.position).normalized, -transform.right) < 30f)
        {
            //Stop();
        }
        //Debug.Log(_light.pointLightOuterRadius +" " + Vector2.Distance(_playerPosition.position,transform.position));
        //Physics2D.Raycast(transform.position, new Vector2(_playerPosition.position.x, _playerPosition.position.y), _light.pointLightOuterRadius);  
    }
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
        if (transform.eulerAngles.y == 180f)
        {
            toAngle = -toAngle;
            if (toAngle < _angle)
            {
                while (toAngle < _angle)
                {
                    _angle -= Time.deltaTime * 100f;
                    transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, _angle);
                    yield return null;
                }
            }
            else
            {
                while (toAngle > _angle)
                {
                    _angle += Time.deltaTime * 100f;
                    transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, _angle);
                    yield return null;
                }
            }
        }
        else
        {
            if (toAngle < _angle)
            {
                while (toAngle < _angle)
                {
                    _angle -= Time.deltaTime * 100f;
                    transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, _angle);
                    yield return null;
                }
            }
            else
            {
                while (toAngle > _angle)
                {
                    _angle += Time.deltaTime * 100f;
                    transform.rotation = Quaternion.Euler(0f, transform.eulerAngles.y, _angle);
                    yield return null;
                }
            }
        }
        yield return null;
    }
}