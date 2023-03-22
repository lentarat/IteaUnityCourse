using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Elevator : MonoBehaviour
{
    //private Light2D _light;
    //private float _slowDownEffectModifier;
    private void FixedUpdate()
    {
        if (transform.localPosition.y > -2.74f)
        {
            transform.position += 0.025f * Vector3.down;
        }
        //else if (transform.localPosition.y < -2f)
        //{
        //    _slowDownEffectModifier
        //    Debug.Log(Mathf.Log10(_slowDownEffectModifier));
        //}
        else
        {
            Destroy(this);
        }
    }
}
