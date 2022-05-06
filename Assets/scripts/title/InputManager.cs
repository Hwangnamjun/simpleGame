using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    Vector2 slideStartPosition;
    Vector2 prevPosition;
    Vector2 delta = Vector2.zero;
    bool moved = false;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
        {
            slideStartPosition = getCurserposition();
        }
        if(Input.GetMouseButton(0))
        {
            if (Vector2.Distance(slideStartPosition, getCurserposition()) >= (Screen.width * 0.1f))
            {
                moved = true;
            }
        }
        if(!Input.GetMouseButtonUp(0) && !Input.GetMouseButton(0))
        {
            moved = false;
        }
        if(moved)
        {
            delta = getCurserposition() - prevPosition;
        }
        else
        {
            delta = Vector2.zero;
        }

        prevPosition = getCurserposition();
    }
    public bool Clicked()
    {
        if(!moved && Input.GetMouseButtonUp(0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public Vector2 GetDeltaPosition()
    {
        return delta;
    }
    public bool Moved()
    {
        return moved;
    }
    public Vector2 getCurserposition()
    {
        return Input.mousePosition;
    }
}
