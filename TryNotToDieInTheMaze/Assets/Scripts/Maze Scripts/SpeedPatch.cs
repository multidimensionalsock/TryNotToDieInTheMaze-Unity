using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPatch : MonoBehaviour
{
    public int speedmod = 100;

    //speeds up the player if the player collides with it
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().playerSpeed += speedmod;
            Debug.Log("sped up");
        }
    }

    //sets the player speed back when the player is no longer colliding
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().playerSpeed -= speedmod;
        }
    }
}
