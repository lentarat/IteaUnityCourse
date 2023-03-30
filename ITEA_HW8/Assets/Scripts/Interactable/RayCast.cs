using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit ))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("YellowBall"))
                {
                    hit.collider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }
            }
        }
    }
}
