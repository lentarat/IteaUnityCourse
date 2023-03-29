using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private float _shotPower = 1f;
    [SerializeField] private Transform _shotPosition;
    [SerializeField] private Transform _shotParticleEffect;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Timer _timer;
    private void Awake()
    {
        _timer.OnTimerEnd += Shoot;
    }
    private void OnDisable()
    {
        _timer.OnTimerEnd -= Shoot;
    }
    private void ButtonClicked()
    {
        Shoot();
    }
    private void Shoot()
    {
        //_rigidbody.AddExplosionForce(_shotPower, _shotPosition.position, _shotRadius);
        _rigidbody.AddForce((_shotParticleEffect.position - _shotPosition.position) * _shotPower, ForceMode.Impulse);
    }
}
