using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenCreate : MonoBehaviour
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

        if (Input.GetKeyDown(KeyCode.S))
        {
            hasStartBeenPressed = true;

            for (int x = 0; GameObject.Find("Node" + x) != null; ++x)
            {
<<<<<<< HEAD:Assets/Scripts/Node_Gen_Create.cs
                
                GameObject currentNode = GameObject.Find("Node_" + x);
                GameObject nextNode = GameObject.Find("Node_" + (x + 1));
=======
                GameObject currentNode = GameObject.Find("Node" + x);
                GameObject nextNode = GameObject.Find("Node" + (x + 1));
>>>>>>> 1edf721d5f45f5d3005d598b0940b43af3e547ec:Assets/Scripts/NodeGenCreate.cs

                if (nextNode == null) currentNode.GetComponent<Node_Checkpoint>().isNodeLastPlaced = true;
            }
        }

        if (!hasStartBeenPressed)   // No longer accepts RMB input once the race starts
        {
            if (Input.GetMouseButtonDown(1)) // RMB
            {
                GameObject nodeInstance = GameObject.Instantiate(node);
                nodeInstance.transform.position = new Vector3(mousePosInWorldCoords.x, mousePosInWorldCoords.y);
                nodeInstance.GetComponent<Node_Checkpoint>().nodePosition = new Vector3(mousePosInWorldCoords.x, mousePosInWorldCoords.y);
                nodeInstance.name = "Node" + numberOfNodes.ToString();

                if (numberOfNodes == 0) nodeInstance.GetComponent<Node_Checkpoint>().isNodeStart = true;

                ++numberOfNodes;
            }
        }
    }
}
