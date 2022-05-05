using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCat_AI : MonoBehaviour
{
    Vector3 fishCatVelocity;
    Vector3 fishCatLeft;
    Vector3 vectorToNextCP;

    float fishCatAngle = 0.0f;
    float vectorLeftAngle = 0.0f;
    float angleToNode = 0.0f;
    public int nodeCounter = 1;
    public float fishCatTurnSpeed = 180.0f;
    public float fishCatSpeed = 1.0f;

    Rigidbody2D playerRigidBody;
    public GameObject nextCP;

    // Update is called on the first frame after initialisation
    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        vectorLeftAngle = fishCatAngle + 90.0f;

        AngleToVectorMovement();

        nextCP = GameObject.Find("Node_" + nodeCounter);
    }

    // Update is called once per frame
    void Update()
    {
        vectorToNextCP = nextCP.GetComponent<Node_Checkpoint>().nodePosition - transform.position;

        fishCatVelocity.Normalize();
        fishCatVelocity *= fishCatSpeed;
        playerRigidBody.AddForce(fishCatVelocity, ForceMode2D.Force);
        playerRigidBody.rotation = fishCatAngle;

        // Calculates whether to turn left or right
        angleToNode = Vector3.Angle(fishCatLeft, vectorToNextCP);

        if (angleToNode <= 90)  // Turns left
        {
            fishCatAngle += fishCatTurnSpeed * Time.deltaTime;
            vectorLeftAngle = fishCatAngle + 90.0f;
            AngleToVectorMovement();
        }
        else if (angleToNode > 90)  // Turns right
        {
            fishCatAngle -= fishCatTurnSpeed * Time.deltaTime;
            vectorLeftAngle = fishCatAngle + 90.0f;
            AngleToVectorMovement();
        }

        // Increments to the next CP upon getting close enough to the current CP
        if (Vector3.Magnitude(vectorToNextCP) < 0.4f)
        {
            ++nodeCounter;

            if (GameObject.Find("Node_" + nodeCounter) != null) nextCP = GameObject.Find("Node_" + nodeCounter);
            else
            {
                nodeCounter = 0;
                nextCP = GameObject.Find("Node_0");
            }
        }
    }

    // Takes fishCatAngle and turns it into a vector/ velocity for movement
    // Calculates the players left into a vector
    // Keeps fishCatAngle and fishCatLeft between 0-360
    void AngleToVectorMovement()
    {
        fishCatVelocity = new Vector3(Mathf.Cos(fishCatAngle * Mathf.Deg2Rad), Mathf.Sin(fishCatAngle * Mathf.Deg2Rad));

        fishCatLeft = new Vector3(Mathf.Cos(vectorLeftAngle * Mathf.Deg2Rad), Mathf.Sin(vectorLeftAngle * Mathf.Deg2Rad));
    }
}
