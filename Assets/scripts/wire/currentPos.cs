using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentPos : MonoBehaviour {

    public GameObject PlayerWire;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(PlayerWire.transform.position.x - 30, 4.93f, 0);
    }
}
