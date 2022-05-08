using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Node_Gen_Create : MonoBehaviour
{
    public Track_Testing track_LR;
    public GameObject lineRenderer;

    public GameObject node;
    public GameObject fishCatPlayer;
    public GameObject fishCatAI;
    public GameObject oilSpill;
    public GameObject catFood;
    public GameObject tacocat;

    Vector3 vectorFrom0To1;
    Vector3 vectorSpawnPoint;
    Vector3 vectorIncremet;

    float fishCatSpawnAngle;
    public int numberOfNodes = 0;
    public int numberOfFishCats = 1;
    public int numberOfOilSpills = 5;
    public int numberOfCatFood = 4;
    public int numberOfTacocat = 3;

    public bool hasStartBeenPressed = false;
    public bool isReadyToDrawTrack = false;

    // Runs once at the first available frame
    void Start()
    {
        lineRenderer.GetComponent<LineRenderer>().startColor = Color.clear;
        lineRenderer.GetComponent<LineRenderer>().endColor = Color.clear;

        RandomlySpawnObstacles();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene(0);

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

            // Spawns the players car and a number of AI behind near the first CP 
            GameObject firstCP = GameObject.Find("Node_0");
            GameObject nextCP = GameObject.Find("Node_1");
            transform.position = firstCP.transform.position;
            vectorFrom0To1 = nextCP.transform.position - firstCP.transform.position;
            fishCatSpawnAngle = Vector3.Angle(vectorFrom0To1, Vector3.right);

            for (int i = 1; i < numberOfFishCats + 1; ++i)
            {
                if (i > 1)
                {
                    SetAngleForFishCatSpawn();  // I know this makes it add the 90deg each run through, but that also helps with placing
                    vectorIncremet = vectorIncremet + vectorSpawnPoint;
                    GameObject fishCat = GameObject.Instantiate(fishCatAI);
                    fishCat.transform.position = firstCP.transform.position;
                    fishCat.transform.position += vectorIncremet;
                    fishCat.name = "Fish_Cat_0" + i;
                }
                else
                {
                    SetAngleForFishCatSpawn();
                    GameObject fishPlayer = GameObject.Instantiate(fishCatPlayer);
                    fishPlayer.transform.position = firstCP.transform.position;
                    fishPlayer.transform.position += vectorSpawnPoint;
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
            vectorIncremet = Vector3.zero;
            fishCatSpawnAngle = 0;
            hasStartBeenPressed = false;
            numberOfNodes = 0;
            isReadyToDrawTrack = false;

            DestroySpawnedObstacles();
            RandomlySpawnObstacles();

            lineRenderer.GetComponent<LineRenderer>().startColor = Color.clear;
            lineRenderer.GetComponent<LineRenderer>().endColor = Color.clear;
        }

        if (!hasStartBeenPressed)   // No longer accepts RMB input once the race starts
        {
            if (Input.GetMouseButtonDown(1)) // RMB - To place the nodes for the track
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

    // Turns the angle that the fishCats spawn at and also seems to help with grouping them near the first CP
    void SetAngleForFishCatSpawn()
    {
        fishCatSpawnAngle += 90.0f;
        vectorSpawnPoint = new Vector3(Mathf.Cos(fishCatSpawnAngle * Mathf.Deg2Rad), Mathf.Sin(fishCatSpawnAngle * Mathf.Deg2Rad));
        vectorSpawnPoint.Normalize();
        vectorSpawnPoint *= 0.5f;
    }

    // Randomly spawns the 3 different obstacles
    void RandomlySpawnObstacles()
    {
        // oil spills
        for (int i = 0; i < numberOfOilSpills; ++i)
        {
            GameObject obstOil = GameObject.Instantiate(oilSpill);
            obstOil.transform.position = new Vector3(0, 0, 0);
            obstOil.transform.position += new Vector3(Random.Range(-7, 7), 0, 0);
            obstOil.transform.position += new Vector3(0, Random.Range(-7, 7), 0);
            obstOil.name = "Oil_Spill_0" + i;
        }
        // cat food
        for (int i = 0; i < numberOfCatFood; ++i)
        {
            GameObject obstCatFood = GameObject.Instantiate(catFood);
            obstCatFood.transform.position = new Vector3(0, 0, 0);
            obstCatFood.transform.position += new Vector3(Random.Range(-7, 7), 0, 0);
            obstCatFood.transform.position += new Vector3(0, Random.Range(-7, 7), 0);
            obstCatFood.name = "Cat_Food_0" + i;
        }
        // tacocat
        for (int i = 0; i < numberOfTacocat; ++i)
        {
            GameObject obstTacocat = GameObject.Instantiate(tacocat);
            obstTacocat.transform.position = new Vector3(0, 0, 0);
            obstTacocat.transform.position += new Vector3(Random.Range(-7, 7), 0, 0);
            obstTacocat.transform.position += new Vector3(0, Random.Range(-7, 7), 0);
            obstTacocat.name = "Tacocat_0" + i;
        }
    }

    // Destroy randomly spawned obstacles
    void DestroySpawnedObstacles()
    {
        // oil spills
        for (int i = 0; i < numberOfOilSpills; ++i)
        {
            Destroy(GameObject.Find("Oil_Spill_0" + i));
        }
        // cat food
        for (int i = 0; i < numberOfOilSpills; ++i)
        {
            Destroy(GameObject.Find("Cat_Food_0" + i));
        }
        // tacocat
        for (int i = 0; i < numberOfOilSpills; ++i)
        {
            Destroy(GameObject.Find("Tacocat_0" + i));
        }
    }
}
