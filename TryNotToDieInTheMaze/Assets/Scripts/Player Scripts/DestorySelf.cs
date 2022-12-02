using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestorySelf : MonoBehaviour
{
    Vector3 startPoint;
    int lives = 3;
    [SerializeField] GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        startPoint = new Vector3(19, 2, 15.5f);
        transform.position = startPoint;
    }
    
    private void GoToEndScreen()
    {
        Debug.Log("player dead");
        SceneManager.LoadScene("EndScene");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.position = startPoint;
            UI.GetComponent<UIvariables>().RemoveLife();
            lives--;
            if (lives == 0)
            {
                GoToEndScreen();
            }
        }
    }
    
}
