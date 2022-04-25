using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Track_Drawing : MonoBehaviour
{
    public GameObject trackPrefab;
    //public GameObject previousNode;
    //public GameObject currentNode;
    //public GameObject nextNode;

    public List<GameObject> trackNodeList;


    // Start is called before the first frame update
    void Start()
    {

        /*
        for (int x = 0; GameObject.Find("Node_" + x) != null; ++x)
        {
            GameObject currentNode = GameObject.Find("Node_" + x);
            GameObject nextNode = GameObject.Find("Node_" + (x + 1));

            if (nextNode == null) currentNode.GetComponent<Node_Checkpoint>().isNodeLastPlaced = true;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addNewNodeToList(GameObject currentTrackNode)
    {
        trackNodeList.Add(currentTrackNode);
    }

    public void initialiseTrackDrawing()
    {




            Debug.Log(trackNodeList.Count);



        //1) get 2 nodes from the list starting at the begining
        
        for (int nodeIndex = 0; nodeIndex < trackNodeList.Count; nodeIndex++)
        {
            Vector3 pos = new Vector3(0, 0, 0);

            //2) Find how far away node_1 is from node_2
            int nextIndex = nodeIndex + 1;
            if (nextIndex >= trackNodeList.Count)
            {
                nextIndex = 0;
            }
            //lerp finds the mid point between 2 vec3s
            Vector3 midpoint = Vector3.Lerp(trackNodeList[nodeIndex].transform.position, trackNodeList[nextIndex].transform.position, 0.5f);
            float nodeToNodeRotation = Vector3.Angle(trackNodeList[nodeIndex].transform.position, trackNodeList[nextIndex].transform.position);
            float scaleIn_xAxis = trackNodeList[nodeIndex].transform.position.x - trackNodeList[nextIndex].transform.position.x;


            GameObject gameObject_Temp = Instantiate(trackPrefab);

            gameObject_Temp.transform.position = new Vector3(midpoint.x, midpoint.y, 0);
            gameObject_Temp.transform.Rotate(0.0f, 0.0f, nodeToNodeRotation);
            gameObject_Temp.transform.localScale = new Vector3(midpoint.x * 2, 0.5f, 0.0f);

            gameObject_Temp.name = "Track segment for_" + nodeIndex + " & " + (nextIndex);
        }
        

    }

    //TODO: 
    /*
     * 1) get 2 nodes from the list starting at the begining
     * 2) Find how far away node_1 is from node_2
     * 3) Find the angle of node_2 from node_1
     * 4) Instantiate a track prefap in the middle between node_1 & node_2
     * 5) rotate the prefab in the z axis to be inline with the 2 nodes
     * 6) scale the prefab in the x axis to strech out to meet with the center of both prefabs
     * 
     * 7) repeat for each node
     */
}
