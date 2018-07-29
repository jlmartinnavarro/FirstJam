using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    [Header("Atributos Enemigo")]
    //Velocidad de Movimiento
    protected float movSpeed;
    //Daño
    protected float damage;
    //Vida Máxima
    protected float maxHealth;
    //Distancia a la que atacar
    protected float attackRange;
    //Velocidad de ataque
    protected float attackSpeed;
    //Money
    protected int money;
    [Header("Atributos Internos")]
    protected float health;
    //Barra de vida.
    public Image healthBar;
    //Used for attacking
    private float attackCountdown = 0f;

    [Header("Atributos Movimiento")]
    //Posición del target al que se dirige.
    protected Transform target;
    //Índice dentro del array de Waypoints.points.
    public int waypointIndex = 0;
    //Objeto al que ataca.
    public Breakable defense;

    [Header("Logica Laser")]
    public float timeBetweenTicks = 1f;
    private float laserDamageCountdown = 0f;

    /**
     * Constructor de la clase. No se utiliza un constructor Enemy por problemas con Unity.
     */
    public void SetEnemy(float movSpeed, float damage, float maxHealth, float attackRange, float attackSpeed, int money)
    {
        this.movSpeed = movSpeed;
        this.damage = damage;
        this.maxHealth = maxHealth;
        this.attackRange = attackRange;
        this.attackSpeed = attackSpeed;
        this.money = money;
    }

    protected void Init()
    {
        this.gameObject.tag = SceneController.enemyTag;
        //Esta comprobación es por si en la creación del objeto pero antes del Start se han inicializado sus parámetros.
        if (damage == 0)
        {
            SetEnemy(3f, 20f, 10f, 2f, 1f, 3);
        }
        //Inicializa la vida
        health = maxHealth;
        //Hace target y defense al primer waypoint del array
        target = Waypoints.points[waypointIndex];
        defense = target.gameObject.GetComponent<Breakable>();

        laserDamageCountdown = 0f;

       
    }
    void Start()
    {
        Init();
    }

    void Update()
    {
        //Si estamos en rango de ataque
        if (Vector2.Distance(transform.position, target.position) <= attackRange)
        {
            Attack(defense);
        }
        //Si no, nos movemos
        else
        {
            //Dirección hacia donde se dirige.
            Vector2 dir = target.position - transform.position;
            /*
            * Movimiento hacia ese punto, normalizado, con la velocidad del enemigo 
            * y multiplicado por Time.deltaTime, en el punto de referencia World.
            * Time.deltaTime hace que el movimiento no dependa de los fps,
            * si no a los segundos reales que transcurren en el juego.
           */
            transform.Translate(dir.normalized * movSpeed * Time.deltaTime, Space.World);
        }
    }

    //Ataca a defense y le hace un daño equivalente a damage.
    protected void Attack(Breakable defense)
    {
        if (attackCountdown <= 0f)
        {
            defense.ToDamage(damage);
            attackCountdown = 1f / attackSpeed;
        }
        attackCountdown -= Time.deltaTime;
    }

    //Pasa al siguiente target.
    void getNextTarget()
    {
        //Si hay más waypoints se pasa al siguiente.
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

    public void ToDamage(float damage)
    {
        //Obtenemos el daño de la bala
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            ScoreManager.score += money;
            MoneyManager.money += money;
            SceneController.globalMoney += money;
            return;
        }
        //Actualizamos vida
        healthBarLogic();
    }

    //Lógica de la barra de Vida
    public void healthBarLogic()
    {
        //Gráfico de vida, se llenará de 0 (min) a 1 (max) según la vida actual.
        //Se divide health / maxHealth para conseguir número de 0 a 1 =>
        //      Si nuestro enemigo tiene 100 de vida max y le quedan 50 estará a 0.5, que es el número que puede coger healthBar.
        healthBar.fillAmount = health / maxHealth;
    }

   /* private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "laser")
        {
            laserDamageCountdown = 1f / timeBetweenTicks;
            if (laserDamageCountdown <= 0f)
            {
                Debug.Log("Laser Damge");
                ToDamage(collision.gameObject.GetComponent<Laser_bullet>().getDamage());
            }
            laserDamageCountdown -= Time.deltaTime;
        }
        
    }*/

    public void laserDamage(float damage)
    {
        
        if (laserDamageCountdown <= 0f)
        {
            laserDamageCountdown = 1f / timeBetweenTicks;
            //Debug.Log("Laser tick " + laserDamageCountdown);

            ToDamage(damage);
            
        }
        laserDamageCountdown -= Time.deltaTime;
    }
}
