using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Diagnostics.CodeAnalysis;
using UnityEngine.UIElements;

public class MazeGenerator : MonoBehaviour
{
    [Header("Maze Variables")]
    //maze array that defines where prefabs are in the scene
    public int[,] mazeArray = //45 x 32
        {{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
         { 1,1,1,1,1,1,3,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,1,1 },
         { 1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,1,1 },
         { 1,1,1,1,1,1,0,0,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,1,1,1,1,1,1,0,0,1,0,0,0,0,1,1,1 },
         { 1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,1,1,1 },
         { 1,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,1,0,0,1,1,1 },
         { 1,0,0,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,1,1 },
         { 1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,1,0,0,1,1,1 },
         { 1,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,1,0,0,1,1,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,1,1 },
         { 1,1,1,1,1,0,0,1,0,0,1,0,0,1,1,1,0,0,1,0,0,0,0,0,0,1,0,0,1,1,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1 },
         { 1,0,0,0,0,0,0,1,0,0,0,0,0,1,1,1,2,2,1,0,0,0,0,0,0,1,0,0,1,1,1,0,0,0,1,0,0,0,1,1,0,0,0,0,1 },
         { 1,0,0,0,0,0,0,1,0,0,0,0,0,1,1,1,2,2,1,0,1,1,1,1,1,1,0,0,1,1,1,0,0,0,1,0,0,0,1,1,1,1,1,1,1 },
         { 1,0,0,1,1,1,1,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,1 },
         { 1,0,0,0,0,0,0,1,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,1 },
         { 1,0,0,0,0,0,0,1,0,0,0,1,0,0,0,1,1,0,0,0,1,1,1,1,0,0,0,1,1,0,0,0,1,0,0,1,1,1,1,1,1,1,0,0,1 },
         { 1,1,1,1,1,0,0,1,0,0,0,1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,1,1,1,0,0,1 },
         { 1,1,1,1,1,0,0,1,1,0,0,1,0,0,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,1,1,1,0,0,1 },
         { 1,0,0,0,0,0,0,1,1,0,0,1,0,0,3,1,1,0,0,0,1,1,1,1,0,0,0,1,1,0,0,0,1,1,1,1,1,0,0,1,1,1,0,0,1 },
         { 1,0,0,0,0,0,0,1,1,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,1,1,0,0,1 },
         { 1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,0,0,0,0,0,0,0,1 },
         { 1,1,0,0,0,0,0,0,0,1,0,0,0,1,1,1,0,0,1,1,1,1,1,1,1,1,2,2,1,1,1,0,0,0,0,0,0,0,0,1,1,1,0,0,1 },
         { 1,1,0,0,0,0,0,0,0,1,0,0,0,1,1,1,0,0,1,0,0,0,0,0,0,1,2,2,1,1,1,0,0,0,0,0,0,0,0,1,1,1,0,0,1 },
         { 1,1,0,0,1,0,0,1,1,1,1,0,0,1,1,1,0,0,1,0,0,0,0,0,0,1,0,0,1,1,1,0,0,1,1,1,1,1,1,1,1,1,0,0,1 },
         { 1,1,0,0,1,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,1 },
         { 1,1,0,0,1,0,0,1,1,1,1,0,0,1,0,0,0,0,0,0,0,1,1,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,0,1 },
         { 1,1,0,0,1,0,0,1,1,1,1,0,0,1,0,0,1,1,1,0,0,0,0,0,0,1,1,1,0,0,1,1,1,1,1,0,0,1,0,0,1,1,1,1,1 },
         { 1,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,1,0,0,0,0,0,0,1,0,0,0,0,0,3,1 },
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
        MazeGeneratorFunc(mazeArray,45,32); //function that builds the maze
        
        
        //build navmesh based on now made maze
        m_navmesh = GetComponent<NavMeshSurface>();
        m_navmesh.BuildNavMesh();
    }

    void MazeGeneratorFunc(int[,] mazeMap, int height, int width)
    {
        List<GameObject> teleporterList;
        teleporterList = new List<GameObject>();
        int teleporterLength = 0;

        //goes through array and places prefabs based on the value in the array
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
                       GameObject newteleport = Instantiate(TeleportPrefab, new Vector3(j, 1.9f, i), Quaternion.identity);
                        teleporterList.Add(newteleport); //adds teleporters to a list of them all
                        teleporterLength++; //length of the list
                        break;
                }
            }
        }
        //goes through the list and sets the component values
        for (int i = 0; i < teleporterLength; i++)
        {
            teleporterList[i].GetComponent<Teleporter>().SetTeleportersList(teleporterList, teleporterLength);
        }

        StartCoroutine(scoreObjectHandler());
    }

    void NewScoreObject(Vector3 position)
    {
        //puts a new score object in
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

    //coroutine that spawns new score handlers every set amount of time
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
