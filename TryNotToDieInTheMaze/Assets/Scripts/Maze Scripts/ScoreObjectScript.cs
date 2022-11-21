using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObjectScript : MonoBehaviour
{
    UIvariables updateScore;
    private void OnTriggerEnter(Collider other)
    {
        updateScore.AddScore(1);
        gameObject.SetActive(false);
    }

    public void SetUI(GameObject UI)
    {
        updateScore = UI.GetComponent<UIvariables>();
    }
}
