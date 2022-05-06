using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCtrl : MonoBehaviour {

    const float RayCastMaxDistance = 100.0f;
    InputManager inputManager;
    public GameObject clickImg;

	// Use this for initialization
	void Start ()
    {
        inputManager = FindObjectOfType<InputManager>();
    }
	
	// Update is called once per frame
	void Update () {
        Walking();
	}
    void Walking()
    {
        if(inputManager.Clicked())
        {
            Vector2 clickPos = inputManager.getCurserposition();
            Ray ray = Camera.main.ScreenPointToRay(clickPos);
            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo, RayCastMaxDistance,1 << LayerMask.NameToLayer("Ground")))
            {
                SendMessage("SetDestination", hitInfo.point);
                clickImg.transform.position = hitInfo.point;
                clickImg.SetActive(true);
            }
        }
    }
}
