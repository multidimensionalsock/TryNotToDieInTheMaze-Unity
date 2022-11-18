using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public bool m_Active = true;
    private Teleporter m_Destination;
    private List<Teleporter> m_teleporters;
    private int poslistLength;

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
        m_Destination = m_teleporters[newpos];
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