using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour
{
    Vector3 velocity;
    float sides = 30.0f;
    float speedMax = 0.3f;
    int colorPropertyID;
    // Store the variable once in the memory
    Vector3 position;
    Renderer rend;

    void Start()
    {

        velocity = new Vector3(Random.Range(0.0f, speedMax),
                        Random.Range(0.0f, speedMax),
                        Random.Range(0.0f, speedMax));

        colorPropertyID = Shader.PropertyToID("_Color");
        rend = GetComponent<Renderer>();
    }

    Color GetRandomColor()
    {
        return new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity);
        
        // Instead of calling the transform each statement below, assign it once to a variable and use it. This will save calls amount 
        // in the profiler and will increase performance
        position = transform.position;

        if (position.x > sides)
        {
            velocity.x = -velocity.x;
        }
        if (position.x < -sides)
        {
            velocity.x = -velocity.x;
        }
        if (position.y > sides)
        {
            velocity.y = -velocity.y;
        }
        if (position.y < -sides)
        {
            velocity.y = -velocity.y;
        }
        if (position.z > sides)
        {
            velocity.z = -velocity.z;
        }
        if (position.z < -sides)
        {
            velocity.z = -velocity.z;
        }

        rend.material.SetColor(colorPropertyID, new Color(position.x/sides,
                                                                             position.y/sides,
                                                                           position.z/sides));

    }
}
