using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<playerCtrl>().enabled = true;

            Destroy(this.gameObject);
        }
    }
}
