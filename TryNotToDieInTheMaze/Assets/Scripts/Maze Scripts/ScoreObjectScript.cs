using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handles the score objects
public class ScoreObjectScript : MonoBehaviour
{
    UIvariables updateScore;
    private void OnTriggerEnter(Collider other)
    {
        updateScore.AddScore(1); //adds score to UI
        gameObject.SetActive(false);
    }

    //sets the UI score
    public void SetUI(GameObject UI)
    {
        updateScore = UI.GetComponent<UIvariables>();
    }
}
