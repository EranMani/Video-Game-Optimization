using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct NPCS
{
    public GameObject avatar;
    public string name;
    public int health;

    public NPCS(string _name, GameObject a)
    {
        name = _name;
        health = 100;
        avatar = a;
    }
}

public class NPCC
{
    public GameObject avatar;
    public string name;
    public int health;

    public NPCC(string _name, GameObject a)
    {
        name = _name;
        health = 100;
        avatar = a;
    }
}


public class NPCTypes : MonoBehaviour
{
    const int numberOfTests = 1000000;
    NPCC[] npcc = new NPCC[numberOfTests];
    NPCS[] npcs = new NPCS[numberOfTests];
    void CreateStructs()
    {
        
        for (int i = 0; i < numberOfTests; i++)
        {
            npcs[i] = new NPCS("No Name", null);
        }
    }

    void CreateClasses()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            npcc[i] = new NPCC("No Name", null);
        }
    }

    void UseClass(NPCC nps)
    {

    }

    void PassClass()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            UseClass(npcc[i]);
        }       
    }

    void UseStruct(NPCS nps)
    {

    }

    void PassStruct()
    {
        for (int i = 0; i < numberOfTests; i++)
        {
            UseStruct(npcs[i]);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateStructs();
            CreateClasses();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            PassClass();
            PassStruct();
        }
    }
}
