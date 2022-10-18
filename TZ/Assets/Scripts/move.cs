using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class move : MonoBehaviour
{
    public GameObject cam;
    public GameObject MovingPoint;
    public float speed = 0.01f;
    private float progress;
    public GameObject MPoint;
    public GameObject Coin;
    public GameObject Spike;
    public GameObject Explosion;
    public GameObject TakeCoin;
    public GameObject PanelWin;
    public GameObject PanelLose;

    public MeshCollider plane;
    public float x, z;
    Vector3 Possit;
    Vector3 SpawnPos;
    int scoreNum = 0;
    public Text scoreNumText;
    public AudioClip[] Sound;
    public AudioSource Audio;
    

    void Start()

    {
        scoreNumText.text = "монеток :" + scoreNum.ToString();
        SpawnCoinsAndSpikes();
    }

   
    void Update()
    {       
     MousePos();
       Moving();
        Win();
    }

     void MousePos()
    {
        if (PanelWin.activeSelf == false && PanelLose.activeSelf == false)
        {
            if (Input.GetMouseButtonDown(0))

            {
                var camera = cam.GetComponent<Camera>();

                var mousePos2D = Input.mousePosition;

                var mousePosNearClipPlane = new Vector3(mousePos2D.x, mousePos2D.y, 9.5f);

                var worldPointPos = camera.ScreenToWorldPoint(mousePosNearClipPlane);

                Debug.Log("    " + worldPointPos);

                Instantiate(MovingPoint, worldPointPos, transform.rotation);
            }
        }

    }
     void Moving()
    {
        MPoint = GameObject.Find("MovingPoint(Clone)");
        if (MPoint != null)
        {
            if (transform.position != MPoint.transform.position)
            {
             

                progress += Time.deltaTime * speed;

                transform.position = Vector3.Lerp(transform.position, MPoint.transform.position, progress);

            }
            if (transform.position == MPoint.transform.position)
            {
                Destroy(MPoint);

                progress = 0;
            }
        }
    }
     void SpawnCoinsAndSpikes()
    {
        int N = Random.Range(5, 20);
        for (int i = 0; i < N; i++) 
        {
            x = Random.Range(plane.transform.position.x  - Random.Range(0, plane.bounds.extents.x), plane.transform.position.x +  Random.Range(0, plane.bounds.extents.x));
            z = Random.Range(plane.transform.position.z  - Random.Range(0, plane.bounds.extents.z), plane.transform.position.z +  Random.Range(0, plane.bounds.extents.z));
            SpawnPos = new Vector3(x, 1f, z);
            Instantiate(Coin, SpawnPos, transform.rotation);
                    }
        int R = Random.Range(5, 30);
        for (int i = 0; i < R; i++)
        {
            x = Random.Range(plane.transform.position.x - Random.Range(0, plane.bounds.extents.x), plane.transform.position.x + Random.Range(0, plane.bounds.extents.x));
            z = Random.Range(plane.transform.position.z - Random.Range(0, plane.bounds.extents.z), plane.transform.position.z + Random.Range(0, plane.bounds.extents.z));
            SpawnPos = new Vector3(x, 1.1f, z);
            Instantiate(Spike, SpawnPos, transform.rotation);
        }
    }
     void Win()
    {
        GameObject[] numCoins = GameObject.FindGameObjectsWithTag("Coin");
        int numToWin = numCoins.Length;
        if (numToWin == 0)
        {
            PanelWin.SetActive(true);
            
        }
    }
     void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.tag == "Coin")
        {
            Audio.clip = Sound[0];
            Audio.Play();
            Possit = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y + 0.5f,other.gameObject.transform.position.z);
            Instantiate(TakeCoin, Possit, transform.rotation);
            Destroy(other.gameObject);
            scoreNum++;
            scoreNumText.text = "монеток :" + scoreNum.ToString();
            
        }
        if (other.gameObject.tag == "Spike" || other.gameObject.tag == "WallSpikes")
        {
            Destroy(gameObject);
            Instantiate(Explosion, transform.position, transform.rotation);
        }
        
    }
  

}

