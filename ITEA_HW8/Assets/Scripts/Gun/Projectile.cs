using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Gun"))
        {
            Explode();
        }
    }
    private void Explode()
    {
        RaycastHit[] colliders = Physics.SphereCastAll(transform.position, _explosionRadius, transform.up);
        foreach (RaycastHit go in colliders)
        {
            if (go.collider.TryGetComponent<Rigidbody>(out Rigidbody rigidbody))
            {
                rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
        Destroy(this);
    }
}
