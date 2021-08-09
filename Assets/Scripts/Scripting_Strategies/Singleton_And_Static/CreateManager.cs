using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateManager : MonoBehaviour
{
    public GameObject boidPrefab;
    public int boidAmount;

    // Start is called before the first frame update
    void Start()
    {
        FlockManagerStatic.Init(boidPrefab, boidAmount);
    }
}
