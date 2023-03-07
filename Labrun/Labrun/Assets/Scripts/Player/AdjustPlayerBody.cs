using UnityEngine;

public class AdjustPlayerBody : MonoBehaviour
{
    private Rigidbody2D[] points;
    private DistanceJoint2D[] distanceJoints;
    private SpringJoint2D[] springJoints;
    private HingeJoint2D[] hingeJoints;

    private void Awake()
    {
        FindComponents();
        ManageDistantJoints();
        ManageSpringJoints();
        ManageHingeJoints();
    }
    private void FindComponents()
    {
        points = gameObject.GetComponentsInChildren<Rigidbody2D>();
        distanceJoints = gameObject.GetComponentsInChildren<DistanceJoint2D>();
        springJoints = gameObject.GetComponentsInChildren<SpringJoint2D>();
        hingeJoints = gameObject.GetComponentsInChildren<HingeJoint2D>();
    }
    private void ManageDistantJoints()
    {
        for (int i = 0; i < points.Length-1; i++)
        {
            if (i == points.Length - 2)
            {
                distanceJoints[i].connectedBody = points[1];
            }
            else
            {
                distanceJoints[i].connectedBody = points[i + 2];
            }
        }
    }
    private void ManageSpringJoints()
    {
        for (int i = 1; i < points.Length; i++)
        {
            if (i == 1)
            {
                springJoints[0].connectedBody = points[points.Length-1];
            }
            else
            {
                springJoints[3 * i - 3].connectedBody = points[i-1];
            }
            springJoints[3 * i - 2].connectedBody = points[0];
            if (i == points.Length - 1)
            {
                springJoints[3 * i - 1].connectedBody = points[1];
            }
            else
            {
                springJoints[3 * i - 1].connectedBody = points[i + 1];
            }
        }
    }
    private void ManageHingeJoints()
    {
        for (int i = 0; i < points.Length - 1; i++)
        {
            if (i == points.Length - 2)
            {
                hingeJoints[i].connectedBody = points[1];
            }
            else
            {
                hingeJoints[i].connectedBody = points[i + 2];
            }
        }
    }
}
