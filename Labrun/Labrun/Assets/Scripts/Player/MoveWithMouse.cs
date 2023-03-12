using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    [SerializeField] private SpringJoint2D _spring;
    [SerializeField] private Rigidbody2D _tongue;
    [SerializeField] private float _tongueForce;
    [SerializeField] private float _tongueCatchDistance;
    private Camera _cam;
    private bool _hanging;
    private bool _tongueActive;
    private Vector3 _mousePositionWorld;
    private bool _leftMouseButtonClicked;
    private bool _tongueReady = true;

    

    private void Start()
    {
        _tongue.gameObject.SetActive(true);
        _cam = Camera.main;
    }
    private void Update()
    {
        GetInput();
        CatchTongue();
    }
    private void FixedUpdate()
    {
        MoveTongue();
    }
    private void MoveTongue()
    {
        if (_leftMouseButtonClicked && !_tongueActive)
        {
            _mousePositionWorld = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.nearClipPlane));
            Vector2 _tongueDirection = new Vector2(_mousePositionWorld.x - transform.position.x, _mousePositionWorld.y - transform.position.y).normalized;
            _tongue.AddForce(_tongueDirection * _tongueForce, ForceMode2D.Impulse);
            _leftMouseButtonClicked = false;
            _tongueActive = true;
        }
    }
    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if (Vector2.Distance(transform.position, _tongue.position) < _tongueCatchDistance)
            //{
            //    _tongueReady = true;
            //}
            //if (_tongueReady)
            //{
            //    _leftMouseButtonClicked = true;
            //    _tongueReady = false;
            //}
            if (Vector2.Distance(transform.position, _tongue.position) < _tongueCatchDistance)
            {
                _leftMouseButtonClicked = true;
            }
        }

        //_mousePositionWorld = _cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.nearClipPlane));  
        //if (Input.GetMouseButtonDown(0) && !_hanging)
        //{
        //    StartClimbing();
        //}                     поганий код
        //else if (Input.GetMouseButton(0) && _hanging)
        //{
        //    ContinueClimbing();
        //}
        //else if (Input.GetMouseButton(1))
        //{
        //    StopClimbing();
        //}
    }
    private void CatchTongue()
    {
        if(_tongueActive)
        {
            if (Vector2.Distance(transform.position, _tongue.position) < _tongueCatchDistance)
            {
                _tongue.velocity = Vector2.zero;
                _tongue.inertia = 0f;
                _tongue.transform.localPosition = Vector2.zero;
                _tongueActive = false;
            }
        }
    }


    private void StartClimbing()
    {
        //CheckRay();
        _spring.enabled = true;
        _spring.connectedAnchor = _mousePositionWorld;
        _spring.frequency = 0.25f;
        _spring.distance = 3f;
        _hanging = true;
    }
    
    private void ContinueClimbing()
    {
        if (_spring.distance > .25f)
            _spring.distance -= Time.deltaTime;
        if (_spring.frequency < 2f)
            _spring.frequency += Time.deltaTime;
    }
    private void StopClimbing()
    {
        _hanging = false;
        _spring.enabled = false;
    }
}
