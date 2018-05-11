using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour {

    public GameObject _obj;

    public float sizeUP = 0;

    public GameObject WirePlayer;

    // Use this for initialization
    void Start ()
    {
        sizeUP = 0.01f;


    }
	
	// Update is called once per frame
	void Update ()
    {
        WirePlayer = GameObject.FindGameObjectWithTag("Player");

        this.gameObject.transform.localScale += new Vector3(0, 0,sizeUP);

        if (this.gameObject.GetComponent<HingeJoint>() == null)
        {
            this.gameObject.transform.position = WirePlayer.transform.position;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Ceiling")
        {
            if(this.gameObject.GetComponent<HingeJoint>() == null)
            {
                this.gameObject.AddComponent<HingeJoint>();
            }
            sizeUP = 0;
            HingeJoint hinge = GetComponent<HingeJoint>();
            JointSpring hingeSpring = hinge.spring;
            hingeSpring.spring = 20;
            hingeSpring.damper = 0;
            hingeSpring.targetPosition = -100;
            hinge.spring = hingeSpring;
            hinge.useSpring = true;
            _obj = other.gameObject;
            this.gameObject.GetComponent<HingeJoint>().anchor = new Vector3(0, -0.67f, 59.04f);
            this.GetComponent<HingeJoint>().connectedBody = other.GetComponent<Rigidbody>();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        //_obj = null;
    }
}
