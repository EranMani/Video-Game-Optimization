using UnityEngine;

public class DummyObjectCreator : MonoBehaviour
{
    public int numberOfObjects;
    GameObject dummyObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CreateObjects();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            DestroyObjects();
        }
    }

    void CreateObjects()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            dummyObject = new GameObject("A_Dummy");
            dummyObject.tag = "Player";
        }
    }

    void DestroyObjects()
    {
        GameObject[] dummies = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in dummies)
        {
            Destroy(go);
        }
    }
}
