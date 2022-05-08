using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]

public class Track_LineController : MonoBehaviour
{
    private LineRenderer lr;
    private EdgeCollider2D ec2D;
    private Transform[] points;
    public Node_Gen_Create NodeGenCreate_Refence;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        ec2D = GetComponent<EdgeCollider2D>();
    }

    public void SetUpLine(Transform[] points)
    {
        lr.positionCount = points.Length;
        this.points = points;
    }

    public void Update()
    {
        if (NodeGenCreate_Refence.isReadyToDrawTrack == true)
        {
            for (int i = 0; i < points.Length; ++i)
            {
                lr.SetPosition(i, points[i].position);
            }
            SetEdgeCollider(lr);
        }
    }

    // Gives the points of the line renderer to the edge collider allowing for collision with the dynamic line
    void SetEdgeCollider(LineRenderer lineRenderer)
    {
        List<Vector2> edges = new List<Vector2>();

        for (int point = 0; point < lineRenderer.positionCount; ++point)
        {
            Vector3 lineRendererPoint = lineRenderer.GetPosition(point);
            edges.Add(new Vector2(lineRendererPoint.x, lineRendererPoint.y));
        }

        ec2D.SetPoints(edges);
    }

}
