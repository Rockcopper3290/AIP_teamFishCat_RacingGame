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
    float fishCatSpeed = 0.9f;
    public float fishCatBaseSpeed = 0.9f;
    public float collisionTimer = 0.0f;
    bool colliding = false;
    bool onTrackSpeedBoost = false;
    bool inOilSpill = false;
    bool eatingCatFood = false;
    bool tacocat = false;

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
        if (!colliding && collisionTimer <= 0)
        {
            fishCatSpeed = fishCatBaseSpeed;
            eatingCatFood = false;
            tacocat = false;
        }
        else if (colliding || collisionTimer > 0)  // Only when colliding with SOMETHING will these checks be done
        {
            CollisionHandling();
        }

        fishCatVelocity.Normalize();
        fishCatVelocity *= fishCatSpeed;
        playerRigidBody.AddForce(fishCatVelocity, ForceMode2D.Force);
        playerRigidBody.rotation = fishCatAngle;

        // Calculates whether to turn left or right
        vectorToNextCP = nextCP.GetComponent<Node_Checkpoint>().nodePosition - transform.position;
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
    void AngleToVectorMovement()
    {
        fishCatVelocity = new Vector3(Mathf.Cos(fishCatAngle * Mathf.Deg2Rad), Mathf.Sin(fishCatAngle * Mathf.Deg2Rad));

        fishCatLeft = new Vector3(Mathf.Cos(vectorLeftAngle * Mathf.Deg2Rad), Mathf.Sin(vectorLeftAngle * Mathf.Deg2Rad));
    }

    // Different checks and outcomes regarding what is being touched
    void CollisionHandling()
    {
        if (onTrackSpeedBoost) fishCatSpeed = 1.5f;
        if (inOilSpill) fishCatSpeed = 0.2f;
        if (eatingCatFood && collisionTimer > 0)
        {
            collisionTimer -= Time.deltaTime;
            fishCatSpeed = 0.0f;
        }
        if (tacocat && collisionTimer > 0)
        {
            collisionTimer -= Time.deltaTime;
            fishCatSpeed = fishCatBaseSpeed * -1.0f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        colliding = true;

        if (other.gameObject.tag == "Line (Track)") onTrackSpeedBoost = true;

        if (other.gameObject.tag == "Oil Spill") inOilSpill = true;

        if (other.gameObject.tag == "Cat Food")
        {
            collisionTimer = 5;
            eatingCatFood = true;
        }

        if (other.gameObject.tag == "Tacocat")
        {
            collisionTimer = 2;
            tacocat = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        colliding = false;

        if (other.gameObject.tag == "Line (Track)") onTrackSpeedBoost = false;

        if (other.gameObject.tag == "Oil Spill") inOilSpill = false;

        // eatingCatFood = false done elsewhere

        // tacocat = false done elsewhere
    }
}
