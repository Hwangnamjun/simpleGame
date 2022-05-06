using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour {

    public GameObject back;
    public bool selectBool;
    public GameObject exit;
    private Animator exitAnim;
    public GameObject help;
    private Animator helpAnim;
    public GameObject PlayerObj;
    public GameObject select;
    private Animator gameSelectAnim;
    public GameObject WHATgame;
    public GameObject HOWgame;
    public GameObject clickImg;
    public GameObject titeimage;
    public GameObject playerobj;
    private float timer = 0;
    private float waittingtime = 0.5f;
    public GameObject helpArrow;

    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1920,1080, true);
        //Camera.main.orthographicSize = (Screen.height / (Screen.width / 16.0f)) / 9.0f;
        titeimage = GameObject.Find("titleimg");
        helpArrow = GameObject.Find("Arrow");
    }
    // Use this for initialization
    void Start ()
    {
        clickImg.SetActive(false);
        WHATgame.SetActive(false);
        HOWgame.SetActive(false);
        back.SetActive(false);
        selectBool = false;
        helpAnim = help.GetComponent<Animator>();
        gameSelectAnim = select.GetComponent<Animator>();
        exitAnim = exit.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(selectBool == false)
            {
                ExitClick();
                PlayerObj.GetComponent<CharacterMove>().enabled = false;
            }
        }
	}

    public void clickWhatis()
    {

        WHATgame.SetActive(true);
    }
    public void noonclickWhatis()
    {
        WHATgame.SetActive(false);
    }
    public void clickHowis()
    {
        HOWgame.SetActive(true);
    }
    public void nonclickHowis()
    {
        HOWgame.SetActive(false);
    }

    //도움말을 클릭하면
    public void SelectClick()
    {
        back.SetActive(true);
        selectBool = true;
        gameSelectAnim.SetTrigger("comeOn");
    }
    public void SelectNonClick()
    {
        gameSelectAnim.SetTrigger("goodBye");

    }
    public void SelectHelp()
    {
        playerobj.GetComponent<playerCtrl>().enabled = false;
        PlayerObj.GetComponent<CharacterMove>().enabled = false;
        back.SetActive(true);
        selectBool = true;
        helpAnim.SetTrigger("HelpClick");
    }
    public void SelectNonHelp()
    {
        playerobj.GetComponent<playerCtrl>().enabled = true;
        HOWgame.SetActive(false);
        WHATgame.SetActive(false);
        helpAnim.SetTrigger("HelpNonClick");
        if (GameObject.Find("Arrow"))
        {
            GameObject.Destroy(helpArrow);
        }
    }

    //게임종료 동굴로 들어가면
    public void ExitClick()
    {
        back.SetActive(true);
        exitAnim.SetTrigger("ExitHi");
    }
    public void ExitNonClick()
    {
        exitAnim.SetTrigger("ExitBye");
    }

    //게임선택
    public void clickBunce()
    {
        SceneManager.LoadScene("bunce");
    }
    public void clickWire()
    {
        SceneManager.LoadScene("wire");
    }
    public void clickHelix()
    {
        SceneManager.LoadScene("Helix");
    }

    //나가기 버튼눌리면
    public void clickExit()
    {
        if (!Application.isEditor)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
