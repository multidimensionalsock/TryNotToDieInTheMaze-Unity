using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//UI for start screen
public class PlayGameButton : MonoBehaviour
{
    public void loadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void loadInstruction()
    {
        SceneManager.LoadScene("InstructionScene");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
