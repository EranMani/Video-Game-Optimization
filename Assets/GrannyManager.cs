using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyManager : MonoBehaviour
{
    public int numberOfGranniesRow;
    public int numberOfGranniesCol;
    public GameObject grannyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int z = 0; z < numberOfGranniesRow; z++)
        {
            for (int x = -(int)(numberOfGranniesCol/2.0f); x < numberOfGranniesCol/2.0f; x++)
            {
                GameObject g = Instantiate(grannyPrefab);
                g.transform.position = new Vector3(x, 0, z);
            }
        }
    }

}
