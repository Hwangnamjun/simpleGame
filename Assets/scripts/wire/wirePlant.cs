using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wirePlant : MonoBehaviour
{
    public GameObject pickup;
    public GameObject Item;
    public GameObject currentCeiling;

    public bool setStart;

    public GameObject[] bonusPos;
    public List<GameObject> bonuscheck = new List<GameObject>();
    public List<GameObject> itemcheck = new List<GameObject>();
    public List<GameObject> plantcheck = new List<GameObject>();

    private float sizeX;
    private float sizeY;

    public GameObject platformX;
    public GameObject platformY;

    Vector3 lastPos;

    public float pickupcount;
    public float Itemcount;
    public float plantcount;

    void Start()
    {
        setStart = false;
        sizeX = platformX.transform.localScale.x;
        sizeY = platformY.transform.localScale.x + 5f;
        lastPos = currentCeiling.transform.position;
        for (int x = 0; x < 10; x++)
        {
           int ransomware = Random.Range(0, 2);
            if(ransomware == 0)
            {
                okCeiling();
            }
            else if(ransomware == 1)
            {
                nonCeiling();
            }
        }
        InvokeRepeating("SpawnPlatform", 2f, 2f);
    }

    void Update()
    {
        if(setStart == true)
        {
            int spawnPickup = Random.Range(0, 300);
            int spawnItem = Random.Range(0, 300);

            if (pickupcount < 5)
            {
                if (spawnPickup == 0)
                {
                    int PickupPos = Random.Range(1, 4);

                    if (PickupPos == 1)
                    {
                        Instantiate(pickup, bonusPos[0].transform.position, Quaternion.Euler(-56.8f, 62.42f, -131.9f));
                        bonuscheck.Add(pickup);
                        pickupcount++;
                    }
                    if (PickupPos == 2)
                    {
                        Instantiate(pickup, bonusPos[1].transform.position, Quaternion.Euler(-56.8f, 62.42f, -131.9f));
                        bonuscheck.Add(pickup);
                        pickupcount++;
                    }
                    if (PickupPos == 3)
                    {
                        Instantiate(pickup, bonusPos[2].transform.position, Quaternion.Euler(-56.8f, 62.42f, -131.9f));
                        bonuscheck.Add(pickup);
                        pickupcount++;
                    }
                }
            }
            if(Itemcount < 1)
            {
                if(spawnItem == 0)
                {
                    int PickupPos = Random.Range(1, 4);

                    if (PickupPos == 1)
                    {
                        Instantiate(Item, bonusPos[0].transform.position, Quaternion.Euler(-56.8f, 62.42f, -131.9f));
                        itemcheck.Add(Item);
                        Itemcount++;
                    }
                    if (PickupPos == 2)
                    {
                        Instantiate(Item, bonusPos[1].transform.position, Quaternion.Euler(-56.8f, 62.42f, -131.9f));
                        itemcheck.Add(Item);
                        Itemcount++;
                    }
                    if (PickupPos == 3)
                    {
                        Instantiate(Item, bonusPos[2].transform.position, Quaternion.Euler(-56.8f, 62.42f, -131.9f));
                        itemcheck.Add(Item);
                        Itemcount++;
                    }
                }
            }
        }
    }
    private void SpawnPlatform()
    {
        int random = Random.Range(0, 6);
        if(plantcount < 15)
        {
            if (random < 3)
            {
                okCeiling();
            }
            if (random >= 3)
            {
                nonCeiling();
            }
        }
    }
    private void okCeiling()
    {
        GameObject _platform = Instantiate(platformX) as GameObject;
        _platform.transform.position = lastPos + new Vector3(sizeX, 0, 0);
        lastPos = _platform.transform.position;
        plantcheck.Add(platformX);
        plantcount++;
    }
    private void nonCeiling()
    {
        GameObject _platform = Instantiate(platformY) as GameObject;
        _platform.transform.position = lastPos + new Vector3(sizeY, 0, 0);
        lastPos = _platform.transform.position;
        plantcheck.Add(platformY);
        plantcount++;
    }
    public void triggerStart()
    {
        setStart = true;
    }
}
