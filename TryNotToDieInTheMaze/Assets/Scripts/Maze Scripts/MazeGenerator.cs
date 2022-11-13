using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEditor.AI;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UIElements;

public class MazeGenerator : MonoBehaviour
{
    [Header("Maze Variables")]
    public int[,] mazeArray = //45 x 32
        {{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
         { 1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,1,1 },
         { 1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,1,1 },
         { 1,1,1,1,1,1,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,1,1,1,1,1,1,0,0,1,0,0,0,0,1,1,1 },
         { 1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,1,1,1 },
         { 1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,1,1,1 },
         { 1,0,0,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,1,1 },
         { 1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,1,1 },
         { 1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,1,1 },
         { 1,1,1,1,1,0,0,1,0,0,1,0,0,1,1,1,0,0,1,0,0,0,0,0,0,1,0,0,1,1,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1 },
         { 1,0,0,0,0,0,0,1,0,0,0,0,0,1,1,1,0,0,1,0,0,0,0,0,0,1,0,0,1,1,1,0,0,0,1,0,0,0,1,1,0,0,0,0,1 },
         { 1,0,0,0,0,0,0,1,0,0,0,0,0,1,1,1,0,0,1,0,1,1,1,1,1,1,0,0,1,1,1,0,0,0,1,0,0,0,1,1,1,1,1,1,1 },
         { 1,0,0,1,1,1,1,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,1 },
         { 1,0,0,0,0,0,0,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,1 },
         { 1,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,1,0,0,0,1,1,1,1,0,0,0,1,1,0,0,0,1,0,0,1,1,1,1,1,1,1,0,0,1 },
         { 1,1,1,1,1,0,0,1,0,0,0,1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,1,1,1,0,0,1 },
         { 1,1,1,1,1,0,0,1,1,0,0,1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,1,1,1,0,0,1 },
         { 1,0,0,0,0,0,0,1,1,0,0,1,0,0,0,1,1,0,0,0,1,1,1,1,0,0,0,1,1,0,0,0,1,1,1,1,1,0,0,1,1,1,0,0,1 },
         { 1,0,0,0,0,0,0,1,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,1,1,0,0,1 },
         { 1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,1 },
         { 1,1,0,0,0,0,0,0,0,1,0,0,0,1,1,1,0,0,1,1,1,1,1,1,1,1,0,0,1,1,1,0,0,0,0,0,0,0,0,1,1,1,0,0,1 },
         { 1,1,0,0,0,0,0,0,0,1,0,0,0,1,1,1,0,0,1,0,0,0,0,0,0,1,0,0,1,1,1,0,0,0,0,0,0,0,0,1,1,1,0,0,1 },
         { 1,1,0,0,1,0,0,1,1,1,1,0,0,1,1,1,0,0,1,0,0,0,0,0,0,1,0,0,1,1,1,0,0,1,1,1,1,1,1,1,1,1,0,0,1 },
         { 1,1,0,0,1,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,1 },
         { 1,1,0,0,1,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,1 },
         { 1,1,0,0,1,0,0,1,1,1,1,0,0,1,0,0,1,1,1,0,0,0,0,0,0,1,1,1,0,0,1,1,1,1,1,0,0,1,0,0,1,1,1,1,1 },
         { 1,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,1 },
         { 1,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,1,1,1,1,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,1 },
         { 1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,1,1,0,0,1,1,1,1,1,0,0,1,1,1,1,1 },
         { 1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1 },
         { 1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1 },
         { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 } };
    private NavMeshSurface m_navmesh;

    [Header("Prefab Variables")]
    public GameObject wallPrefab; //1
    public GameObject SpeedPatchPrefab; //2
    public GameObject TeleportPrefab; //3
    [SerializeField] GameObject ScorePrefab; 

    [SerializeField] GameObject UIref;

    List<GameObject> scoreObjectList;
    [SerializeField] int scoreObjectGenFrequency;
    int objectsInScoreList = -1;

    void Start()
    {
        scoreObjectList = new List<GameObject>();
        MazeGeneratorFunc(mazeArray,45,32);
        
        
        //build navmesh
        m_navmesh = GetComponent<NavMeshSurface>();
        m_navmesh.BuildNavMesh();
    }

    // Update is called once per frame
    void Update()
    {
        //NewScoreObject();
    }

    void MazeGeneratorFunc(int[,] mazeMap, int height, int width)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                switch (mazeMap[i, j])
                {
                    case 0:
                        NewScoreObject(new Vector3(j, 1.9f, i));
                        break;
                    case 1:
                        Instantiate(wallPrefab, new Vector3(j, 1.9f, i), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(SpeedPatchPrefab, new Vector3(j, 1.9f, i), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(TeleportPrefab, new Vector3(j, 1.9f, i), Quaternion.identity);
                        break;
                }
            }
        }
        StartCoroutine(scoreObjectHandler());
    }

    void NewScoreObject(Vector3 position)
    {
//could have it so all score objects are always in the scene and are enabled and activated when needed?
        //Vector3 position = GetRandom();
        GameObject score = Instantiate(ScorePrefab, position, Quaternion.identity);
        score.SetActive(false);
        scoreObjectList.Add(score);
        objectsInScoreList++;
        ScoreObjectScript temp = score.GetComponent<ScoreObjectScript>();
        //when created you need to pass the UI to it to inc score when destoryed.
        temp.SetUI(UIref);
    }

    Vector3 GetRandom()
    {
        Vector3 tempPos = new Vector3(Random.Range(0, 45), 2.2f, Random.Range(0, 32)); //2.2f

        //pick a random location if it does equal zero, set to there, if not loop until it does.
        while (mazeArray[(int)tempPos.z, (int)tempPos.x] == 1)
        {
            tempPos = new Vector3(Random.Range(0, 45), 2.2f, Random.Range(0, 32));
            Debug.Log("loop");
        }
        return tempPos;
    }

    IEnumerator scoreObjectHandler()
    {
        yield return new WaitForSeconds(scoreObjectGenFrequency);
        bool activated = false;
        while (activated == false)
        {
            GameObject temp = scoreObjectList[(int)Random.Range(0, objectsInScoreList)];
            if (temp.activeSelf == false)
            {
                temp.SetActive(true);
                activated = true;
            }
        }
        StartCoroutine(scoreObjectHandler());
    }
}
