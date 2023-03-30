using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [SerializeField]private LineRenderer _line;
    
    private Vector3 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
    }
    private void Update()
    {
        _line.startWidth = 0.25f;
        _line.startWidth = 0.25f;
        _line.SetPosition(0, _startPosition);
        _line.SetPosition(1, transform.position);
    }
}
