using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenSet : MonoBehaviour
{
    public GameObject node;


    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < 6; ++x) // Generates 6 checkpoints in pre-set locations
        {
            GameObject nodeInstance = GameObject.Instantiate(node);
            if (x == 0)
            {
                nodeInstance.transform.position = new Vector3(0.0f, 0.0f);
                nodeInstance.GetComponent<Node_Checkpoint>().nodePosition = new Vector3(0.0f, 0.0f);
                nodeInstance.GetComponent<Node_Checkpoint>().isNodeStart = true;
            }
            if (x == 1)
            {
                nodeInstance.transform.position = new Vector3(-2.0f, 4.0f);
                nodeInstance.GetComponent<Node_Checkpoint>().nodePosition = new Vector3(-2.0f, 4.0f);
            }
            if (x == 2)
            {
                nodeInstance.transform.position = new Vector3(-4.0f, -1.0f);
                nodeInstance.GetComponent<Node_Checkpoint>().nodePosition = new Vector3(-4.0f, -1.0f);
            }
            if (x == 3)
            {
                nodeInstance.transform.position = new Vector3(3.5f, -2.5f);
                nodeInstance.GetComponent<Node_Checkpoint>().nodePosition = new Vector3(3.5f, -2.5f);
            }
            if (x == 4)
            {
                nodeInstance.transform.position = new Vector3(1.5f, 4.0f);
                nodeInstance.GetComponent<Node_Checkpoint>().nodePosition = new Vector3(1.5f, 4.0f);
            }
            if (x == 5)
            {
                nodeInstance.transform.position = new Vector3(-1.0f, -4.5f);
                nodeInstance.GetComponent<Node_Checkpoint>().nodePosition = new Vector3(-1.0f, -4.5f);
                nodeInstance.GetComponent<Node_Checkpoint>().isNodeLastPlaced = true;
            }
            nodeInstance.name = "Node_" + x.ToString();
        }
    }
}
