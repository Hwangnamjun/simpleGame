using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

    public GameObject back;
    private bool selectBool;
    public GameObject select;
    private Animator gameSelectAnim;

    // Use this for initialization
    void Start ()
    {
        back.SetActive(false);
        selectBool = false;
        gameSelectAnim = select.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(selectBool == true)
            {
                back.SetActive(false);
                selectBool = false;
                gameSelectAnim.SetTrigger("goodBye");
            }
            else if(selectBool == false)
            {
                if (!Application.isEditor)
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
            }
        }
	}
    public void SelectClick()
    {
        back.SetActive(true);
        selectBool = true;
        gameSelectAnim.SetTrigger("comeOn");
    }
    public void SelectNonClick()
    {
        back.SetActive(false);
        selectBool = false;
        gameSelectAnim.SetTrigger("goodBye");
    }
    public void clickBunce()
    {
        SceneManager.LoadScene("bunce");
    }
    public void clickExit()
    {
        if (!Application.isEditor)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
