using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{

    public AudioSource WinSound;
    
    void Start()
    {
        WinSound.Play();
    }

}
