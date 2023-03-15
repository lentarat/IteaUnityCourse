using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droid3Behaviour : MonoBehaviour, IPatrol
{
    void Update()
    {
        Shcho();
    }
    public void Shcho()
    {
        Debug.Log(IPatrol.a);
    }
}
