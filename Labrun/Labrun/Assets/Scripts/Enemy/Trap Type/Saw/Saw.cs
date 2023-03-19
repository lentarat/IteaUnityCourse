using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Trap
{
    private readonly int Activate = Animator.StringToHash("Activate");
    private readonly int Deactivate = Animator.StringToHash("Deactivate");
    private readonly int Idle = Animator.StringToHash("Idle");

    protected bool IsActivated
    {
        get => _isActivated;
        set
        {
            if (value)
            {
                _animator.Play(Activate);
            }
            else
            {
                _animator.Play(Deactivate);
            }
        }
    }
    //protected override void DealDamage(Collider2D col)
    //{

    //}
}
