using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] GameObject AI1;
    [SerializeField] GameObject AI2;
    [SerializeField] GameObject AI3;
    [SerializeField] GameObject AI4;
    private int AIsInScene = 1;
    [SerializeField] int newEnemySpawnTime;

    void Start()
    {
        //set all the possible AI's to be disabled except the first
        AI1.SetActive(true);
        AI2.SetActive(false);
        AI3.SetActive(false);
        AI4.SetActive(false);

        AI1.transform.position = new Vector3(22f, 2f, 15.5f);
        StartCoroutine(spawnEnemy()); // coroutine to enable other AIs one by one
    }

    IEnumerator spawnEnemy()
    {
        yield return new WaitForSeconds(newEnemySpawnTime);
        AIsInScene++; //increments how many AI's are in the scene
        //switch statement that activates the AI's based on how many are already in the scene
        switch (AIsInScene) 
        { 
            case 2:
                AI2.SetActive(true);
                
                break;
            case 3:
                AI3.SetActive(true);
                break;
            case 4:
                AI4.SetActive(true);
                break;
        }
        //loops this coroutine until all possible enemies are in the scene
        if (AIsInScene < 4)
        {
            StartCoroutine(spawnEnemy());
        }
    }
}
