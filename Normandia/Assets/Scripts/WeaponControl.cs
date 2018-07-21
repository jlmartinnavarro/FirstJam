using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour {

    private float bulletVelocity = 6f;
    public float attackSpeed = 1f;
    private float fireCountdown = 0f;


    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            Shot();
        }
		
	}

    private void OnMouseDown()
    {
        Debug.Log("Click");
        Shot();
    }

    void Shot()
    {
        //...setting shoot direction
        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        //...instantiating the rocket
        GameObject bulletGO = (GameObject)Instantiate(
           bulletPrefab,
           bulletSpawn.position,
           bulletSpawn.rotation);


        CannonBall bullet = bulletGO.GetComponent<CannonBall>();
        bullet.setDir(shootDirection.normalized);


    }
}
