using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructureTesting : MonoBehaviour
{
    const int numberOfTests = 10000;
    int[] inventory = new int[numberOfTests];
    Dictionary<int, int> inventoryD = new Dictionary<int, int>();
    List<int> inventoryL = new List<int>();
    HashSet<int> inventoryH = new HashSet<int>();

    private void Start()
    {
        AddValuesInArray();
        AddValuesInDictionary();
        AddValuesInList();
        AddValuesInHash();
    }

    void AddValuesInArray()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            inventory[i] = Random.Range(10, 100);
        }
    }

    void IterValuesInArray()
    {
        foreach (int item in inventory)
        {
            Debug.Log(item);
        }
    }

    void AddValuesInDictionary()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            inventoryD.Add(i, Random.Range(10, 100));
        }
    }

    void IterValuesInDictionary()
    {
        foreach (KeyValuePair<int, int> item in inventoryD)
        {
            Debug.Log(item.Value);
        }
    }

    void AddValuesInList()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            inventoryL.Add(Random.Range(10, 100));
        }
    }

    void IterValuesInList()
    {
        foreach(int item in inventoryL)
        {
            Debug.Log(item);
        }
    }

    void AddValuesInHash()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            inventoryH.Add(Random.Range(10, 100));
        }
    }

    void IterValuesInHash()
    {
        foreach (int key in inventoryH)
        {
            Debug.Log(key);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            IterValuesInArray();
            IterValuesInDictionary();
            IterValuesInList();
            IterValuesInHash();
        }
    }
}
