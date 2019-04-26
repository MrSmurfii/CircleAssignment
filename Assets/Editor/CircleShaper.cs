using System;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(CircleDrawer))]
public class CircleShaper : Editor
{

    private CircleDrawer selectedDrawer;
    float snap = 0.5f;
    float snapint = 1f;
    private void OnEnable() {
        selectedDrawer = target as CircleDrawer;
    }

    private void OnSceneGUI() {
        GameObject circleTarget = selectedDrawer.target;
        if (!target)
            return;

        HandleRadius(circleTarget);
        HandleSides(circleTarget);
        selectedDrawer.DrawCircle();
    }

    private void HandleSides(GameObject circleTarget) {
        Color oldColor = Handles.color;

        EditorGUI.BeginChangeCheck();
        Handles.color = Color.red;
        float sides = Handles.ScaleSlider(selectedDrawer.sides, circleTarget.transform.position, circleTarget.transform.up, Quaternion.identity, selectedDrawer.sides, snapint);
        int realSides = (int)sides;
        realSides = Mathf.Clamp(realSides, 3, int.MaxValue);
        if(EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(target, "Sides amount");
            selectedDrawer.sides = realSides;
        }
        Handles.Label(circleTarget.transform.position + circleTarget.transform.up * selectedDrawer.sides, "Sides", EditorGUIUtility.GetBuiltinSkin(EditorSkin.Scene).textField);
        Handles.color = oldColor;
    }

    private void HandleRadius(GameObject circleTarget) {
        Color oldColor = Handles.color;

        EditorGUI.BeginChangeCheck();
        Handles.color = Color.green;
        float radius = Handles.ScaleSlider(selectedDrawer.radius, circleTarget.transform.position, circleTarget.transform.forward, Quaternion.identity, selectedDrawer.radius, snap);
        radius = Mathf.Clamp(radius, 5f, 100f);
        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(target, "Change Radius");
            selectedDrawer.radius = radius;
        }
        Handles.Label(circleTarget.transform.position + circleTarget.transform.forward * selectedDrawer.radius, "Radius", EditorGUIUtility.GetBuiltinSkin(EditorSkin.Scene).textField);
    }
}
