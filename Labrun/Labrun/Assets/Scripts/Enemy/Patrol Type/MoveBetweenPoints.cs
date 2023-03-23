using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    [SerializeField] private float _yOffsetOfRoutePoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _pointsAccuracy;

    private Vector2[] _routePoints;
    private Vector3 _direction;
    private float _angle;
    private int _currentPointIndex = 1;
    private bool _goingInverse;
    private bool _routeIsInverted;
    //public float Speed
    //{
    //    set =>_speed = value;
    //}

    //private Transform _droidTransform;
    //public Transform DroidTransform
    //{
    //    set => _droidTransform = value;
    //}
    private void Awake()
    {
        AdjustPointsYCoordinate();
    }
    public void AdjustPointsYCoordinate()
    {
        Transform[] tempTransforms = transform.GetComponentsInChildren<Transform>();
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
        if (Vector2.Distance(transform.position, _routePoints[_currentPointIndex]) < _pointsAccuracy)
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
            if (tempAngle != _angle)
            {
                StartCoroutine(RotateAngle(tempAngle));
            }
        }
        transform.position += Time.deltaTime * _speed * _direction.normalized;
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
