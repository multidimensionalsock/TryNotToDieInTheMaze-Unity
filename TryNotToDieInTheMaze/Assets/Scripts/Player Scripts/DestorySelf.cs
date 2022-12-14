using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestorySelf : MonoBehaviour
{
    Vector3 startPoint; //point to move the player back to when they die
    int lives = 3;
    [SerializeField] GameObject UI;

    void Start()
    {
        startPoint = new Vector3(19, 2, 15.5f);
        transform.position = startPoint;
    }
    
    //sets the scene to end scene
    private void GoToEndScreen()
    {
        Debug.Log("player dead");
        SceneManager.LoadScene("EndScene");
    }

    //what happens if the player collides with the enemy
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.position = startPoint; //move the player to start point again
            UI.GetComponent<UIvariables>().RemoveLife(); //update the AI
            lives--;
            if (lives == 0)
            {
                GoToEndScreen();
            }
        }
    }
    
}
