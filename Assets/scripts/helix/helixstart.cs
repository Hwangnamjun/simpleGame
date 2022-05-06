using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class helixstart : MonoBehaviour {

    public GameObject Konw;
    public GameObject KH_back;
    private Animator NowHowAnim;
    public GameObject Startscore;
    public GameObject Maintitle;
    public GameObject MainName;
    public GameObject Player;
    public GameObject Pauseui;
    private void Awake()
    {
        Player.SetActive(false);
        NowHowAnim = Konw.GetComponent<Animator>();
        Startscore.SetActive(false);
        Maintitle.SetActive(true);
        MainName.SetActive(true);
        KH_back.SetActive(false);
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
        Startscore.SetActive(true);
        MainName.SetActive(false);
        Player.SetActive(true);
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
    public void helixExit()
    {
        SceneManager.LoadScene("mainTitle");
    }
    public void helixReset()
    {
        SceneManager.LoadScene("Helix");
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
        GameObject.Find("Player").GetComponent<helixPlayer>().enabled = false;
        KH_back.SetActive(true);
        Pauseui.SetActive(true);
    }
    public void PauseNonClick()
    {
        KH_back.SetActive(false);
        Pauseui.SetActive(false);
        Time.timeScale = 1;
        GameObject.Find("Player").GetComponent<helixPlayer>().enabled = true;
    }
}
