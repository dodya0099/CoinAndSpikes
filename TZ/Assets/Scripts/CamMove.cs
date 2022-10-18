using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform target;
    public float smooth = 5.0f;
    public Vector3 offset = new Vector3(0, 9.5f, 0);
    public float leftLimit;
    public float rightLimit;
    public float topLimit;
    public float botLimit;
    

    void Start()
    {

    }


    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * smooth);
        }
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
        transform.position.y,
        Mathf.Clamp(transform.position.z, botLimit, topLimit));
    }

    


}
