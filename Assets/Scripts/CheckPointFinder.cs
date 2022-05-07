using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointFinder : MonoBehaviour
{

    public static NodeGenCreate nodeGenCreate;
    public static Node_Checkpoint nodeCheckpoint; 

    public int totalNumCheckPoints; // how many check points in the scene 
    bool startBeenPressed; // bool is check if player has pressed start 
    public int counter;

    public GameObject car; 

    // Start is called before the first frame update
    void Start()
    {
        totalNumCheckPoints = nodeGenCreate.numberOfNodes;
        startBeenPressed = nodeGenCreate.hasStartBeenPressed;
        counter++; // add one to counter since players start at node 0
    }

    // Update is called once per frame
    void Update()
    {
            // if player has started the game to race and the total number of nodes isnt 0 then 
        if (startBeenPressed && totalNumCheckPoints > 0 )
        {
            // check for the node after node 0 
            GameObject nextNode = GameObject.Find("Node_" + counter);
            // move game object in the directon of that node 
            transform.position = nodeCheckpoint.nodePosition; 
                // ??? maybe have a array which holds the car objects on the track and then use a for loop to go through array to 
                // change the position of the cars to the next node, adding one to the counter ???

            // once close in contact with node, search for next point and move towards that one 
            // untill the next checkpoint == NULL, thus look for node 0 being the start and end of the track 
        }
    }
}
