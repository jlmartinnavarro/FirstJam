using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_bullet : MonoBehaviour {

    public float damage = 1f;
    public float damageCountdown = 0f;
    public float timeBetweenTicks = 0.1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       


    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        /* if (damageCountdown <= 0f)
         {
             damageCountdown = 1f / timeBetweenTicks;
             if (collision.tag == "Enemy")
             {
                 Debug.Log("Enemy hit");
                 collision.gameObject.GetComponent<Enemy>().ToDamage(damage);           
             }
         }
         damageCountdown -= Time.deltaTime; */
        if (collision.tag == "Enemy")
        {
            //Debug.Log("Enemy hit");
            collision.gameObject.GetComponent<Enemy>().laserDamage(damage);
        }

    }

    public void DamageTick(Enemy enemy)
    {        
       

    }

    public void setRotation(Quaternion rot)
    { 
        transform.rotation = rot;
    }

    public float getDamage()
    {
        return damage;
    }
}
