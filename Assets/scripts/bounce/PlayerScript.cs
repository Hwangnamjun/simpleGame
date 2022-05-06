using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float speed = 10;
    public int speedup = 1;
    public bool speedcount = false;
    public Vector3 dir;
    private bool isDead;
    public GameObject resetBtn;
    public int score = 0;
    public Text scoreText;
    public Animator gameOverAnim;
    public Text HighScore;
    public Image backGround;
    public Text[] scoreTexts;
    public LayerMask whatIsGround;
    private bool isPlaying = false;
    public Transform contactPoint;
    public bool scoreImpact;
    public GameObject ps;
    public GameObject vCamera;
    public Camera camcomponent;
    public Material tile;
    public GameObject playerlight;
    public Color32[] Tilecolor;
    public float timer;
    private bool colorswitch = false;
    private bool controlrandom = true;
    private int sideCamNum;
    private int randomCamNum;
    private int sideTileNum;
    private int randomTileNum;
    private bool Topcheck = false;
    private bool Leftcheck = false;
    private float jumpPower = 4;
    new Rigidbody rigidbody;
    bool isJumping;
    public AudioClip[] eventclip;
    // Use this for initialization

    void Start ()
    {
        this.GetComponent<SphereCollider>().enabled = true;
        rigidbody = GetComponent<Rigidbody>();
        isDead = false;
        dir = Vector3.zero;
        vCamera.SetActive(true);
        tile.color = Tilecolor[5];
        sideCamNum = 5;
        sideTileNum = 5;
        playerlight.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        changeColor();
        upspeed();
        //if (!IsGrounded() && isPlaying)
        //{
        //    isDead = true;

        //    GameOver();

        //    resetBtn.SetActive(true);

        //    if (transform.childCount > 0)
        //    {
        //        vCamera.SetActive(false);
        //    }
        //}
        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            this.GetComponent<AudioSource>().clip = eventclip[0];
            this.GetComponent<AudioSource>().Play();

            if (!Topcheck && !Leftcheck && !isJumping)
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
            else if(Topcheck)
            {
                if (!isJumping)
                {
                    return;
                }
                else
                {
                    dir = Vector3.forward;
                    isPlaying = true;
                    score++;
                    scoreText.text = score.ToString();
                    rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                    Topcheck = false;
                }
            }
            else if(Leftcheck)
            {
                if (!isJumping)
                {
                    return;
                }
                else
                {
                    dir = Vector3.left;
                    isPlaying = true;
                    score++;
                    scoreText.text = score.ToString();
                    rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                    Leftcheck = false;
                }
            }
        }

        if (sideTileNum == 0)
        {
            playerlight.SetActive(true);
        }
        else
        {
            playerlight.SetActive(false);
        }

        float amoutToMove = speed * Time.deltaTime;

        transform.Translate(dir * amoutToMove);

        if (score >= 30)
        {
            speedcount = true;
        }

        if(speedcount == true)
        {
            speed = 10 + speedup;

            if (score >= 30 * speedup && score < 30 * speedup + 3)
            {
                colorswitch = true;
            }

        }

	}
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Finish")
        {
            isJumping = false;
        }
        if(other.tag == "DeadZone")
        {
            this.GetComponent<AudioSource>().clip = eventclip[1];
            this.GetComponent<AudioSource>().Play();

            isDead = true;
            GameOver();
            resetBtn.SetActive(true);
            if (transform.childCount > 0)
            {
                vCamera.SetActive(false);
            }
        }
        if (other.tag == "Pickup")
        {
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
            score+= 3;
            scoreText.text = score.ToString();
            CombatTextManager.Instance.CreateText(other.transform.position, "+3", new Color32(255, 38, 38, 255), true);
        }
        if (other.tag == "TopJump")
        {
            Topcheck = true;
            isJumping = true;
        }
        if (other.tag == "LeftJump")
        {
            Leftcheck = true;
            isJumping = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "TopJump")
        {
            Topcheck = false;
        }
        if (other.tag == "LeftJump")
        {
            Leftcheck = false;
        }
        //if (other.tag == "Tile")
        //{
        //    RaycastHit hit;

        //    Ray downRay = new Ray(transform.position, -Vector3.up);

        //    if (!Physics.Raycast(downRay, out hit))
        //    {
        //        isDead = true;
        //        GameOver();
        //        resetBtn.SetActive(true);
        //        if (transform.childCount > 0)
        //        {
        //            vCamera.SetActive(false);
        //        }
        //    }
        //}
    }
    private void GameOver()
    {
        this.GetComponent<SphereCollider>().enabled = false;
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
    //private bool IsGrounded()
    //{
    //    Collider[] colliders = Physics.OverlapSphere(contactPoint.position, 0.5f, whatIsGround);

    //    for(int i =0; i < colliders.Length; i++)
    //    {
    //        if(colliders[i].gameObject != gameObject)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
    private void changeColor()
    {
        if (isDead == false)
        {
            if (colorswitch == true)
            {
                if (controlrandom == true)
                {
                    randomCamNum = Random.Range(0, 6);
                    randomTileNum = Random.Range(0, 6);
                    if (randomCamNum == sideCamNum)
                    {
                        randomCamNum = Random.Range(0, 6);
                    }
                    if (randomTileNum == sideTileNum)
                    {
                        randomTileNum = Random.Range(0, 6);
                    }
                    controlrandom = false;
                }
                timer += Time.deltaTime;
                tile.SetColor("_Color", tile.color = Color.Lerp(Tilecolor[sideTileNum], Tilecolor[randomTileNum], timer));

                if (timer >= 1.2f || isDead)
                {
                    sideCamNum = randomCamNum;
                    sideTileNum = randomTileNum;
                    randomCamNum = 0;
                    randomTileNum = 0;
                    colorswitch = false;
                    controlrandom = true;
                    timer = 0;
                }
            }
        }
    }
    private void upspeed()
    {
        if (!isJumping)
        {
            if (score > 60 && score < 90)
            {
                speedup = 2;
            }
            else if (score > 90 && score < 120)
            {
                speedup = 3;
            }
            else if (score > 120 && score < 150)
            {
                speedup = 4;
            }
            else if (score > 150 && score < 180)
            {
                speedup = 5;
            }
            else if (score > 180 && score < 210)
            {
                speedup = 6;
            }
            else if (score > 210 && score < 240)
            {
                speedup = 7;
            }
            else if (score > 240 && score < 270)
            {
                speedup = 8;
            }
            else if (score > 270 && score < 300)
            {
                speedup = 9;
            }
            else if (score > 300)
            {
                speedup = 10;
            }
        }
        else
        {
            speed = 10;
        }
    }
}
