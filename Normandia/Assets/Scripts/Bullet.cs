using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage = 10;

    private void OnTriggerEnter(Collider2D other)
    {
        /// this.enabled = !this.enabled;
        Destroy(this);
    }
}
