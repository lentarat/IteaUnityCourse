using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Trap
{
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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            IsActivated = false;
        }
        else  if (Input.GetKeyDown(KeyCode.Z))
        {
            IsActivated = true;
        }
    }
    //protected override void DealDamage(Collider2D col)
    //{

    //}
}
