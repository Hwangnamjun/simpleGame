using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wirePlayer : MonoBehaviour {

    public GameObject Line;
    private int clickNum;
    public GameObject CreatePos;
    public bool clickCheck = true;
    public GameObject[] countLine ;

    // Use this for initialization
    void Start ()

    {
        clickNum = 0;
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        countLine = GameObject.FindGameObjectsWithTag("Line");

        clickNum = clickNum % 2;

        SignClick();

        ClickEvent();

    }

    void SignClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickNum++;
        }
        if (clickNum == 0)
        {
            clickCheck = true;
        }
        else if (clickNum == 1)
        {
            clickCheck = false;
        }
    }
    void ClickEvent()
    {
        if(clickCheck == false)
        {
            if(countLine.Length == 1)
            {
                Destroy(countLine[0]);
                Destroy(this.GetComponent<HingeJoint>());
            }
        }
        else if(clickCheck == true)
        {
            if(countLine.Length == 0)
            {
               Instantiate(Line, CreatePos.transform.position, Quaternion.Euler(new Vector3(-45f,90,0)));
                countLine = GameObject.FindGameObjectsWithTag("Line");
            }
            if (countLine[0].GetComponent<HingeJoint>() != null)
            {
                if(this.GetComponent<HingeJoint>() == null)
                {
                    this.gameObject.AddComponent<HingeJoint>();
                }
                this.GetComponent<HingeJoint>().connectedBody = countLine[0].GetComponent<Rigidbody>();
            }
        }

    }
}
