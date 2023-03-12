using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    
    [SerializeField] private Rigidbody2D _rigidbody;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.layer + " " + LayerMask.NameToLayer("Ground"));
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.inertia = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _rigidbody.velocity = Vector2.zero;
            _rigidbody.inertia = 0f;
        }
    }
}
