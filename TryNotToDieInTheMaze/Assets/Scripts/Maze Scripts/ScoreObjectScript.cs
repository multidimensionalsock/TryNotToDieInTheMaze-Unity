using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObjectScript : MonoBehaviour
{
    UIvariables updateScore;
    // Start is called before the first frame update
    //void Start(GameObject UI)
    //{
    //    updateScore = UI.GetComponent<UIvariables>();
    //}

    private void OnCollisionEnter(Collision collision)
    {
        updateScore.AddScore(1);
        Destroy(gameObject);
    }

    public void SetUI(GameObject UI)
    {
        updateScore = UI.GetComponent<UIvariables>();
    }
}
