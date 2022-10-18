using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExAndRest : MonoBehaviour

    
{

    public GameObject PanelLose;
    

    void Start()
    {
        
    }

   
    void Update()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if ( Player == null )
        {
            PanelLose.SetActive(true);
        }
    }
    public void RestartPressed()
    {
        SceneManager.LoadScene("Game");

    }
    public void ExitPressed()
    {
        Application.Quit();

    }
}
