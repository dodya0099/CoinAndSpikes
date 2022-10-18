using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public AudioSource Audio;

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            Audio.Play();
                      
        }
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "Spike")
        {
            Destroy(gameObject);

        }
    }
}
