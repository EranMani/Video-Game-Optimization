using UnityEngine;

public class TankMovement : MonoBehaviour
{
    Transform player;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        t = (Transform) GetComponent("Transform");

        InvokeRepeating("FollowPlayer", Random.Range(0f, 1f), 1);
    }

    void FollowPlayer()
    {
        t.LookAt(player.transform.position);
        t.Translate(0, 0, 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
