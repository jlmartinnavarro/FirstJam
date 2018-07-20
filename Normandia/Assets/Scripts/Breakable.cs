using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Breakable : MonoBehaviour {

    public float health = 100f;
    public float maxHealth = 100f;
    //Barra de vida.
    public Image healthBar;
    //Derrota
    public GameOver gaOver;

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

    public void ToDamage(float damage)
    {
       

        Debug.Log("Tower Damage " + damage + " " + health);
        //Obtenemos el daño recibido
        health -= damage;
        Debug.Log("New tower health" + health);
        //Actualizamos vida
        healthBarLogic();
        if(health < 0)
        {
            //Destroy(gameObject);
            //return;
            gaOver.throwGameOver();
            destroyThis();
        }
       
    }
    //A usar al recibir daño (barra de vida) -- No sé donde
    public void healthBarLogic()
    {
        //Gráfico de vida, se llenará de 0 (min) a 1 (max) según la vida actual.
        //Se divide health / maxHealth para conseguir número de 0 a 1 =>
        //      Si nuestra torre tiene 100 de vida max y le quedan 50 estará a 0.5, que es el número que puede coger healthBar.
        healthBar.fillAmount = health / maxHealth;
    }

}
