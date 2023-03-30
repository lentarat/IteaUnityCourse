using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Button : MonoBehaviour
{
    //[SerializeField] private Animator _animator;
    
    public Action OnButtonClicked;

    private bool _buttonWasClicked;
    //private bool _animationIsPlaying;

    //used by animator
    private void ButtonClicked()
    {
        OnButtonClicked();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!_buttonWasClicked && collision.gameObject.layer == LayerMask.NameToLayer("BlueBall"))
        {
            _buttonWasClicked = true;
            //if (_animationIsPlaying) return;
            //_animationIsPlaying = true;
            //_animator.Play("ButtonClick");
            ButtonClicked();
        }
    }
}
