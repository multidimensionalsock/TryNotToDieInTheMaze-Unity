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
        startPoint = transform.position;
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (lives == 0)
        {
            SceneManager.LoadScene("EndScene");
            //end screen
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            transform.position = startPoint;
            UI.GetComponent<UIvariables>().RemoveLife();
            lives--;
        }
    }
    
}
