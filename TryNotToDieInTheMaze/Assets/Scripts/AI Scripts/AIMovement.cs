using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIMovement : MonoBehaviour
{
    private Vector3 m_targetLocation;
    [SerializeField] GameObject player;
    private bool m_playerInRange;
    private AIState m_state;
    public float MaxDistanceToChase;
    private float CurrentSpeed;
    [SerializeField] float WanderSpeed; // the speed you go when in wander
    [SerializeField] float ChaseSpeed; //the speed you go when in chase
    [SerializeField] GameObject mazeGen;
    private int[,] maze;
    

    private void Start()
    {
        //set new target location
        UpdatePath(randomPath());
    }

    private void FixedUpdate()
    {
        switch (m_state)
        {
            case AIState.WANDER:
                //if player is in range, change targetLocation to player
                if (FindRange() < MaxDistanceToChase)
                {
                    UpdatePath(player.transform.position);
                    m_state = AIState.CHASE;
                    CurrentSpeed = ChaseSpeed;
                }
                //if current transform is euqal to targetlocation, set a new one
                else if (transform.position == m_targetLocation)
                {
                    UpdatePath(randomPath());
                }
                break;
            case AIState.CHASE:
                //if player is no longer in range, switch to wander
                if (FindRange() > MaxDistanceToChase)
                {
                    UpdatePath(randomPath());
                    m_state = AIState.WANDER;
                    CurrentSpeed = WanderSpeed;
                }
                //if player is in range, update location
                break;
        }

        //i need code to move them towards the path lol
    }

    private void UpdatePath(Vector3 newLocation)
    {
       


        //this fucntion updates the players path based on the new location
    }

    private Vector3 randomPath()
    {
        //get the array from mazegenerator
        maze = mazeGen.GetComponent<MazeGenerator>().mazeArray; //45 x 32
        Vector3 tempPos = new Vector3(Random.Range(0, 45), 2.2f, Random.Range(0, 32)); //2.2f

        //pick a random location if it does equal zero, set to there, if not loop until it does.
        while (maze[(int)tempPos.x, (int)tempPos.z] ! == 1)
        {
            tempPos = new Vector3(Random.Range(0, 45), 2.2f, Random.Range(0, 32));
        } 
        return tempPos;
    }

    private float FindRange()
    {
        float tempDist = (player.transform.position - transform.position).magnitude;
        return tempDist;
    }
}

public enum AIState
{
    WANDER,
    CHASE
};
