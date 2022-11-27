using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool m_Active = true;
    private Teleporter m_Destination;
    private List<Teleporter> m_teleporters;
    private int poslistLength;
    GameObject m_player;
    ParticleSystem m_ParticleSystem;
    ParticleSystem.MainModule main;
    bool activeStatus = false;

    private void Start()
    {
        m_player = GameObject.Find("Player");
        m_ParticleSystem = transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        main = m_ParticleSystem.main;
    }

    private void LateUpdate()
    {
        if ((m_player.transform.position - transform.position).magnitude <= 5)
        {
            if (activeStatus == false)
            {
                m_ParticleSystem.Play();
                main.loop = true;
                activeStatus = true;
            }
        }
        else
        {
            if (activeStatus == true)
            {
                main.loop = false;
                activeStatus = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (m_Active && (other.tag == "Player" || other.tag == "Enemy"))
        {
            PickRandomTeleporter();
            m_Destination.m_Active = false;
            other.transform.position = m_Destination.transform.position;
            Debug.Log("collided");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Enemy")
        {
            m_Active = true;
        }
    }

    private void PickRandomTeleporter()
    {
        int newpos = Random.Range(0, poslistLength);
        if (m_teleporters[newpos] != this)
        {
            m_Destination = m_teleporters[newpos];
        }
        else
        {
            PickRandomTeleporter();
        }
    }

    public void SetTeleportersList(List<GameObject> teleporters, int listLength)
    {
        m_teleporters = new List<Teleporter>();
        Debug.Log(teleporters);
        poslistLength = listLength;

        for (int i = 0; i < listLength; i++)
        {
            m_teleporters.Add(teleporters[i].GetComponent<Teleporter>());
            Debug.Log(i);
        }
    }
}