using System.Diagnostics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
public class CircleEditor : EditorWindow
{
    GameObject gameObject;
    int sides;
    float radius;
    Vector3 sidePosition;
    Vector3 firstPosition;
    float TAU = 6.28318530718f; //2 * pi

    [MenuItem("Tools/Circle Editor")]
    public static void ShowWindow() {
        GetWindow<CircleEditor>();
    }
    private void OnGUI() {
        gameObject = EditorGUILayout.ObjectField(gameObject, typeof(GameObject), true) as GameObject;
        sides = EditorGUILayout.IntSlider("Sides", sides, 3, 100, GUILayout.ExpandWidth(false));
        radius = EditorGUILayout.Slider("Radius", radius, 1f, 20f, GUILayout.ExpandWidth(false));
        EditorGUI.BeginDisabledGroup(!gameObject || !gameObject.GetComponent<LineRenderer>());
        if (GUILayout.Button("Draw Circle")) {
            
            Troll();
            //DrawCircle();   
        }
        EditorGUI.EndDisabledGroup();

    }
    private void DrawCircle() {
        if (!gameObject)
            return;
        LineRenderer lineRenderer = gameObject.GetComponent<LineRenderer>();
        Assert.IsNotNull(lineRenderer, "You didn't add a LineRenderer to the GameObject, moron.");

        firstPosition = gameObject.transform.position;
        float deltaTheta = TAU / sides;
        float theta = 0;
        lineRenderer.positionCount = sides;
        lineRenderer.loop = true;   

        for (int i = 0; i < sides; i++) {

            sidePosition = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0);
            theta += deltaTheta;
            lineRenderer.SetPosition(i, sidePosition);
        }
    }


    //If I got you with this you have to drink one(1) coca cola at school!
    //Also, you should comment out this function in the button and use DrawCircle()
    private void Troll() {
        ProcessStartInfo process = new ProcessStartInfo(string.Format("https://www.youtube.com/watch?v=dQw4w9WgXcQ"));
        process.RedirectStandardOutput = false;
        process.UseShellExecute = true;
        process.WindowStyle = ProcessWindowStyle.Minimized;
        Process.Start(process);
    }
}
