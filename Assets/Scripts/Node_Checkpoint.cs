using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Checkpoint : MonoBehaviour
{
    public bool isNodeStart = false;
    public bool isNodeLastPlaced = false;
    public Vector3 nodePosition = new Vector3();
    // public int nodeCounter = 0;

    // Start is called before the first frame update
    void Awake()
    {
        nodePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
