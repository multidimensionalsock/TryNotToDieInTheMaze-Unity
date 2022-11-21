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
        AI1.SetActive(true);
        AI2.SetActive(false);
        AI3.SetActive(false);
        AI4.SetActive(false);

        AI1.transform.position = new Vector3(22f, 2f, 15.5f);
        StartCoroutine(spawnEnemy());
    }
    void Update()
    {
        //needs to activate and place AIs when the player reaches a certain score.
    }

    IEnumerator spawnEnemy()
    {
        
        Debug.Log("corrouine started");
        yield return new WaitForSeconds(newEnemySpawnTime);
        Debug.Log("after wait" + AIsInScene);
        AIsInScene++;
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
        if (AIsInScene < 4)
        {
            StartCoroutine(spawnEnemy());
        }
    }
}
