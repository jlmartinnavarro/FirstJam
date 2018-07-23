using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

    public Transform target;

    [Header("Attrubutes")]

    public float range = 15f;
    
    public float aimSpeed = 15f;
    private float bulletVelocity = 6f;
    public float attackSpeed = 1f;
    private float fireCountdown = 0f;

    [Header("Funcionality")]
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public bool auto = true;
    public GameObject manualbulletPrefab;


    // Use this for initialization
    void Start () {
        auto = true;
		
	}

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(SceneController.enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (shortestDistance > distanceToEnemy)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        } else
        {
            target = null;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (auto)
        {
            UpdateTarget();
            if (target == null)
            {
                return;
            }

            Vector3 vectorToTarget = target.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * aimSpeed);

            if (fireCountdown <= 0f)
            {
                Fire();
                fireCountdown = 1f / attackSpeed;
            }
            fireCountdown -= Time.deltaTime;
        }
        else
        {
            Vector3 shootDirection;
            shootDirection = Input.mousePosition;
            shootDirection.z = 0.0f;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            Vector3 vectorToTarget = shootDirection- transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * aimSpeed);

            if (Input.GetMouseButtonDown(0) && fireCountdown <= 0f)
            {            
                ManualShot();
                fireCountdown = 1f / attackSpeed;              
            }
            fireCountdown -= Time.deltaTime;

        }

    }
    
    void Fire()
    {
        
        GameObject bulletGO = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Target(target);
            //Velocity
            bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * bulletVelocity;
        }

       
       
    }

    void ManualShot()
    {
        //...setting shoot direction
        Vector3 shootDirection;
        shootDirection = Input.mousePosition;
        shootDirection.z = 0.0f;
        shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
        shootDirection = shootDirection - transform.position;
        
        Debug.Log("ShootDirection: " + shootDirection);
        //...instantiating the rocket
        GameObject bulletGO = (GameObject)Instantiate(
           manualbulletPrefab,
           bulletSpawn.position,
           bulletSpawn.rotation);


        CannonBall bullet = bulletGO.GetComponent<CannonBall>();
        bullet.setDir(shootDirection.normalized);


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    private void OnMouseDown()
    {
        auto = !auto;
    }



    
}
