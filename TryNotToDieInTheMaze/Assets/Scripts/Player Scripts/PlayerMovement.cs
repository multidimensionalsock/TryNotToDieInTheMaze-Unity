using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody m_rb;
    public float playerSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        m_rb.velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            //transform.Translate(0f, 0f, Time.deltaTime * _moveSpeed);
            m_rb.AddForce(transform.forward * playerSpeed, ForceMode.Force); //phyisics automatically applies deltatime
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.Translate(0f, 0f, Time.deltaTime * -_moveSpeed);
            m_rb.AddForce(-transform.forward * playerSpeed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.Translate(Time.deltaTime * _moveSpeed, 0f, 0f);
            m_rb.AddForce(transform.right * playerSpeed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.Translate(Time.deltaTime * -_moveSpeed, 0f, 0f);
            m_rb.AddForce(-transform.right * playerSpeed, ForceMode.Force);
        }
    }
}
