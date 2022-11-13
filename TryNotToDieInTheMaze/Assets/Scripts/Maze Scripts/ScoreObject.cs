using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    UIvariables updateScore;
    [SerializeField] GameObject scoreObject;
    // Start is called before the first frame update
    void Start()
    {
        updateScore = scoreObject.GetComponent<UIvariables>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        updateScore.AddScore(1);
        Destroy(gameObject);
    }
}
