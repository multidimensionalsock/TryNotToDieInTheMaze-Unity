using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIvariables : MonoBehaviour
{
    private int m_score = 0;
    [SerializeField] TMP_Text m_ScoreText;

    void Start()
    {
        m_ScoreText.text = "score: " + m_score.ToString();
    }

    public void AddScore(int points)
    {
        m_score += points;
        m_ScoreText.text = "score: " + m_score.ToString();
    }
    
}
