using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentPos : MonoBehaviour {

    public GameObject PlayerWire;
    public wirePlant wireCount;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(PlayerWire.transform.position.x - 20, 4.93f, 0.82f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Pickup")
        {
            Destroy(other.gameObject);
            wireCount.pickupcount += -1;
        }
        if (other.gameObject.tag == "Item")
        {
            Destroy(other.gameObject);
            wireCount.Itemcount += -1;
        }
    }
}
