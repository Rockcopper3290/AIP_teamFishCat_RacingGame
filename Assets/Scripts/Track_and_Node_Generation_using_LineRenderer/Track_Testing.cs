using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Testing : MonoBehaviour
{
    [SerializeField] private List <Transform> points;
    [SerializeField] private Track_LineController line;
    private Transform[] pointsInAnArray;

    public void addNewNodeToList_trackTesting(GameObject currentTrackNode)
    {
        points.Add(currentTrackNode.transform);
    }

    public void fuckMe_lr()
    {
        points.Add(points[0]);
        pointsInAnArray = points.ToArray();
    }

    private void Start(){

    }

    public void Update()
    {
        line.SetUpLine(pointsInAnArray);

    }

}
