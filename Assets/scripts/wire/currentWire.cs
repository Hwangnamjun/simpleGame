using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentWire : MonoBehaviour {

    public wirePlant plantcount;
    // Use this for initialization
    void Start()
    {
        plantcount = GameObject.Find("WirePlant").GetComponent<wirePlant>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "current")
        {
            Invoke("FallDown", 1f);
        }
    }
    private void FallDown()
    {
        Destroy(this.transform.parent.gameObject, 2f);
        plantcount.plantcount += -1;
    }
}
