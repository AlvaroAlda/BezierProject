using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public Vector3[] points;
    [Min(1)]public int lineSteps;

    public void Reset()
    {
        points = new Vector3[]
        {
            new(1, 0, 0),
            new(2, 0, 0),
            new(3, 0, 0),
            new(4, 0, 0),
        };
    } 

    public Vector3 GetPoint (float t)
    {
        return transform.TransformPoint(Bezier.GetPoint(points[0], points[1], points[2], points[3], t));
    }

    private Vector3 GetVelocity (float t)
    {
        return transform.TransformPoint(Bezier.GetFirstDerivative(points[0], points[1], points[2], points[3], t)) - transform.position;
    }

    public Vector3 GetDirection (float t)
    {
        return GetVelocity(t).normalized;
    }

}
