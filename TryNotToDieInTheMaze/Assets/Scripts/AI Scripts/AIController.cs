using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] GameObject AI1;
    [SerializeField] GameObject AI2;
    [SerializeField] GameObject AI3;
    [SerializeField] GameObject AI4;

    void Start()
    {
        AI1.SetActive(false);
        AI2.SetActive(false);
        AI3.SetActive(false);
        AI4.SetActive(false);
    }
    void Update()
    {
        //needs to activate and place AIs when the player reaches a certain score.
    }
}
