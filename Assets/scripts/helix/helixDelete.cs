using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helixDelete : MonoBehaviour {

    helixCreate helixcreate;
    public Vector3 cylinderCol;
	// Use this for initialization
	void Start ()
    {
        helixcreate = GameObject.Find("helixCreate").GetComponent<helixCreate>();
    }
	
    public void delete()
    {
        transform.parent = null;
        cylinderCol = GameObject.Find("Cylinder").GetComponent<CapsuleCollider>().center += new Vector3(0,-0.1f,0);
        helixcreate.deleteCount++;
        helixcreate.createCount++;
        Destroy(gameObject);
    }
}
