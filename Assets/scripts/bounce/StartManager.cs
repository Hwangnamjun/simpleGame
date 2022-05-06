using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour {

    public GameObject Startscore;
    public GameObject Maintitle;
    public GameObject MainName;
    public GameObject Konw;
    public GameObject KH_back;
    private Animator gameStartAnim;
    private Animator NowHowAnim;
    public GameObject Player;
    public GameObject vCam2;
    public GameObject dollyCart;
    public GameObject Pauseui;
    private void Awake()
    {
        Pauseui.SetActive(false);
        vCam2.SetActive(true);
        Player.SetActive(false);
        NowHowAnim = Konw.GetComponent<Animator>();
        gameStartAnim = Maintitle.GetComponent<Animator>();
        gameStartAnim.SetTrigger("Start");
        Startscore.SetActive(false);
        Maintitle.SetActive(true);
        MainName.SetActive(true);
        KH_back.SetActive(false);
        dollyCart.SetActive(true);
    }
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseClick();
        }
    }

    public void TimingIsNow()
    {
        vCam2.SetActive(false);
        Startscore.SetActive(true);
        MainName.SetActive(false);
        Player.SetActive(true);
        dollyCart.SetActive(false);
    }
    public void PauseClick()
    {
        Time.timeScale = 0;
        GameObject.Find("Player").GetComponent<PlayerScript>().enabled = false;
        KH_back.SetActive(true);
        Pauseui.SetActive(true);
    }
    public void PauseNonClick()
    {
        KH_back.SetActive(false);
        Pauseui.SetActive(false);
        Time.timeScale = 1;
        GameObject.Find("Player").GetComponent<PlayerScript>().enabled = true;
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
    public void bounceExit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("mainTitle"); 
    }

}
