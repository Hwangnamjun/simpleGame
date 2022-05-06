using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterRotate : MonoBehaviour {

    // Use this for initialization
    PlayerScript playerscript;
    private int Xrotate = 0;
    private int Zrotate = 0;

    void Start ()
    {
        playerscript = GameObject.Find("Player").GetComponent<PlayerScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(new Vector3(Xrotate, 0, Zrotate),Space.World);

        if (playerscript.dir == Vector3.forward)
        {
            Xrotate = 10;
            Zrotate = 0;
        }
        else if (playerscript.dir == Vector3.left)
        {
            Xrotate = 0;
            Zrotate = 10;
        }
    }
}
