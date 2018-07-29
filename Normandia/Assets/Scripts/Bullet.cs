using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage = 1f;
    public float bulletVelocity = 20f;
    private Transform target;    

    public void Target (Transform tgt)
    {
        target = tgt;
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



    private void Update()
    {
        if (target == null || transform.position.y < -3.40)
        {
            Destroy(gameObject);
            return;
        }

       

        if (true) //de momento que sean un poco teleridigidos
        {
            //Obtenemos la dirección de movimiento de la bala
            Vector3 dir = target.position - transform.position;
            //Velocidad Real = Velocidad Base * Tiempo
            float dTF = bulletVelocity * Time.deltaTime;
            //Efectua el movimiento de la bala
            transform.Translate(dir.normalized * dTF, Space.World);
        }
    }
}
