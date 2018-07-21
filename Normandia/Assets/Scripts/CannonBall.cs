using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour {

    public float damage = 10f;
    public float bulletVelocity = 20f;
    private Vector3 dir;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "floor")
        {
            Explosion();
        }
        else if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().ToDamage(damage);
            Explosion();
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
        transform.Translate(dir.normalized * realV, Space.World);
    }
}
