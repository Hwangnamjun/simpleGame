using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class soundManager : MonoBehaviour {

    public static soundManager Instance;
    public AudioClip[] BGMclip;
    public GameObject titleImage;
    private void Awake()
    {
        if (GameObject.Find("titleimg") != null)
        {
            titleImage = GameObject.Find("titleimg");
        }
        else
        {
            return;
        }

        if (Instance != null)
        {

            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
	// Update is called once per frame
	void Update () {

        if (SceneManager.GetActiveScene().name == "mainTitle")
        {
            if(titleImage != null)
            {
                if (titleImage.activeSelf == true)
                {
                    this.GetComponent<AudioSource>().clip = BGMclip[0];
                }
                else
                {
                    this.GetComponent<AudioSource>().clip = BGMclip[1];
                }
                if (this.GetComponent<AudioSource>().isPlaying == false)
                {
                    this.GetComponent<AudioSource>().Play();
                }
                else
                {
                    return;
                }
            }
            else if(titleImage == null)
            {
                this.GetComponent<AudioSource>().clip = BGMclip[1];

                if (this.GetComponent<AudioSource>().isPlaying == false)
                {
                    this.GetComponent<AudioSource>().Play();
                }
            }
        }
        if (SceneManager.GetActiveScene().name == "bunce")
        {
            this.GetComponent<AudioSource>().clip = BGMclip[2];

            if (this.GetComponent<AudioSource>().isPlaying == false)
            {
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                return;
            }
        }
        if (SceneManager.GetActiveScene().name == "wire")
        {
            this.GetComponent<AudioSource>().clip = BGMclip[3];

            if (this.GetComponent<AudioSource>().isPlaying == false)
            {
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                return;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Helix")
        {
            this.GetComponent<AudioSource>().clip = BGMclip[4];

            if (this.GetComponent<AudioSource>().isPlaying == false)
            {
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                return;
            }
        }
    }
}
