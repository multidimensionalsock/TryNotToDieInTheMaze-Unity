using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    public GameObject wallPrefab;
    private int[,] mazeArray =
        {{1, 1, 1, 1, 1},
         { 1, 0, 0, 0, 1},
         { 1, 0, 0, 0, 1},
         { 1, 0, 0, 0, 1},
         { 1, 1, 1, 1, 1}};

    // Start is called before the first frame update
    void Start()
    {
        mazeGenerator(mazeArray,5,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void mazeGenerator(int[,] mazeMap, int height, int width)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (mazeMap[i,j] == 1)
                {
                    Instantiate(wallPrefab, new Vector3(i, 1.9f, j), Quaternion.identity);
                }
            }
        }
    }
}
