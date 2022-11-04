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

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(playerSpeed);
        m_rb.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(0f, 0f, Time.deltaTime * _moveSpeed);
            m_rb.AddForce(transform.forward * playerSpeed, ForceMode.Force); //phyisics automatically applies deltatime
            previousDir = Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(0f, 0f, Time.deltaTime * -_moveSpeed);
            m_rb.AddForce(-transform.forward * playerSpeed, ForceMode.Force);
            previousDir = Vector3.down;
            
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(Time.deltaTime * _moveSpeed, 0f, 0f);
            m_rb.AddForce(transform.right * playerSpeed, ForceMode.Force);
            previousDir = Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(Time.deltaTime * -_moveSpeed, 0f, 0f);
            m_rb.AddForce(-transform.right * playerSpeed, ForceMode.Force);
            previousDir = Vector3.left;
        }
        if (playerSpeed != baseSpeed)
        {
            m_rb.AddForce(previousDir * playerSpeed, ForceMode.Force);
        }
    }
}
