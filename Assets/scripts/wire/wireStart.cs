using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wireStart : MonoBehaviour {

    public GameObject Score;
    public GameObject Player;
    public GameObject wave;
    public GameObject KH_back;
    private Animator NowHowAnim;
    public GameObject Maintitle;
    public GameObject Konw;
    public GameObject CeilingManager;
    public GameObject MainName;
    public GameObject wavescript;
    public GameObject vcam2;
    public GameObject playerRender;
    public GameObject lineRender;
    public GameObject Pauseui;
    // Use this for initialization
    private void Awake()
    {
    }
    void Start ()
    {
        playerRender.GetComponent<Renderer>().enabled = false;
        lineRender.GetComponent<Renderer>().enabled = false;
        MainName.SetActive(true);
        vcam2.SetActive(true);
        wavescript.GetComponent<DeadZone>().enabled = false;
        Player.GetComponent<Renderer>().enabled = false;
        Player.GetComponent<wirePlayer>().enabled = false;
        Player.GetComponent<Rigidbody>().isKinematic = true;
        Score.SetActive(false);
        NowHowAnim = Konw.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseClick();
        }
    }
    public void TimingIsNow()
    {
        Player.GetComponent<Renderer>().enabled = true;
        playerRender.GetComponent<Renderer>().enabled = true;
        lineRender.GetComponent<Renderer>().enabled = true;
        vcam2.SetActive(false);
        MainName.SetActive(false);
        wavescript.GetComponent<DeadZone>().enabled = true;
        Player.GetComponent<wirePlayer>().enabled = true;
        Player.GetComponent<Rigidbody>().isKinematic = false;
        Score.SetActive(true);
    }
    public void KonwHow_Click()
    {
        KH_back.SetActive(true);
        NowHowAnim.SetTrigger("Hello");
    }
    public void KonwHow_nonClick()
    {
        KH_back.SetActive(false);
        NowHowAnim.SetTrigger("Bye");
    }
    public void wireExit()
    {
        SceneManager.LoadScene("mainTitle");
    }
    public void ResetGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void newGame()
    {
        SceneManager.LoadScene(2);
    }
    public void PauseClick()
    {
        Time.timeScale = 0;
        GameObject.Find("WirePlayer").GetComponent<wirePlayer>().enabled = false;
        KH_back.SetActive(true);
        Pauseui.SetActive(true);
    }
    public void PauseNonClick()
    {
        KH_back.SetActive(false);
        Pauseui.SetActive(false);
        Time.timeScale = 1;
        GameObject.Find("WirePlayer").GetComponent<wirePlayer>().enabled = true;
    }
}
