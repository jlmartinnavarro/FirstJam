using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float damage = 10;
    public float bulletVelocity = 20f;
    private Transform target;
    private bool firstStep = true;
    

    public void Target (Transform tgt)
    {
        target = tgt;
    }
    private void OnTriggerEnter(Collider2D playaPrueba)
    {
        /// this.enabled = !this.enabled;
        Destroy(gameObject);
        return;
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
            Vector3 dir = target.position - transform.position;
            float dTF = bulletVelocity * Time.deltaTime;
            transform.Translate(dir.normalized * dTF, Space.World);
            firstStep = false;
        }
    }
}
