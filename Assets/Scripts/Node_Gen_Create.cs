using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Gen_Create : MonoBehaviour
{
    public GameObject node;

    public int numberOfNodes = 0;

    bool hasStartBeenPressed = false;

    // Update is called once per frame
    void Update()
    {
        // mouse stuff from screen to game world
        Vector2 mousePosInScreenCoords = Input.mousePosition;
        Vector3 mousePosInWorldCoords = Camera.main.ScreenToWorldPoint(mousePosInScreenCoords);
        mousePosInWorldCoords.z = 0.0f;

        //GameObject tileInstance = GameObject.Instantiate(tile);
        //tileInstance.transform.position = new Vector3(x + 0.5f, y + 0.5f);
        //tileInstance.name = "Tile_" + x.ToString() + "_" + y.ToString();

        if (Input.GetKeyDown(KeyCode.S))
        {
            hasStartBeenPressed = true;

            for (int x = 0; GameObject.Find("Node_" + x) != null; ++x)
            {
                GameObject currentNode = GameObject.Find("Node_" + x);
                GameObject nextNode = GameObject.Find("Node_" + (x + 1));

                if (nextNode == null) currentNode.GetComponent<Node_Checkpoint>().isNodeLastPlaced = true;
            }
        }

        if (!hasStartBeenPressed)
        {
            if (Input.GetMouseButtonDown(1)) // RMB
            {
                GameObject nodeInstance = GameObject.Instantiate(node);
                nodeInstance.transform.position = new Vector3(mousePosInWorldCoords.x, mousePosInWorldCoords.y);
                nodeInstance.name = "Node_" + numberOfNodes.ToString();

                if (numberOfNodes == 0) nodeInstance.GetComponent<Node_Checkpoint>().isNodeStart = true;

                ++numberOfNodes;
            }
        }
    }
}
