using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lose : MonoBehaviour
{
    public AudioSource LoseSound;
    
    void Start()
    {
        LoseSound.Play();
    }

}
