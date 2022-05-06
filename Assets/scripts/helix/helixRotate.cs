using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helixRotate : MonoBehaviour {


    float speed = 5f;
    bool startcheck = false;
    public bool endcheck = false;

    private void Awake()
    {
        startcheck = false;
    }
    public void starthelix()
    {
        startcheck = true;
    }

    private void OnMouseDrag()
    {
        if(startcheck == true && endcheck == false)
        {
            float rotx = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;

            transform.RotateAround(Vector3.up, -rotx);
        }
    }
}
