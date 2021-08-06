using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformanceTestingNulls : MonoBehaviour
{
    const int numberOfTests = 5000;
    GameObject testGameObject;


    void PerformTest1()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            if (testGameObject != null)
            {
            }
        }
    }

    void PerformTest2()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            if (!System.Object.ReferenceEquals(testGameObject, null))
            {
            }
        }
    }

    //C# 9.0 - V2020 only supports C# 8.
    void PerformTest3()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
           // if (testGameObject is not null)
            {
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformTest1();
            PerformTest2();
            //PerformTest3();
        }
    }
}
