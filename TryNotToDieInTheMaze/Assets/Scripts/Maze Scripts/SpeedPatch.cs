using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPatch : MonoBehaviour
{
    public int speedmod = 100;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().playerSpeed += speedmod;
            Debug.Log("sped up");
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().playerSpeed -= speedmod;
        }
    }
}
