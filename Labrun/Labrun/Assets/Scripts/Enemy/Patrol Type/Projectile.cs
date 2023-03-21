using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]private float _projectileSpeed;
    private Animator _animator;
    private Transform _destination;
    private Vector3 _direction;
    private LayerMask _playerLayer;
    private void Start()
    {
        _destination = FindObjectOfType<PlayerMovement>().transform;
        _direction = _destination.position - transform.position;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        _playerLayer = LayerMask.NameToLayer("Player");
        _animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {
        transform.position += Time.deltaTime * _projectileSpeed * _direction.normalized;
    }
    private void DestroyProjectile()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == _playerLayer)
        {
            _projectileSpeed = 1f;
            _animator.Play("Droid3Projectile_Impact");
        }
    }
}
