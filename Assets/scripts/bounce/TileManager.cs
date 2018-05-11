using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    public GameObject currentTile;

    private static TileManager instance;

    private Stack<GameObject> leftTiles = new Stack<GameObject>();

    public Stack<GameObject> LeftTiles
    {
        get { return leftTiles; }
        set { leftTiles = value; }
    }

    private Stack<GameObject> topTiles = new Stack<GameObject>();

    public Stack<GameObject> TopTiles
    {
        get { return topTiles; }
        set { topTiles = value; }
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
            leftTiles.Peek().SetActive(false);
            topTiles.Peek().SetActive(false);
            topTiles.Peek().name = "TopTile";
            leftTiles.Peek().name = "LeftTile";
        }
    }

    public void SpawnTile()
    {

        if(leftTiles.Count == 0 || topTiles.Count ==0)
        {
            CreateTiles(10);
        }

        int randomIndex = Random.Range(0, 2);

        if(randomIndex == 0)
        {
            GameObject tmp = leftTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
            currentTile = tmp;
        }
        else if(randomIndex == 1)
        {
            GameObject tmp = topTiles.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentTile.transform.GetChild(0).transform.GetChild(randomIndex).position;
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