using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    // protected vs public?
    [SerializeField] private float _damage;
    protected float Damage => _damage; 

    protected PlayerStats _playerStats;
    protected LayerMask _playerLayer;
    protected Animator _animator;

    protected bool _isActivated = true;
    
    protected virtual void DealDamage(Collider2D collision)
    {
        if (collision.gameObject.layer == _playerLayer)
        {
            _playerStats.Health -= _damage;
        }
    }
    private void Awake()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
        _playerLayer = LayerMask.NameToLayer("Player");
        _animator = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_isActivated)
        {
            DealDamage(collision);
        }
    }
}
