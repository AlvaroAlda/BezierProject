using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    [SerializeField] private BezierSpline spline;
    [SerializeField] private float resolution = 1000;
    [SerializeField] private float roadWidth;
    
    private List<Vector3> centeredPositions;
    private List<Vector3> directions;
    
    private void OnDrawGizmos()
    {
        Intialize();
        //Representation of points
        for (var i = 0; i < centeredPositions.Count; i++)
        {
            Gizmos.DrawSphere(centeredPositions[i], 0.1f);
            
            Gizmos.color = Color.green;

            if (i == centeredPositions.Count - 1) return;
            var forward = (centeredPositions[i + 1] - centeredPositions[i]).normalized;
            var leftPoint = Vector3.Cross((Vector3.up).normalized, forward) + centeredPositions[i];
            var rightPoint = -Vector3.Cross((Vector3.up).normalized, forward) + centeredPositions[i];
        
            Gizmos.DrawSphere(centeredPositions[i], 0.2f);
            Gizmos.DrawSphere(rightPoint, 0.2f);
            Gizmos.DrawSphere(leftPoint , 0.2f);
        }
    }

    private void Intialize()
    {
        centeredPositions = new List<Vector3>();
        directions = new List<Vector3>();
        for (var i = 0f; i < 1f; i+= 1/resolution)
        {
            centeredPositions.Add(spline.GetPoint(i));
            directions.Add(spline.GetDirection(i));
        }
    }

    private void Awake()
    {
        Intialize();
        
        
    }
}
