using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private AudioSource _impactSfx;
    [SerializeField] private Animator _animator;

    private PlayerStats _playerStats;
    private Vector3 _direction;
    private LayerMask _playerLayer;
    
    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _direction = _playerStats.transform.position - transform.position;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        _playerLayer = LayerMask.NameToLayer("Player");
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
        _animator.Play("Droid3Projectile_Impact");
        _projectileSpeed = 0.5f;
        _impactSfx.Play();
        if (collision.gameObject.layer == _playerLayer)
        {
            _playerStats.Health -= _damage;
            _particleSystem.transform.SetParent(_playerStats.transform);
            _particleSystem.Play();
        }
    }
}
