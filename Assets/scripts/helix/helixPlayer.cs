using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class helixPlayer : MonoBehaviour {

    public Rigidbody player;
    public float speed;
    public static float GlobalGravity = -9.8f;
    public float gravityScale = 1.0f;
    private bool isforce = false;
    private bool playerAlive;
    public Animator gameOverAnim;
    public int score = 0;
    public Text scoreText;
    public Text HighScore;
    public Text[] scoreTexts;
    public Image backGround;
    public GameObject Vcam1;
    public Animator playerDead;
    public GameObject currentPlayer;
    private helixRotate helixrotate;
    public GameObject deleteObj;
    private int checknum = 0;
    public AudioClip[] eventclip;
    // Use this for initialization
    void Start ()
    {
        helixrotate = GameObject.Find("Cylinder").GetComponent<helixRotate>();
        player = GetComponent<Rigidbody>();
        player.useGravity = false;
        playerAlive = true;
    }
    void FixedUpdate()
    {
        if(playerAlive == true)
        {
            Vector3 gravity = GlobalGravity * gravityScale * Vector3.up;

            player.AddForce(gravity, ForceMode.Acceleration);
        }
    }
    void Update()
    {
        if (isforce == true && playerAlive == true)
        {
            isforce = false;
            //player.AddForce(Vector3.up * speed, ForceMode.Impulse);
            player.velocity = new Vector3(0, 2.3f, 0);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag == "helix")
        {
            this.GetComponent<AudioSource>().clip = eventclip[0];
            this.GetComponent<AudioSource>().Play();

            if (checknum <= 1)
            {
                isforce = true;
                checknum = 0;
            }
            else if(checknum > 1)
            {
                score++;
                checknum = 0;
                scoreText.text = score.ToString();
                int Randomint = Random.Range(0, 3);
                if (Randomint == 0)
                {
                    col.gameObject.GetComponentInParent<Animator>().SetTrigger("break1");
                }
                if (Randomint == 1)
                {
                    col.gameObject.GetComponentInParent<Animator>().SetTrigger("break2");
                }
                if (Randomint == 2)
                {
                    col.gameObject.GetComponentInParent<Animator>().SetTrigger("break3");
                }
                col.transform.parent.transform.parent = deleteObj.transform;
            }
        }
    }
    void OnCollisionExit(Collision col)
    {
        if(col.transform.tag == "helix")
        {
            isforce = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "current")
        {
            score++;
            checknum++;
            scoreText.text = score.ToString();
            int Randomint = Random.Range(0, 3);
            if (Randomint == 0)
            {
                other.GetComponentInParent<Animator>().SetTrigger("break1");
            }
            if (Randomint == 1)
            {
                other.GetComponentInParent<Animator>().SetTrigger("break2");
            }
            if (Randomint == 2)
            {
                other.GetComponentInParent<Animator>().SetTrigger("break3");
            }
            other.transform.parent.transform.parent = deleteObj.transform;
        }
        if(other.tag == "DeadZone")
        {
            if(checknum <= 1)
            {
                this.GetComponent<AudioSource>().clip = eventclip[1];
                this.GetComponent<AudioSource>().Play();

                playerDead.SetTrigger("playerDead");
                this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                currentPlayer.SetActive(false);
                Vcam1.SetActive(false);
                playerAlive = false;
                gameOverAnim.SetTrigger("GameOver");
                gameover();
            }
            else if(checknum > 1)
            {
                score++;
                checknum = 0;
                scoreText.text = score.ToString();
                int Randomint = Random.Range(0, 3);
                if (Randomint == 0)
                {
                    other.GetComponentInParent<Animator>().SetTrigger("break1");
                }
                if (Randomint == 1)
                {
                    other.GetComponentInParent<Animator>().SetTrigger("break2");
                }
                if (Randomint == 2)
                {
                    other.GetComponentInParent<Animator>().SetTrigger("break3");
                }
                other.transform.parent.transform.parent = deleteObj.transform;
            }
        }
    }
    void gameover()
    {
        helixrotate.endcheck = true;
        scoreTexts[1].text = score.ToString();

        int bestScore = PlayerPrefs.GetInt("Besthelix", 0);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("Besthelix", score);
            HighScore.gameObject.SetActive(true);
            backGround.color = new Color32(255, 255, 154, 255);
            foreach (Text txt in scoreTexts)
            {
                txt.color = Color.black;
            }
        }
        scoreTexts[3].text = PlayerPrefs.GetInt("Besthelix", 0).ToString();
    }
}
