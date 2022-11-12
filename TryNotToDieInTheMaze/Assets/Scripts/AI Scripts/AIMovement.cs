using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIMovement : MonoBehaviour
{
    private Vector3 m_targetLocation;
    public GameObject player;
    private AIState m_state;
    public float MaxDistanceToChase = 50f;
    [SerializeField] float WanderSpeed; // the speed you go when in wander
    [SerializeField] float ChaseSpeed; //the speed you go when in chase
    [SerializeField] GameObject mazeGen;
    private int[,] maze;
    private NavMeshPath m_CurrentPath;
    private NavMeshAgent m_Agent = null;
    private NavMeshSurface m_navmesh;


    private void OnEnable()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_navmesh = mazeGen.GetComponent<NavMeshSurface>();
        UpdatePath(randomPath());
        m_state = AIState.WANDER;
    }

    private void FixedUpdate()
    {
        switch (m_state)
        {
            case AIState.WANDER:
                //if player is in range, change targetLocation to player
                if (FindRange() < MaxDistanceToChase)
                {
                    Debug.Log("should chase");
                    m_state = AIState.CHASE;
                    m_Agent.speed = ChaseSpeed;
                }
                //if current transform is euqal to targetlocation, set a new one
                else if (m_Agent.velocity == Vector3.zero)
                {
                    Debug.Log("isnt chasing");
                    UpdatePath(randomPath());
                }
                break;
            case AIState.CHASE:
                UpdatePath(player.transform.position);
                //if player is no longer in range, switch to wander
                if (FindRange() > MaxDistanceToChase)
                {
                    UpdatePath(randomPath());
                    m_state = AIState.WANDER;
                    m_Agent.speed = WanderSpeed;
                }
                //if player is in range, update location
                break;
        }

    }

    private void UpdatePath(Vector3 newLocation)
    {
        m_targetLocation = newLocation;
        m_Agent.SetDestination(newLocation);
    }

    private Vector3 randomPath()
    {
        //get the array from mazegenerator
        maze = mazeGen.GetComponent<MazeGenerator>().mazeArray; //45 x 32
        Vector3 tempPos = new Vector3(Random.Range(0f, 32f), 2.2f, Random.Range(0f, 45f) + 0.5f); //2.2f

        //pick a random location if it does equal zero, set to there, if not loop until it does.
        while (maze[(int)tempPos.x, (int)tempPos.z] ! == 1)
        {
            tempPos = new Vector3(Random.Range(0, 32) + 0.5f, 2.2f, Random.Range(0, 45) + 0.5f);
            Debug.Log("loop");
        } 
        return tempPos;
    }

    private float FindRange()
    {
        float tempDist = (player.transform.position - transform.position).magnitude;
        return tempDist;
        
    }

    IEnumerator NavmeshLoad()
    {
        yield return new WaitForSeconds(1f);
        m_navmesh = mazeGen.GetComponent<NavMeshSurface>();

        UpdatePath(randomPath());
    }
}

public enum AIState
{
    WANDER,
    CHASE
};
