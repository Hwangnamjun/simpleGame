using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ByeEvent : MonoBehaviour {

    public GameObject back;
    public GameObject PlayerObj;
    public GameObject mainManagerObj;
    // Use this for PlayerObj
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ByeFinish()
    {
        PlayerObj.GetComponent<CharacterMove>().enabled = true;
        PlayerObj.transform.position = new Vector3(0.02f, 2.06f, -19.52f);
        back.SetActive(false);
    }
    public void selectFinish()
    {
        PlayerObj.GetComponent<CharacterMove>().enabled = true;
        PlayerObj.transform.position = new Vector3(0.02f, 2.06f, -19.52f);
        mainManagerObj.GetComponent<MainManager>().selectBool = false;
        back.SetActive(false);
    }
    public void HelpFinish()
    {
        PlayerObj.GetComponent<CharacterMove>().enabled = true;
        mainManagerObj.GetComponent<MainManager>().selectBool = false;
        back.SetActive(false);
    }
}
