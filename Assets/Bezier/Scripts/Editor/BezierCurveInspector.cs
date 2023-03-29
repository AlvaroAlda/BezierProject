using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BezierCurve))]
public class BezierCurveInspector : Editor
{
	private BezierCurve curve;
	private Transform handleTransform;
	private Quaternion handleRotation;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }

    private void OnSceneGUI()
	{
		curve = target as BezierCurve;
		handleTransform = curve.transform;
		handleRotation = Tools.pivotRotation == PivotRotation.Local ?
			handleTransform.rotation : Quaternion.identity;

		Vector3 p0 = ShowPoint(0);
		Vector3 p1 = ShowPoint(1);
		Vector3 p2 = ShowPoint(2);
		Vector3 p3 = ShowPoint(3);

		Handles.color = Color.gray;
		Handles.DrawLine(p0, p1);
		Handles.DrawLine(p2, p3);

		Handles.color = Color.white;
		Vector3 lineStart = curve.GetPoint(0);

		Handles.color = Color.green;
		Handles.DrawLine(lineStart, lineStart + curve.GetDirection(0f));

		for (int i = 1; i <= curve.lineSteps; i++)
        {
			Vector3 lineEnd = curve.GetPoint(i/(float)curve.lineSteps);
			Handles.color = Color.white;
			Handles.DrawLine(lineStart, lineEnd);

			Handles.color = Color.green;
			Handles.DrawLine(lineEnd, lineEnd + curve.GetDirection(i / (float)curve.lineSteps));
			lineStart = lineEnd;
        }

	}

	private Vector3 ShowPoint(int index)
	{
		Vector3 point = handleTransform.TransformPoint(curve.points[index]);
		EditorGUI.BeginChangeCheck();
		point = Handles.DoPositionHandle(point, handleRotation);
		if (EditorGUI.EndChangeCheck())
		{
			Undo.RecordObject(curve, "Move Point");
			EditorUtility.SetDirty(curve);
			curve.points[index] = handleTransform.InverseTransformPoint(point);
		}
		return point;
	}
}
