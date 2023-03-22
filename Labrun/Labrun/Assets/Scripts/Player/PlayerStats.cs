using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float _health;
    public float Health
    { get => _health;
        set
        {
            _health = value;
            if (_health <= 0f)
            {
                gameObject.GetComponent<AnimationController>().ChangeAnimationState(Animator.StringToHash("Die"));
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            }
        }
    }
    [SerializeField] private float _walkSpeed;
    public float WalkSpeed { get => _walkSpeed; set => _walkSpeed = value; }
    [SerializeField] private float _runSpeed;
    public float RunSpeed { get => _runSpeed; set => _runSpeed = value; }
    [SerializeField] private float _jumpForce;
    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
}
