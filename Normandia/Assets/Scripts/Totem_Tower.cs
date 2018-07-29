using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem_Tower : MonoBehaviour {

    [Header("Attrubutes")]
    public float range;
    public float damage;
    public float summonSpeed = 1f;
   

    [Header("Functionality")]

    public GameObject aimV;
    public Transform target;
    public GameObject bulletPrefab;
    private float summonCountdown = 0f;

    [Header("SpawnSpots")]
    public Transform tsp1;
    public Transform tsp2;
    public Transform tsp3;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTarget();
        if (target != null)
        {
            aimV.SetActive(true);
            aimV.transform.position = target.position;
            if (summonCountdown <= 0f)
            {
                SummonBullets();
                summonCountdown = 1f / summonSpeed;
            }
            summonCountdown -= Time.deltaTime;
        }
        else
        {
            aimV.SetActive(false);
        }
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
        }
        else
        {
            target = null;
        }
    }

    private void SummonBullets()
    {
        CreateBullet(tsp1);
        CreateBullet(tsp2);
        CreateBullet(tsp3);
    }

    private void CreateBullet(Transform s)
    {
        GameObject bulletGO = (GameObject)Instantiate(
            bulletPrefab,
            s.position,
            s.rotation);

        Totem_bullet bullet = bulletGO.GetComponent<Totem_bullet>();

        if (bullet != null)
        {
            bullet.Target(target);
            bullet.SetDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
