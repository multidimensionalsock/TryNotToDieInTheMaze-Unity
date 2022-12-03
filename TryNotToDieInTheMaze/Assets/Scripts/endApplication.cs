using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endApplication : MonoBehaviour
{
    int wait = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            wait++;
            if (wait > 200)
            {
                EndApplication();
            }
        }
        else
        {
            wait = 0;
        }
    }

    static void EndApplication()
    {
        Debug.Log("application quit");
        Application.Quit();
    }
}
