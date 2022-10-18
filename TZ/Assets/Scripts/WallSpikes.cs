using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpikes : MonoBehaviour
{
    public AudioSource Audio;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
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
            Destroy(other.gameObject);

        }
    }
}
