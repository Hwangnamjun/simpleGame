using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helixCreate : MonoBehaviour {

    public float deleteCount = 0;
    public float createCount = 0;
    public GameObject currenthelix;
    Vector3 lastPos;
    public GameObject platformY;
    private float sizeY;
    public List<GameObject> plantcheck = new List<GameObject>();
    public GameObject parentCylinder;

    // Use this for initialization
    void Start ()
    {
        lastPos = currenthelix.transform.position;
        sizeY = platformY.transform.localScale.y;
        lastPos = currenthelix.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (deleteCount == 7)
        {
            deleteCount = -3f;
            helixCtrating();
        }
    }

    private void helixCtrating()
    {
        GameObject _platform = Instantiate(platformY) as GameObject;
        _platform.transform.parent = parentCylinder.transform;
        _platform.transform.position = lastPos + new Vector3(0, -(sizeY * 12.25f), 0);
        _platform.transform.localScale = new Vector3(0.1632802f, 0.4898401f, 0.16328f);
        for(int i = 0; i < 9; i++)
        {
            int rotY = Random.Range(0, 361);
            _platform.transform.GetChild(i).transform.rotation = Quaternion.Euler(0, rotY, 0);

            int trapNum = Random.Range(0, 10);
            int trapNum2 = 0;
            int trapNum3 = 0;
            int trapNum4 = 0;

            _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum).tag = "DeadZone";
            _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum).GetComponent<MeshCollider>().convex = true;
            _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum).GetComponent<MeshCollider>().isTrigger = true;
            _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum).GetComponent<MeshRenderer>().materials[0].color = Color.red;

            if (createCount > 30)
            {
                while (true)
                {
                    trapNum2 = Random.Range(0, 10);
                    if (trapNum2 != trapNum) break;
                }
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum2).tag = "DeadZone";
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum2).GetComponent<MeshCollider>().convex = true;
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum2).GetComponent<MeshCollider>().isTrigger = true;
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum2).GetComponent<MeshRenderer>().materials[0].color = Color.red;
            }

            if (createCount > 60)
            {
                while (true)
                {
                    trapNum3 = Random.Range(0, 10);
                    if (trapNum3 != trapNum && trapNum3 != trapNum2) break;
                }
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum3).tag = "DeadZone";
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum3).GetComponent<MeshCollider>().convex = true;
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum3).GetComponent<MeshCollider>().isTrigger = true;
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum3).GetComponent<MeshRenderer>().materials[0].color = Color.red;
            }

            if (createCount > 90)
            {
                while (true)
                {
                    trapNum4 = Random.Range(0, 10);
                    if (trapNum4 != trapNum && trapNum4 != trapNum2 && trapNum4 != trapNum3) break;
                }
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum4).tag = "DeadZone";
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum4).GetComponent<MeshCollider>().convex = true;
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum4).GetComponent<MeshCollider>().isTrigger = true;
                _platform.transform.GetChild(i).transform.GetChild(0).transform.GetChild(trapNum4).GetComponent<MeshRenderer>().materials[0].color = Color.red;
            }
        }

        lastPos = _platform.transform.position;
        plantcheck.Add(platformY);
    }

}
