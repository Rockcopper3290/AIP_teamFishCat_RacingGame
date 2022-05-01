using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Testing : MonoBehaviour
{
    [SerializeField] public List <Transform> points;
    [SerializeField] private Track_LineController line;
    private Transform[] pointsInAnArray;

    public void addNewNodeToList_trackTesting(GameObject currentTrackNode)
    {
        points.Add(currentTrackNode.transform);
    }

    public void endOfTrackSelection()
    {
        points.Add(points[0]);
        pointsInAnArray = points.ToArray();
        line.SetUpLine(pointsInAnArray);

    }

    public void clearTrackList()
    {
        points.Clear();
       

    }

    private void Start()
    {

    }

    public void Update()
    {

    }

}
