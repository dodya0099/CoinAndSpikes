using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destrSpikes : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {

           
        if (other.gameObject.tag == "Spike")
        {
            Destroy(other.gameObject);
        }
    }
}
