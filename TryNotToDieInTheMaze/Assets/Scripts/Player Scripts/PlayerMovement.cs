using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody m_rb;
    public float playerSpeed = 5f;
    private float baseSpeed;
    private Vector3 previousDir = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        baseSpeed = playerSpeed;
    }

    // player movemnet based on input
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_rb.AddForce(transform.forward * playerSpeed, ForceMode.Force); //physics automatically applies deltatime
            previousDir = Vector3.up; //keeps the player going in that direction if they stop clicking for a time
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_rb.AddForce(-transform.forward * playerSpeed, ForceMode.Force);
            previousDir = Vector3.down;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_rb.AddForce(transform.right * playerSpeed, ForceMode.Force);
            previousDir = Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_rb.AddForce(-transform.right * playerSpeed, ForceMode.Force);
            previousDir = Vector3.left;
        }
        if (playerSpeed != baseSpeed)
        {
            m_rb.AddForce(previousDir * playerSpeed, ForceMode.Force);
        }
    }
}
