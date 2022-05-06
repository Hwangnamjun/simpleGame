using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerrote : MonoBehaviour {

    private int Xrotate = 0;
    private CharacterMove charactermove;
    // Use this for initialization
    void Start ()
    {
        charactermove = gameObject.GetComponentInParent<CharacterMove>();
    }
	
	// Update is called once per frame
	void Update ()

    {
        transform.Rotate(new Vector3(Xrotate, 0, 0));

        if (charactermove.arrived)
        {
            Xrotate = 0;
        }
        else
        {
            Xrotate = 10;
        }
    }
}
