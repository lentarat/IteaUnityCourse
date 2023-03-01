using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _sens;
    [SerializeField] private Transform _cameraPos;
    private Vector3 _headOffset = new Vector3(0f, 1.532f, 0f);
    private Vector3 _moveDir;
    private float _xRot = 0f;
    private float _yRot = 0f;

    private void LateUpdate()
    {
        RotateCamera();
    }
    private void FixedUpdate()
    {
        MovePlayer();
        transform.rotation = Quaternion.Euler(0f, _xRot, 0f);
    }
    private void MovePlayer()
    {
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        _moveDir = transform.forward * zMove + transform.right * xMove;
        _moveDir.y = _rb.velocity.y;
        _rb.velocity = _moveDir * _moveSpeed;
    }
    private void RotateCamera()
    {
        _xRot += Input.GetAxisRaw("Mouse X") * _sens;
        _yRot += Input.GetAxisRaw("Mouse Y") * _sens;
        _cameraPos.transform.rotation = Quaternion.Euler(-_yRot, _xRot, 0f);
        _cameraPos.transform.position = transform.position + _headOffset;
    }
}