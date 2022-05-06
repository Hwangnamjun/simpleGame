using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    public GameObject currentTile;

    public Color32[] colortile;

    public Material starttile;

    private static TileManager instance;
    //
    private Stack<GameObject> leftTiles = new Stack<GameObject>();

    public Stack<GameObject> LeftTiles
    {
        get { return leftTiles; }
        set { leftTiles = value; }
    }
    //
    private Stack<GameObject> topTiles = new Stack<GameObject>();

    public Stack<GameObject> TopTiles
    {
        get { return topTiles; }
        set { topTiles = value; }
    }
    //
    private Stack<GameObject> topJumpTiles = new Stack<GameObject>();

    public Stack<GameObject> TopJumpTiles
    {
        get { return topJumpTiles; }
        set { topJumpTiles = value; }
    }
    //
    private Stack<GameObject> leftJumpTiles = new Stack<GameObject>();

    public Stack<GameObject> LeftJumpTiles
    {
        get { return leftJumpTiles; }
        set { leftJumpTiles = value; }
    }


    public static TileManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<TileManager>();
            }
            return instance;
        }
    }

	// Use this for initialization
	void Start ()
    {
        currentTile.SetActive(false);
        starttile.SetColor("_Color", colortile[0]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void pushStart()
    {
        currentTile.SetActive(true);

        CreateTiles(100);

        for (int i = 0; i < 50; i++)
        {
            SpawnTile();
        }
    }

    public void CreateTiles(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            leftTiles.Push(Instantiate(tilePrefabs[0]));
            topTiles.Push(Instantiate(tilePrefabs[1]));
            leftJumpTiles.Push(Instantiate(tilePrefabs[2]));
            topJumpTiles.Push(Instantiate(tilePrefabs[3]));
            leftTiles.Peek().SetActive(false);
            topTiles.Peek().SetActive(false);
            leftJumpTiles.Peek().SetActive(false);
            topJumpTiles.Peek().SetActive(false);
            topTiles.Peek().name = "TopTile";
            leftTiles.Peek().name = "LeftTile";
            topJumpTiles.Peek().name = "TopJumpTile";
            leftJumpTiles.Peek().name = "LeftJumpTile";
        }
    }

    public void SpawnTile()
    {

        if(leftTiles.Count == 0 || topTiles.Count ==0 || leftJumpTiles.Count == 0 || topJumpTiles.Count == 0)
        {
            CreateTiles(100);
        }

        int randomIndex = Random.Range(0, 4);

        int randomPos = Random.Range(0, 2);

        if(randomIndex == 0)
        {
            GameObject tmp = leftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(0).position;
            currentTile = tmp;
        }
        else if(randomIndex == 1)
        {
            GameObject tmp = topTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(1).position;
            currentTile = tmp;
        }
        else if (randomIndex == 2)
        {
            GameObject tmp = leftJumpTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(0).position;
            currentTile = tmp;
        }
        else if (randomIndex == 3)
        {
            GameObject tmp = topJumpTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(1).position;
            currentTile = tmp;
        }
        int spawnPickup = Random.Range(0, 10);

        if(spawnPickup == 0)
        {
            currentTile.transform.GetChild(1).gameObject.SetActive(true);
        }

    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
    public void newGame()
    {
        SceneManager.LoadScene(1);
    }
}