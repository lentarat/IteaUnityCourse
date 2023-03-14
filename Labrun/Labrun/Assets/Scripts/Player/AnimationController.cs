using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private int _currentState;
    [SerializeField] private Animator _animator;
    
    public readonly int Idle = Animator.StringToHash("Idle");
    public readonly int Walk = Animator.StringToHash("Walk");
    public readonly int Run = Animator.StringToHash("Run");
    public readonly int Jump = Animator.StringToHash("Jump");
    public readonly int DuckDown = Animator.StringToHash("DuckDown");
    public readonly int DuckUp = Animator.StringToHash("DuckUp");
    public readonly int Disappear = Animator.StringToHash("Disappear");
    public readonly int Die = Animator.StringToHash("Die");

    private void Start()
    {
        ChangeAnimationState(Idle);
    }
    public void ChangeAnimationState(int newState)
    {
        if (_currentState == newState) return;
        _animator.Play(newState);
        _currentState = newState;
    }
}