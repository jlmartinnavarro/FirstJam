using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem_bullet : MonoBehaviour {

    public Transform target;
    public float damage;
    public float bulletVelocity = 20f;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }



        //Obtenemos la dirección de movimiento de la bala
        Vector3 dir = target.position - transform.position;
        //Velocidad Real = Velocidad Base * Tiempo
        float dTF = bulletVelocity * Time.deltaTime;
        //Efectua el movimiento de la bala
        transform.Translate(dir.normalized * dTF, Space.World);

        
    }

    public void Target(Transform tgt)
    {
        target = tgt;
    }

    public void SetDamage(float d)
    {
        damage = d;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == SceneController.enemyTag)
        {
            /// this.enabled = !this.enabled;
            other.gameObject.GetComponent<Enemy>().ToDamage(damage);
            Destroy(gameObject);
        }
    }

}
