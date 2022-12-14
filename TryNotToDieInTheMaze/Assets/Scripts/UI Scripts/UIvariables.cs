using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//controls UI
public class UIvariables : MonoBehaviour
{
    private int m_score = 0;
    private int m_lives = 3;
    [SerializeField] TMP_Text m_ScoreText;

    void Start()
    {
        m_ScoreText.text = "Score: " + m_score.ToString() + "<br>Lives: " + m_lives;
    }

    public void AddScore(int points)
    {
        m_score += points;
        m_ScoreText.text = "Score: " + m_score.ToString() + "<br>Lives: " + m_lives;
    }
    
    public void RemoveLife()
    {
        m_lives--;
        m_ScoreText.text = "Score: " + m_score.ToString() + "<br>Lives: " + m_lives;
    }
}
