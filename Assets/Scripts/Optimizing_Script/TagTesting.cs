using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagTesting : MonoBehaviour
{
    const int numberOfTests = 1000000;
    GameObject testGameObject;


    void Start()
    {
        testGameObject = new GameObject();
    }

    void PerformTagEquals()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            if (testGameObject.tag == "Player")
            {
            }
        }
    }

    void PerformCompareTag()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            if (testGameObject.CompareTag("Player"))
            {
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformTagEquals();
            PerformCompareTag();
        }
    }
}
