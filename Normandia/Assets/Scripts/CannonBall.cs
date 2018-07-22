using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

    public float damage = 10f;
    public float bulletVelocity = 20f;
    private Vector3 dir;

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy hit T");
            other.gameObject.GetComponent<Enemy>().ToDamage(damage);
            Explosion();
            return;
        }
        else if (other.tag == "floor")
        {
            Debug.Log("Floor hit");
            Explosion();
            return;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("Enemy hit");
            other.gameObject.GetComponent<Enemy>().ToDamage(damage);
            Explosion();
            return;
        }
        else if (other.tag == "floor")
        {
            Debug.Log("Floor hit");
            Explosion();
            return;
        }
        else if (other.tag == "worldBorder")
        {
            Debug.Log("Border");
            Destroy(gameObject);
            return;
        }
    }

    private void Explosion()
    {

        Destroy(gameObject);
        return;
    }

    public void setDir(Vector3 d)
    {
        dir = d;
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float realV = bulletVelocity * Time.deltaTime;
        transform.Translate(dir * realV);
        
    }
}
