using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start : MonoBehaviour
{
   
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void PlayPressed()
    {
        SceneManager.LoadScene("Game");
      
    }
    public void ExitPressed()
    {
        Application.Quit();
       
    }
}
