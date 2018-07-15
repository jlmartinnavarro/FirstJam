using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 3f;
    public float damage = 20f; //Por segundo

    //Posición del target al que se dirige.
    private Transform target;

    //Índice dentro del array de Waypoints.points.
    public int waypointIndex = 0;

    //Objeto al que ataca.
    public Breakable defense;
    private GameObject aux;

    //Temporizador despawn.
    float timer = 0f;

    //Distancia a la que atacar
    private float distanceToAtack = 2f;
    void Start()
    {
        //Hace target y defense al primer waypoint del array
        target = Waypoints.points[waypointIndex];
        aux = GameObject.Find(target.gameObject.name);
        defense = aux.GetComponent<Breakable>();

        //La última es para indicar que defense es un objeto Breakable que hereda de GameObject. 
    }

    void Update()
    {
        /*
         * 
         * Dirección hacia donde se dirige.
         * Vector2 dir = target.position - transform.position;
         * 
         * Movimiento hacia ese punto, normalizado, con la velocidad que queremos darle al enemigo y multiplicado por Time.deltaTime,
         * en el punto de referencia World (No se mueve respecto a otra cosa que no sea lo global).
         * Time.deltaTime hace que el movimiento no dependa de los fps a los que vemos el juego, si no a los segundos reales que transcurren en el juego.
         * transform.Translate(dir.normalized *speed *Time.deltaTime,Space.World);
        */

        //Comprobamos si nuestro defense NO está destruido
        if (!defense.isDestroyed())
        {
            //Si estamos a una distancia menor de X atacamos.
            if (Vector2.Distance(transform.position, target.position) <= distanceToAtack)
            {
                Attack(defense);
            }

            //Si no, nos movemos hacia el.
            else
            {
                Vector2 dir = target.position - transform.position;
                transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
            }

            
        }
        //Si está destruido
        else
        {
            //Si no quedan más objetos a destruir.
            if (waypointIndex >= Waypoints.points.Length - 1)
            {
                //Contamos el tiempo en el que no tiene ningún target. -- JL: para qué?
                timer = timer + 1.0f * Time.deltaTime;

                //Movimiento hacia la izquierda (Vector2.left = (-1,0).
                transform.Translate(Vector2.left * speed * Time.deltaTime, Space.World);

                //TODO Contamos 5 segundos para hacer despawn.
                if (timer >= 5)
                {
                    Debug.Log("DESTRUIDO: "+gameObject.name);
                    Destroy(gameObject);
                }
            }
            //Si siguen quedando objetos a destruir.
            else
            {
                //Avanzamos hasta el siguiente target.
                getNextTarget();
            }
        }
    }

    //Ataca a defense y le hace un daño equivalente a damage.
    void Attack(Breakable defense)
    {
        float currentHealth = defense.getHealth();
        defense.setHealth(currentHealth - damage *Time.deltaTime);
    }

    //Pasa al siguiente target.
    void getNextTarget()
    { 
        //Si hay más waypoints se pasa al siguiente.
        waypointIndex++;
        target = Waypoints.points[waypointIndex];

    }

}
