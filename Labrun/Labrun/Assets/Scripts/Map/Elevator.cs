using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private void Start()
    {
        //StartCoroutine(DescendDown());
    }
    private void FixedUpdate()
    {
        if (transform.localPosition.y > -2.74f)
        {
            transform.position += 0.025f * Vector3.down;
        }
        else
        {
            Destroy(this);
        }
    }
    //private IEnumerator DescendDown()
    //{
    //    while (transform.localPosition.y> -2.74f)
    //    {
    //        Debug.Log(Time.deltaTime + " " + Time.time);
    //        transform.position += /*Time.deltaTime * */Vector3.down * 0.005f;
    //        yield return null;
    //    }
    //    yield return null;
    //}
}
