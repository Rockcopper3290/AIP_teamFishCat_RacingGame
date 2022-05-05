using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCat_Player : MonoBehaviour
{
    Vector3 playerVelocity;

    public float playerAngle = 0.0f;
    float playerTurnSpeed = 180.0f;
    public float playerSpeed = 1.0f;

    Rigidbody2D playerRigidBody;

    // Update is called on the first frame
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

        AngleToVectorMovement();
    }

    // Update is called once per frame
    void Update()
    {
        playerVelocity.Normalize();
        playerVelocity *= playerSpeed;
        playerRigidBody.AddForce(playerVelocity, ForceMode2D.Force);

        playerRigidBody.rotation = playerAngle;

        if (Input.GetKey(KeyCode.A))
        {
            playerAngle += playerTurnSpeed * Time.deltaTime;
            AngleToVectorMovement();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerAngle -= playerTurnSpeed * Time.deltaTime;
            AngleToVectorMovement();
        }
    }

    // Takes playerAngle and turns it into a vector/ velocity for movement
    void AngleToVectorMovement()
    {
        playerVelocity = new Vector3(Mathf.Cos(playerAngle * Mathf.Deg2Rad), Mathf.Sin(playerAngle * Mathf.Deg2Rad));
    }
}
