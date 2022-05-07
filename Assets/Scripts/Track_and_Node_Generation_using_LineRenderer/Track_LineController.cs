using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_LineController : MonoBehaviour
{
    private LineRenderer lr;
    private Transform[] points;
    public NodeGenCreate NodeGenCreate_Refence;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
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
        }
            
    }

}
