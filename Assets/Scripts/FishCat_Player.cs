using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCat_Player : MonoBehaviour
{
    Vector3 playerVelocity;
    Vector3 vectorLeft;
    Vector3 vectorToNextCP;

    float playerAngle = 0.0f;
    float vectorLeftAngle = 0.0f;
    float angleToNode = 0.0f;
    public int nodeCounter = 1;
    public float playerTurnSpeed = 180.0f;
    public float playerSpeed = 1.0f;
    bool onTrackSpeedBoost = false;

    Rigidbody2D playerRigidBody;
    public GameObject nextCP;

    // Update is called on the first frame after instantiated
    void Awake()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        vectorLeftAngle = playerAngle + 90.0f;

        AngleToVectorMovement();

        nextCP = GameObject.Find("Node_" + nodeCounter);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0))    // LMB released
        {
            if (playerSpeed > 0.5f) playerSpeed -= 0.01f;
        }
        else if (Input.GetMouseButton(0))    // LMB held down
        {
            if (playerSpeed < 1.2f) playerSpeed += 0.01f;
        }

        if (onTrackSpeedBoost) playerSpeed = 1.5f;

        playerVelocity.Normalize();
        playerVelocity *= playerSpeed;
        playerRigidBody.AddForce(playerVelocity, ForceMode2D.Force);
        playerRigidBody.rotation = playerAngle;

        // Calculates whether to turn left or right
        vectorToNextCP = nextCP.GetComponent<Node_Checkpoint>().nodePosition - transform.position;
        angleToNode = Vector3.Angle(vectorLeft, vectorToNextCP);

        if (angleToNode <= 90)  // Turns left
        {
            playerAngle += playerTurnSpeed * Time.deltaTime;
            vectorLeftAngle = playerAngle + 90.0f;
            AngleToVectorMovement();
        }
        else if (angleToNode > 90)  // Turns right
        {
            playerAngle -= playerTurnSpeed * Time.deltaTime;
            vectorLeftAngle = playerAngle + 90.0f;
            AngleToVectorMovement();
        }

        // Increments to the next CP upon getting close enough to the current CP
        if (Vector3.Magnitude(vectorToNextCP) < 0.3f)
        {
            ++nodeCounter;

            // Increments through checkpoints 
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
        playerVelocity = new Vector3(Mathf.Cos(playerAngle * Mathf.Deg2Rad), Mathf.Sin(playerAngle * Mathf.Deg2Rad));

        vectorLeft = new Vector3(Mathf.Cos(vectorLeftAngle * Mathf.Deg2Rad), Mathf.Sin(vectorLeftAngle * Mathf.Deg2Rad));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        onTrackSpeedBoost = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        onTrackSpeedBoost = false;
    }
}
