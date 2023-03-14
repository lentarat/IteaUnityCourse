using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private string _currentState;
    [SerializeField] private Animator _animator;
    public void ChangeAnimationState(string newState)
    {
        if (_currentState == newState) return;
        _animator.Play(newState);
        _currentState = newState;
    }
}
