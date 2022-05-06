﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wirePlayer : MonoBehaviour {

    public GameObject Line;
    private int clickNum;
    public GameObject CreatePos;
    public bool clickCheck = true;
    public GameObject[] countLine ;
    private int wirescore = 0;
    public Text scoreText;
    public Text[] wirescoreTexts;
    public GameObject PickupPs;
    public GameObject ItemPs;
    public bool isLive = true;
    public GameObject Vcamera;
    public Animator gameOverAnim;
    public Text wireHighScore;
    public Image backGround;
    public GameObject current;
    public wirePlant wirecount;
    public DeadZone deadzone;
    public GameObject dead;
    public AudioClip[] eventclip;
    // Use this for initialization
    void Start ()
    {
        deadzone = dead.GetComponent<DeadZone>();
        clickNum = 0;
        isLive = true;
        Vcamera.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        countLine = GameObject.FindGameObjectsWithTag("Line");

        clickNum = clickNum % 2;

        SignClick();

        ClickEvent();

    }

    void SignClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.GetComponent<AudioSource>().clip = eventclip[0];
            this.GetComponent<AudioSource>().Play();
            clickNum++;
        }
        if (clickNum == 0)
        {
            clickCheck = true;
        }
        else if (clickNum == 1)
        {
            clickCheck = false;
        }
    }
    void ClickEvent()
    {
        if(clickCheck == false && isLive == true)
        {
            if(countLine.Length == 1)
            {
                Destroy(countLine[0]);
                Destroy(this.GetComponent<HingeJoint>());
            }
        }
        else if(clickCheck == true && isLive == true)
        {
            if(countLine.Length == 0)
            {
                wirescore++;
                scoreText.text = wirescore.ToString();

                Instantiate(Line, CreatePos.transform.position, Quaternion.Euler(new Vector3(-45f,90,0)));
                countLine = GameObject.FindGameObjectsWithTag("Line");
            }
            if (countLine[0].GetComponent<HingeJoint>() != null)
            {
                if(this.GetComponent<HingeJoint>() == null)
                {
                    this.gameObject.AddComponent<HingeJoint>();
                }
                this.GetComponent<HingeJoint>().connectedBody = countLine[0].GetComponent<Rigidbody>();
            }
        }

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            Destroy(other.gameObject);
            wirecount.pickupcount += -1f;
            wirescore += 3;
            scoreText.text = wirescore.ToString();
            Instantiate(PickupPs, transform.position, Quaternion.identity);
            CombatTextManager.Instance.CreateText(other.transform.position, "+3", new Color32(255, 38, 38, 255), true);
        }
        if(other.tag == "Item")
        {
            Destroy(other.gameObject);
            deadzone.pickItem = true;
            wirecount.Itemcount += -1f;
            Instantiate(ItemPs, transform.position, Quaternion.identity);
        }
        if(other.tag == "DeadZone")
        {
            this.GetComponent<AudioSource>().clip = eventclip[1];
            this.GetComponent<AudioSource>().Play();

            current.SetActive(false);
            isLive = false;
            Vcamera.SetActive(false);
            GameOver();
            if (countLine.Length >= 1)
            {
                Destroy(countLine[0]);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "DeadZone")
        {
            Destroy(this);
        }
    }
    private void GameOver()
    {
        gameOverAnim.SetTrigger("GameOver");

        wirescoreTexts[1].text = wirescore.ToString();

        int bestWire = PlayerPrefs.GetInt("Bestwire", 0);

        if (wirescore > bestWire)
        {
            PlayerPrefs.SetInt("Bestwire", wirescore);
            wireHighScore.gameObject.SetActive(true);
            backGround.color = new Color32(255, 255, 154, 255);
            foreach (Text txt in wirescoreTexts)
            {
                txt.color = Color.black;
            }
        }
        wirescoreTexts[3].text = PlayerPrefs.GetInt("Bestwire", 0).ToString();
    }
    public void none()
    {
        Destroy(countLine[0]);
        clickCheck = false;
        clickNum++;
    }
}
