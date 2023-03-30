using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    private Transform _startPosition;

    private LineRenderer _line;
    private void Awake()
    {
        //_startPosition = GetComponent<SpringJoint>().c
    }
    private void Update()
    {
        _line.SetPosition(0, _startPosition.position);
        _line.SetPosition(1, transform.position);
    }
}
