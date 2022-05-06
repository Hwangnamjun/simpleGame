using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeHeliox : MonoBehaviour {

    public GameObject playerPos;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.position = new Vector3(0 , playerPos.transform.position.y + 8.3f, 0);
    }
}
