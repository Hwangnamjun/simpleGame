using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    public GameObject PlayerWire;
    public GameObject Cam;
    public float Zonesize;
    public float Timer;
    public int randomIndex;
    public bool check = false;
    public bool sizecheck = false;
    public bool playerZone;
    public bool pickItem = false;
    private float timeCheck;
    public float PlayerX;
    private float countlife;
    private bool countzone = false;
    public GameObject waterwave;
    public GameObject wavepoint;
    // Use this for initialization
    void Start ()
    {
        playerZone = false;
        randomIndex = Random.Range(1, 11);
    }
	
	// Update is called once per frame
	void Update ()
    {
        waterwave.transform.position = wavepoint.transform.position;
        if (check == false)
        {
            Timer += Time.deltaTime;
        }
        if(playerZone == false)
        {
            this.transform.position = new Vector3(PlayerWire.transform.position.x, -6f, 0);
        }

        //this.transform.localScale = new Vector3(28, Zonesize, 5);
        this.transform.localScale = new Vector3(50, Zonesize, 25);
        if(pickItem == false)
        {
            if (Zonesize < 6)
            {
                sizecheck = false;
                Zonesize = 6f;
            }
            if (playerZone == false)
            {
                PlayerX = PlayerWire.transform.position.x;
            }
            else if (playerZone == true)
            {
                PlayerX = Cam.transform.position.x;
            }
            if (countzone == true)
            {
                countlife += Time.deltaTime;
                if (countlife >= 5)
                {
                    PlayerWire.GetComponent<Rigidbody>().isKinematic = true;
                    countlife = 0;
                    countzone = false;
                }
            }
            Lookrandom();
            randomScale();
            sizeUpDown();
        }
        else
        {
            check = true;
            Timer = 0;
            eatitem();
        }
    }

    public void Lookrandom()
    {
        if (check == false && Timer > randomIndex)
        {
            check = true;
            randomIndex = Random.Range(1, 11);
            Timer = 0;
        }
    }
    public void randomScale()
    {
        if (check == true)
        {
            Zonesize += 0.1f;
        }
        else if (check == false)
        {
            return;
        }

        if(Zonesize > 13)
        {
            sizecheck = true;
            check = false;
        }
    }
    public void sizeUpDown()
    {
        if (sizecheck == true)
        {
            Zonesize -= 3f * Time.deltaTime;
        }
    }
    public void eatitem()
    {
        if(Zonesize > 6)
        {
            Zonesize -= 7f * Time.deltaTime;
        }
        if (Zonesize < 6)
        {
            sizecheck = false;
            Zonesize = 6f;
        }
        timeCheck += Time.deltaTime;
        if(timeCheck > 5)
        {
            pickItem = false;
            check = false;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            playerZone = true;
            countzone = true;
        }
    }
}
