using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void Update()
    {
        this.transform.Translate(0, 0, 0.5f);
    }
}
