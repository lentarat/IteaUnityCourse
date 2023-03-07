using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TongueController : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    
    [SerializeField] private Rigidbody2D _rigidBody;
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.layer + " " + LayerMask.NameToLayer("Ground"));
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            _rigidBody.velocity = Vector2.zero;
            _rigidBody.inertia = 0f;
        }
    }
}
