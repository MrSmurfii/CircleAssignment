using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(LineRenderer))]
public class CircleDrawer : MonoBehaviour
{

    public GameObject target;
    public float radius = 10f;
    public int sides = 3;
    Vector3 sidePosition;

    LineRenderer lineRenderer;
    float TAU = 6.28318530718f; //2 * pi

    private void Awake() {
        lineRenderer = GetComponent<LineRenderer>();
        Assert.IsNotNull(lineRenderer, "You didn't add a LineRenderer, moron!");
    }

    public void DrawCircle() {
        if (!lineRenderer)
            lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = sides;
        lineRenderer.loop = true;
        float deltaTheta = TAU / sides;
        float theta = 0;

        for (int i = 0; i < sides; i++) {
            lineRenderer.SetPosition(i, sidePosition);
            sidePosition = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0);
            theta += deltaTheta;
        }
    }
}
