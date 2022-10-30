using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [Header ("Maze Variables")]
    private int[,] mazeArray =
        {{ 1, 1, 1, 1, 1},
         { 1, 0, 0, 0, 1},
         { 1, 0, 0, 0, 1},
         { 1, 0, 0, 0, 1},
         { 1, 1, 1, 1, 1}};

    [Header("Prefab Variables")]
    public GameObject wallPrefab; //1
    public GameObject SpeedPatchPrefab; //2
    public GameObject TeleportPrefab; //3

    void Start()
    {
        MazeGeneratorFunc(mazeArray,5,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MazeGeneratorFunc(int[,] mazeMap, int height, int width)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                switch (mazeMap[i, j])
                {
                    case 1:
                        Instantiate(wallPrefab, new Vector3(i, 1.9f, j), Quaternion.identity);
                        break;
                    case 2:
                        Instantiate(SpeedPatchPrefab, new Vector3(i, 1.9f, j), Quaternion.identity);
                        break;
                    case 3:
                        Instantiate(TeleportPrefab, new Vector3(i, 1.9f, j), Quaternion.identity);
                        break;
                }
            }
        }
    }         
}