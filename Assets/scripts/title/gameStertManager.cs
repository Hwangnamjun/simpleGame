using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class gameStertManager : MonoBehaviour {

    public GameObject startImg;
    public GameObject HelpArrow;
    public bool checkScale = false;
    public static gameStertManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        if (SceneManager.GetActiveScene().name == "mainTitle")
        {
            startImg = GameObject.Find("titleimg");
            HelpArrow = GameObject.Find("Arrow");
            if (checkScale == false)
            {
                Time.timeScale = 0;
            }
            else
            {
                startImg.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {

        if (SceneManager.GetActiveScene().name == "mainTitle")
        {
            startImg = GameObject.Find("titleimg");
            HelpArrow = GameObject.Find("Arrow");
            if (checkScale == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    startImg.SetActive(false);
                    checkScale = true;
                    Time.timeScale = 1;
                }
            }
            else if (checkScale == true)
            {
                if (startImg == null)
                {
                    return;
                }
                else
                {
                    HelpArrow.SetActive(false);
                    startImg.SetActive(false);
                }
            }
        }
	}
}
