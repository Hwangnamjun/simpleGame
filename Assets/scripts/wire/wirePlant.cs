using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wirePlant : MonoBehaviour
{
    public GameObject[] CeilingPrefabs;

    public GameObject currentCeiling;

    private Stack<GameObject> okCeiling = new Stack<GameObject>();

    private Stack<GameObject> nonCeiling = new Stack<GameObject>();

    void Start()
    {
        CreateCeiling(100);

        for (int i = 0; i < 5; i++)
        {
            SpawnCeiling();
        }
    }   

    void Update()
    {
        
    }

    public void CreateCeiling(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            okCeiling.Push(Instantiate(CeilingPrefabs[0]));
            nonCeiling.Push(Instantiate(CeilingPrefabs[1]));
            nonCeiling.Peek().SetActive(false);
            okCeiling.Peek().SetActive(false);

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
}
