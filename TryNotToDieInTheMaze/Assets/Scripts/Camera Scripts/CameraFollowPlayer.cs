using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject PlayerCharacter;
    Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = PlayerCharacter.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //y is 15 
        transform.position = new Vector3(PlayerCharacter.transform.position.x, 15, PlayerCharacter.transform.position.z);
    }
}
