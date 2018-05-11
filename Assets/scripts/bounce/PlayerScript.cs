using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float speed;

    private Vector3 dir;

    public GameObject ps;

    private bool isDead;

    public GameObject resetBtn;

    private int score = 0;

    public Text scoreText;

    public Animator gameOverAnim;

    public Text HighScore;

    public Image backGround;

    public Text[] scoreTexts;

    public LayerMask whatIsGround;

    private bool isPlaying = false;

    public Transform contactPoint;

    public bool scoreImpact;

    public GameObject vCamera;
	// Use this for initialization
	void Start ()
    {
        isDead = false;
        dir = Vector3.zero;
        vCamera.SetActive(true);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(!IsGrounded() && isPlaying)
        {
            isDead = true;

            GameOver();

            resetBtn.SetActive(true);

            if (transform.childCount > 0)
            {
                vCamera.SetActive(false);
                //transform.GetChild(0).transform.parent = null;
            }
        }
        if (Input.GetMouseButtonDown(0) && !isDead && Time.timeScale == 1)
        {
            isPlaying = true;
            score++;
            scoreText.text = score.ToString();

            if (dir == Vector3.forward)
            {
                dir = Vector3.left;
            }
            else
            {
                dir = Vector3.forward;
            }
        }

        float amoutToMove = speed * Time.deltaTime;

        transform.Translate(dir * amoutToMove);
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
            score+= 3;
            scoreText.text = score.ToString();
            CombatTextManager.Instance.CreateText(other.transform.position, "+3", new Color32(255, 38, 38, 255), true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Tile")
        {
            RaycastHit hit;

            Ray downRay = new Ray(transform.position, -Vector3.up);

            if (!Physics.Raycast(downRay, out hit))
            {
                isDead = true;
                GameOver();
                resetBtn.SetActive(true);
                if (transform.childCount > 0)
                {
                    //transform.GetChild(0).transform.parent = null;
                    vCamera.SetActive(false);
                }
            }
        }
    }
    private void GameOver()
    {
        gameOverAnim.SetTrigger("GameOver");

        scoreTexts[1].text = score.ToString();

        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if(score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            HighScore.gameObject.SetActive(true);
            backGround.color = new Color32(255, 255, 154, 255);
            foreach(Text txt in scoreTexts)
            {
                txt.color = Color.black;
            }
        }
        scoreTexts[3].text = PlayerPrefs.GetInt("BestScore", 0).ToString();
    }
    private bool IsGrounded()
    {
        Collider[] colliders = Physics.OverlapSphere(contactPoint.position, 0.5f, whatIsGround);

        for(int i =0; i < colliders.Length; i++)
        {
            if(colliders[i].gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }
}
