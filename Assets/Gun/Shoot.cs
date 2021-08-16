using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public GameObject bullet;
    public GameObject spawnPos;
    public GameObject player;
    AudioSource gunSound;
    float shootCoolDown = 0;
    float distance = 10;

    // The script with this method must be attached to an object with a mesh renderer component, otherwise it wont work
    /*private void OnBecameInvisible()
    {
        enabled = false;
    }

    private void OnBecameVisible()
    {
        enabled = true;
    }*/

    IEnumerator DistanceDisable()
    {
        while (true)
        {
            // sqrMagnitude is more optimized to calculate then the regular magnitude 
            float distS = (transform.position - player.transform.position).sqrMagnitude;
            if (distS < distance * distance)
            {
                enabled = true;
            }
            else
            {
                enabled = false;
            }

            yield return new WaitForSeconds(1);
        }
    }

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        gunSound = this.GetComponent<AudioSource>();
        StartCoroutine(DistanceDisable());
	}

    void ShootBullet()
    {
        Instantiate(bullet, spawnPos.transform.position, spawnPos.transform.rotation);
        gunSound.Play();
    }

    float turnSpeed = 1.0f;
	// Update is called once per frame
	void Update () {

        if(player)
        {
            Vector3 direction = player.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                                Quaternion.LookRotation(direction),
                                turnSpeed * Time.smoothDeltaTime);
            if (shootCoolDown <= 0)
            {
                ShootBullet();
                shootCoolDown = Random.Range(3,5);
            }
            else
                shootCoolDown -= 0.1f;
        }
	}
}
