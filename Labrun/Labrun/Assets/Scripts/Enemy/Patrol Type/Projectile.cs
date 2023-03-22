using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _projectileSpeed;
    [SerializeField] private float _damage;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioManager _audioManager;
   
    private PlayerStats _playerStats;
    private Vector3 _direction;
    private LayerMask _playerLayer;
    private bool _hit;
    
    private void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _direction = _playerStats.transform.position - transform.position;
        float angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        _playerLayer = LayerMask.NameToLayer("Player");

        _audioManager.Play("Shoot");
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
        if (!_hit)
        {
            _hit = true;
            _animator.Play("Droid3Projectile_Impact");
            _audioManager.Play("Impact");
            _projectileSpeed = 0.5f;
            if (collision.gameObject.layer == _playerLayer)
            {
                _playerStats.Health -= _damage;
            }
        }
    }
}
