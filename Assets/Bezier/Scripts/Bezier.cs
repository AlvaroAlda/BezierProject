using UnityEngine;

//https://catlikecoding.com/unity/tutorials/curves-and-splines/
/// ////////////////////////////////////////////////////////////

public static class Bezier
{
    /////////////////////////////////// QUADRATIC  ///////////////////////////////////////////////////////////
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        //Lineal interpolation: The theoretical meaning of the quadratic bezier curve
        //Vector3.Lerp(Vector3.Lerp(p0, p1, t), Vector3.Lerp(p1, p2, t), t);

        //Resulting direct formula for Quadratic Bezier Curve
        //B(t) = (1 - t) ((1 - t) P0 + t P1) + t ((1 - t) P1 + t P2) 
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;

        return
            oneMinusT * oneMinusT * p0 +
            2f * oneMinusT * t * p1 +
            t * t * p2;
    }

    public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        //Derivate from the formula, getting the tangents at any point in the curve
        // B'(t) = 2 (1 - t) (P1 - P0) + 2 t (P2 - P1)
        return 2 * (1 -t) * (p1 - p0) + 2 * t * (p2 - p1);
    }


    /////////////////////////////////// CUBIC  ///////////////////////////////////////////////////////////
    public static Vector3 GetPoint(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        //B(t) = (1 - t)3 P0 + 3 (1 - t)2 t P1 + 3 (1 - t) t2 P2 + t3 P3
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            oneMinusT * oneMinusT * oneMinusT * p0 +
            3f * oneMinusT * oneMinusT * t * p1 +
            3f * oneMinusT * t * t * p2 +
            t * t * t * p3;
    }

    public static Vector3 GetFirstDerivative(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        //B'(t) = 3 (1 - t)2 (P1 - P0) + 6 (1 - t) t (P2 - P1) + 3 t2 (P3 - P2)
        t = Mathf.Clamp01(t);
        float oneMinusT = 1f - t;
        return
            3f * oneMinusT * oneMinusT * (p1 - p0) +
            6f * oneMinusT * t * (p2 - p1) +
            3f * t * t * (p3 - p2);
    }
}


