using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Collider : MonoBehaviour
{
    public FishCat_Player fishCatPlayer;
    float normalPlayerSpeed;


    private void OnTriggerEnter2D(Collider2D other)
    {
        normalPlayerSpeed = fishCatPlayer.playerSpeed;
        if (other.tag == "Oil")
        {
            Debug.Log("Oil detected");
            fishCatPlayer.playerSpeed = (normalPlayerSpeed/3);

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Oil")
        {
            Debug.Log("No longer in Oil");
            fishCatPlayer.playerSpeed = normalPlayerSpeed;
        }
    }
}
