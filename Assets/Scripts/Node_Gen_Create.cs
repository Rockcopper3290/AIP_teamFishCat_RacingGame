using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Gen_Create : MonoBehaviour
{
    public Track_Testing track_LR;
    public GameObject lineRenderer;

    public GameObject node;
    public GameObject fishCatPlayer;
    public GameObject fishCatAI;

    Vector3 vectorFrom0To1;
    Vector3 vectorSpawnPoint;

    public int numberOfNodes = 0;
    public int numberOfFishCats = 5;

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

            // Spawns the players car and a number of AI behind
            GameObject firstCP = GameObject.Find("Node_0");
            GameObject nextCP = GameObject.Find("Node_1");
            vectorFrom0To1 = nextCP.transform.position - firstCP.transform.position;
            vectorFrom0To1.Normalize();
            vectorFrom0To1 *= -0.5f;
            vectorSpawnPoint = firstCP.transform.position + vectorFrom0To1;

            for (int i = 1; i < numberOfFishCats + 1; ++i)
            {
                if (i > 1)
                {
                    vectorSpawnPoint = vectorFrom0To1;
                    vectorSpawnPoint *= i;
                    GameObject fishCat = GameObject.Instantiate(fishCatAI);
                    fishCat.transform.position = vectorSpawnPoint;
                    fishCat.name = "Fish_Cat_0" + i;
                }
                else
                {
                    vectorSpawnPoint *= i;
                    GameObject fishPlayer = GameObject.Instantiate(fishCatPlayer);
                    fishPlayer.transform.position = vectorSpawnPoint;
                    fishPlayer.name = "Fish_Cat_Player";
                }
            }

            track_LR.endOfTrackSelection();
            lineRenderer.GetComponent<LineRenderer>().startColor = Color.cyan;
            lineRenderer.GetComponent<LineRenderer>().endColor = Color.cyan;

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

            for (int x = 1; x < numberOfFishCats + 1; ++x) // Destroys all of the current fishCats on screen
            {
                if (x > 1)
                {
                    Destroy(GameObject.Find("Fish_Cat_0" + x));
                }
                else
                {
                    Destroy(GameObject.Find("Fish_Cat_Player"));
                }
            }
            vectorFrom0To1 = Vector3.zero;
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

                if (numberOfNodes == 0)
                {
                    nodeInstance.GetComponent<Node_Checkpoint>().isNodeStart = true;
                    nodeInstance.GetComponent<SpriteRenderer>().color = Color.black;
                }

                ++numberOfNodes;

                track_LR.addNewNodeToList_trackTesting(nodeInstance);
            }
        }
    }
}
