using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wirePlant : MonoBehaviour
{
    public GameObject[] CeilingPrefabs;

    public GameObject currentCeiling;

    public GameObject pickup;

    public bool setStart;

    public GameObject[] bonusPos;

    private static wirePlant instance;

    private Stack<GameObject> okCeiling = new Stack<GameObject>();

    public Stack<GameObject> OkCeiling
    {
        get { return okCeiling; }
        set { okCeiling = value; }
    }

    private Stack<GameObject> nonCeiling = new Stack<GameObject>();

    public Stack<GameObject> NonCeiling
    {
        get { return nonCeiling; }
        set { nonCeiling = value; }
    }

    public static wirePlant Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<wirePlant>();
            }
            return instance;
        }
    }

    void Start()
    {
        setStart = false;
    }
    public void startWire()
    {
        CreateCeiling(10);

        for (int i = 0; i < 5; i++)
        {
            SpawnCeiling();
        }
    }
    void Update()
    {
        if(setStart == true)
        {
            int spawnPickup = Random.Range(0, 300); if (spawnPickup == 0)
            {
                int PickupPos = Random.Range(1, 4);

                if (PickupPos == 1)
                {
                    Instantiate(pickup, bonusPos[0].transform.position, Quaternion.Euler(-56.8f, 62.42f, -131.9f));
                }
                if (PickupPos == 2)
                {
                    Instantiate(pickup, bonusPos[1].transform.position, Quaternion.Euler(-56.8f, 62.42f, -131.9f));
                }
                if (PickupPos == 3)
                {
                    Instantiate(pickup, bonusPos[2].transform.position, Quaternion.Euler(-56.8f, 62.42f, -131.9f));
                }
            }
        }

    }

    public void CreateCeiling(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            okCeiling.Push(Instantiate(CeilingPrefabs[0]));
            nonCeiling.Push(Instantiate(CeilingPrefabs[1]));
            nonCeiling.Peek().SetActive(false);
            okCeiling.Peek().SetActive(false);
            nonCeiling.Peek().name = "NonCeiling";
            okCeiling.Peek().name = "OkCeiling";
        }
    }

    public void SpawnCeiling()
    {
        if (okCeiling.Count == 0|| nonCeiling.Count == 0)
        {
            CreateCeiling(10);
        }

        int randomIndex = Random.Range(0, 2);

        if (randomIndex == 0)
        {
            GameObject tmp = okCeiling.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentCeiling.transform.GetChild(0).transform.GetChild(0).position;
            currentCeiling = tmp;
        }
        else if(randomIndex == 1)
        {
            GameObject tmp = nonCeiling.Pop();
            tmp.SetActive(true);
            tmp.transform.position = currentCeiling.transform.GetChild(0).transform.GetChild(0).position;
            currentCeiling = tmp;
        }
    }
    public void triggerStart()
    {
        setStart = true;
    }
}
