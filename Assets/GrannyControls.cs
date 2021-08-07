using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrannyControls : MonoBehaviour {

    Animator anim;
    float speed = 0.1f;
    int animRunningID;

    // Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
        animRunningID = Animator.StringToHash("running");

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool(animRunningID, true);
            this.transform.position += this.transform.forward * speed;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool(animRunningID, true);
            this.transform.position -= this.transform.forward * speed;
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool(animRunningID, false);
        }
	}
}
