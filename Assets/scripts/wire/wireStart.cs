using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class wireStart : MonoBehaviour {

    public GameObject Score;
    public GameObject Player;
    public GameObject Line;
    public GameObject wave;
    public GameObject KH_back;
    private Animator gameStartAnim;
    private Animator NowHowAnim;
    public GameObject Maintitle;
    public GameObject Konw;
    public GameObject CeilingManager;
    public GameObject MainName;
    // Use this for initialization
    private void Awake()
    {
        Time.timeScale = 0;
    }
    void Start ()
    {
        MainName.SetActive(true);
        Player.GetComponent<wirePlayer>().enabled = false;
        Score.SetActive(false);
        NowHowAnim = Konw.GetComponent<Animator>();
        gameStartAnim = Maintitle.GetComponent<Animator>();
        gameStartAnim.SetTrigger("Start");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void TimingIsNow()
    {
        MainName.SetActive(false);
        Player.GetComponent<wirePlayer>().enabled = true;
        Time.timeScale = 1;
        CeilingManager.AddComponent<wirePlant>();
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
        Time.timeScale = 1;
        SceneManager.LoadScene("mainTitle");
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
    public void newGame()
    {
        SceneManager.LoadScene(2);
    }
}
