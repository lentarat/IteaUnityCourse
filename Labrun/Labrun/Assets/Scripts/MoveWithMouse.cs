using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    [SerializeField] private SpringJoint2D _spring;
    private Camera _cam;
    private bool _hanging;
    private void Start()
    {
        _cam = Camera.main;
    }
    private void Update()
    {
        Vector3 _mousePosition = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.nearClipPlane));
        if (Input.GetMouseButtonDown(0) && !_hanging)
        {
            _spring.enabled = true;
            _spring.connectedAnchor = _mousePosition;
            _spring.frequency = 0.25f;
            _spring.distance = 3f;
            _hanging = true;
        }
        else if (Input.GetMouseButton(0) && _hanging)
        {
            if (_spring.distance > .25f)
                _spring.distance -= Time.deltaTime;
            if (_spring.frequency < 2f)
                _spring.frequency += Time.deltaTime;
        }
        else if (Input.GetMouseButton(1))
        {
            _hanging = false;
            _spring.enabled = false;
        }
    }
}
