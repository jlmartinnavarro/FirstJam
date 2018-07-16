using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneController : MonoBehaviour {


    // Bullet Logic
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float velocity = 6f;
    void Fire()
    {
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);
        //Velocity
        bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * velocity;
        
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
