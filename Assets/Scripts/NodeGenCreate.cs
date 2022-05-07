using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenCreate : MonoBehaviour
{
    public Track_Testing track_LR;
    public GameObject lineRenderer;

    public GameObject node;
    public GameObject fishCatAI;

    public int numberOfNodes = 0;

    public bool hasStartBeenPressed = false;
    public bool isReadyToDrawTrack = false;

    // Runs once at the first available frame
    void Start()
    {
        lineRenderer.GetComponent<LineRenderer>().startColor = Color.clear;
        lineRenderer.GetComponent<LineRenderer>().endColor = Color.clear;
    }

    // Update is called once per frame
    void Update()
    {
        // mouse stuff from screen to game world
        Vector2 mousePosInScreenCoords = Input.mousePosition;
        Vector3 mousePosInWorldCoords = Camera.main.ScreenToWorldPoint(mousePosInScreenCoords);
        mousePosInWorldCoords.z = 0.0f;

        if (Input.GetKeyDown(KeyCode.S))    // Disables node creation and will start/ spawn the cars to race
        {
            hasStartBeenPressed = true;

            for (int x = 0; GameObject.Find("Node_" + x) != null; ++x)  // Finds the last checkpoint and labels it as last for some reason :)
            {
                GameObject currentNode = GameObject.Find("Node_" + x);
                GameObject nextNode = GameObject.Find("Node_" + (x + 1));

                if (nextNode == null) currentNode.GetComponent<Node_Checkpoint>().isNodeLastPlaced = true;
            }

            // Creates a tester AI upon S being pressed {
            GameObject fishCat = GameObject.Instantiate(fishCatAI);
            GameObject startCP = GameObject.Find("Node_0");
            fishCat.transform.position = startCP.GetComponent<Node_Checkpoint>().nodePosition;
            fishCat.name = "Fish Cat 01";
            // }

            track_LR.endOfTrackSelection();
            lineRenderer.GetComponent<LineRenderer>().startColor = Color.white;
            lineRenderer.GetComponent<LineRenderer>().endColor = Color.white;

            isReadyToDrawTrack = true;
        }

        if (Input.GetKeyDown(KeyCode.C))    // Clears all of the check points and prepares for new creation of CPs
        {
            track_LR.clearTrackList();

            for (int x = 0; x < numberOfNodes; ++x)
            {
                //track_LR.points.RemoveAt(x);
                Destroy(GameObject.Find("Node_" + x));
            }

            Destroy(GameObject.Find("Fish Cat 01")); // DESTROYS the single AI fish cat upon C pressed

            hasStartBeenPressed = false;
            numberOfNodes = 0;
            isReadyToDrawTrack = false;

            lineRenderer.GetComponent<LineRenderer>().startColor = Color.clear;
            lineRenderer.GetComponent<LineRenderer>().endColor = Color.clear;
        }

        if (!hasStartBeenPressed)   // No longer accepts RMB input once the race starts
        {
            if (Input.GetMouseButtonDown(1)) // RMB
            {
                GameObject nodeInstance = GameObject.Instantiate(node);
                nodeInstance.transform.position = new Vector3(mousePosInWorldCoords.x, mousePosInWorldCoords.y);
                nodeInstance.GetComponent<Node_Checkpoint>().nodePosition = new Vector3(mousePosInWorldCoords.x, mousePosInWorldCoords.y);
                nodeInstance.name = "Node_" + numberOfNodes.ToString();

                if (numberOfNodes == 0) nodeInstance.GetComponent<Node_Checkpoint>().isNodeStart = true;

                ++numberOfNodes;

                track_LR.addNewNodeToList_trackTesting(nodeInstance);
            }
        }
    }
}
