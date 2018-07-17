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
    

    // Use this for initialization
    void Start () {
		
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
        UpdateTarget();
        if (target == null)
        {
            return;
        }
 
        Vector3 vectorToTarget = target.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * aimSpeed);

        if(fireCountdown <= 0f)
        {
            Fire();
            fireCountdown = 1f / attackSpeed;
        }
        fireCountdown -= Time.deltaTime;
        

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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
