using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyBoss : Enemy
{
    //BOSS
    [Header("Atributos Enemigo")]
    //Velocidad de Movimiento
    protected float movSpeed1 = 0.2f;
    //Daño
    protected float damage1 = 15f;
    //Vida Máxima
    protected float maxHealth1 = 50f;
    //Distancia a la que atacar
    protected float attackRange1 = 2f;
    //Velocidad de ataque
    protected float attackSpeed1 = 1f;
    //Money
    protected int money1 = 50;
    private void Start()
    {
        SetEnemy(movSpeed1, damage1, maxHealth1, attackRange1, attackSpeed1, money1);
        Init();
    }
}