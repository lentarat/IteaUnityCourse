using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustPlayerBody : MonoBehaviour
{
    [SerializeField] private float _bodyRadius;
    [SerializeField] private Rigidbody2D _parentRigidBody;
    //private Rigidbody2D[] _rigidbodyList;
    private List<Rigidbody2D> _rigidbodyList = new List<Rigidbody2D>();
    private DistanceJoint2D[] _distanceJoints;
    //private SpringJoint2D[] _springJoints;
    private List<SpringJoint2D> _springJointsList = new List<SpringJoint2D>();
    private HingeJoint2D[] _hingeJoints;

    private void Awake()
    {
        FindComponents();
        //Place_rigidbodyList();
        ManageDistantJoints();
        ManageSpringJoints();
        ManageHingeJoints();
    }
    private void FindComponents()
    {
        _hingeJoints = gameObject.GetComponentsInChildren<HingeJoint2D>();
        //_rigidbodyList = gameObject.GetComponentsInChildren<Rigidbody2D>();
        _distanceJoints = gameObject.GetComponentsInChildren<DistanceJoint2D>();
        //springJoints = gameObject.GetComponentsInChildren<SpringJoint2D>();


        foreach (HingeJoint2D go in _hingeJoints)
        {
            _rigidbodyList.Add(go.gameObject.GetComponent<Rigidbody2D>());
            _springJointsList.AddRange(go.gameObject.GetComponents<SpringJoint2D>());
        }
        //points = rbList.;
    }
    //private void PlacePoints()
    //{
    //    float currentAngleBetweenPoints = 0;
    //    Vector2 currentPosition = Vector2.right;
    //    Vector2 nextPosition;
    //    float angleBetweenPoints = 360f / (points.Length - 1);

    //    for (int i = 1; i < points.Length; i++)
    //    {
    //        if (i == 0)
    //            points[i].transform.localPosition = Vector2.right * _bodyRadius;
    //        else
    //        {
    //            currentAngleBetweenPoints += 36f * Mathf.Deg2Rad;   
    //            nextPosition.x = currentPosition.x * Mathf.Cos(currentAngleBetweenPoints) + currentPosition.y * Mathf.Sin(currentAngleBetweenPoints);
    //            nextPosition.y = -currentPosition.x * Mathf.Sin(currentAngleBetweenPoints) + currentPosition.y * Mathf.Cos(currentAngleBetweenPoints);
    //            points[i].transform.localPosition = nextPosition * _bodyRadius;
    //            currentPosition = nextPosition;
    //            break;
    //        }
    //    }

    //}
    private void ManageDistantJoints()
    {
        for (int i = 0; i < _rigidbodyList.Count-1; i++)
        {
            _distanceJoints[i].connectedBody = _rigidbodyList[i + 1];
        }
        _distanceJoints[_rigidbodyList.Count - 1].connectedBody = _rigidbodyList[0];
    }
    private void ManageSpringJoints()
    {
        //for (int i = 1; i < _rigidbodyList.Count; i++)
        //{
        //    if (i == 1)
        //    {
        //        _springJointsList[0].connectedBody = _rigidbodyList[_rigidbodyList.Count-1];
        //    }
        //    else
        //    {
        //        _springJointsList[3 * i - 3].connectedBody = _rigidbodyList[i-1];
        //    }
        //    _springJointsList[3 * i - 2].connectedBody = _parentRigidBody;
        //    if (i == _rigidbodyList.Count - 1)
        //    {
        //        _springJointsList[3 * i - 1].connectedBody = _rigidbodyList[0];
        //    }
        //    else
        //    {
        //        _springJointsList[3 * i - 1].connectedBody = _rigidbodyList[i + 1];
        //    }
        //}

        for (int i = 0; i < _rigidbodyList.Count; i++)
        {
            if (i == 0)
            {
                _springJointsList[0].connectedBody = _rigidbodyList[_rigidbodyList.Count - 1];
            }
            else
            {
                _springJointsList[3 * i].connectedBody = _rigidbodyList[i - 1];
            }

            _springJointsList[3 * i + 1].connectedBody = _parentRigidBody;

            if (i == _rigidbodyList.Count - 1)
            {
                _springJointsList[3 * i + 2].connectedBody = _rigidbodyList[0];
            }
            else
            {
                _springJointsList[3 * i + 2].connectedBody = _rigidbodyList[i + 1];
            }
        }
        
    }
    private void ManageHingeJoints()
    {
        for (int i = 0; i < _rigidbodyList.Count - 1; i++)
        {
            _hingeJoints[i].connectedBody = _rigidbodyList[i + 1];
        }
        _hingeJoints[_rigidbodyList.Count - 1].connectedBody = _rigidbodyList[0];
    }
}
