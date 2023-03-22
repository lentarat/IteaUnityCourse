using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDamageTaken : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bleedingParticle;
    [SerializeField] private PlayerStats _playerStats;
    private void Awake()
    {
        _playerStats.OnDamageTaken += DamageTaken;
    }
    public void DamageTaken(float health)
    {
        _bleedingParticle.Play();
        if (health <= 0f)
        {
            gameObject.GetComponent<AnimationController>().ChangeAnimationState(Animator.StringToHash("Die"));
            gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().simulated = false;
        }
    }
}

