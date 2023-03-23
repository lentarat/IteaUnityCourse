using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private NumericPanel numericPanel;
    [SerializeField] private Collider2D _wall;
    [SerializeField] private Animator _animator;
    [SerializeField] private AnimationController _animationController;
    
    private PlayerStats _playerStats;

    private bool _ready;
    private readonly int _activateAnimation = Animator.StringToHash("Activate");
    private readonly int _deactivateAnimation = Animator.StringToHash("Deactivate");

    private void Awake()
    {
        numericPanel.OnAccessGranted += Launch;
    }
    private void Launch()
    {
        _ready = true;
    }
    private void KillPlayer()
    {
        _playerStats.Health -= 100f;
    }
    private void Deactivate()
    {
        _animationController.ChangeAnimationState(_deactivateAnimation);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_ready && collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            _wall.enabled = true;
            _animator.enabled = true;
            _animationController.ChangeAnimationState(_activateAnimation);
            _playerStats = collision.gameObject.GetComponent<PlayerStats>();
        }
    }
}
