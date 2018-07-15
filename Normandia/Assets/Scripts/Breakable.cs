using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour {

    public float health = 100f;

    //Setters y getters de toda la vida

    public float getHealth()
    {
        return health;
    }

    public void setHealth(float newHealth)
    {
        health = newHealth;
        if(health <= 0)
        {
            destroyThis();
        }
    }

    //Comprueba si no tiene vida, o sea, si está destruido.
    public bool isDestroyed()
    {
        if (getHealth() <= 0) return true;
        else return false;
    }

    //El objeto no se debería destruir, únicamente se debería "ocultar"
    public void destroyThis()
    {
        //Quitamos el collider para que el enemigo pueda seguir avanzando.
        Destroy(GetComponent<BoxCollider2D>());
        //Quitamos el sprite y se deja de ver el objeto.
        Destroy(GetComponent<SpriteRenderer>());

        //Se podrían introducir animaciones de destruit el objeto aquí.

    }

}
