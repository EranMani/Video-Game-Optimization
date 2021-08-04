using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    Transform[] tanks;
    public int numberOfTanks;
    public GameObject tankPrefab;

    // Populating the player via the inspector is much more efficient then populate it dynamically in code
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    { 
        // Cache the transforms of the tanks
        tanks = new Transform[numberOfTanks];
        // Add to memory only one tank gameObject instead of the amount inside the loop
        GameObject tank;

        for (int i = 0; i < numberOfTanks; i++)
        {
            tank = Instantiate(tankPrefab);
            tank.transform.position = new Vector3(Random.Range(-50,50), 0, Random.Range(-50,50));
            tanks[i] = tank.transform;
            tanks[i].LookAt(player.transform.position);
        }      
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform t in tanks)
        {          
            t.Translate(0, 0, 0.05f);          
        } 
    }
}
