using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class currentWire : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "current")
        {
            wirePlant.Instance.SpawnCeiling();
            StartCoroutine(Falling());
            //destroyBlock();
        }
    }

    //public void destroyBlock()
    //{
    //    if (gameObject.name == "okCeiling")
    //    {
    //        wirePlant.Instance.OkCeiling.Push(gameObject);
    //        gameObject.SetActive(false);
    //        Debug.Log("123");
    //    }
    //    else if (gameObject.name == "nonCeiling")
    //    {
    //        wirePlant.Instance.NonCeiling.Push(gameObject);
    //        gameObject.SetActive(false);
    //        Debug.Log("123");
    //    }
    //}
    IEnumerator Falling()
    {
        yield return new WaitForSeconds(2);

        switch (gameObject.name)

        {
            case "OkCeiling":
                wirePlant.Instance.OkCeiling.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;

            case "NonCeiling":
                wirePlant.Instance.NonCeiling.Push(gameObject);
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                gameObject.SetActive(false);
                break;
        }
    }

}
