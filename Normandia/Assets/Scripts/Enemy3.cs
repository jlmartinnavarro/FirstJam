using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy3 : Enemy
{
    //BIG
    [Header("Atributos Enemigo")]
    //Velocidad de Movimiento
    protected float movSpeed1 = 1f;
    //Daño
    protected float damage1 = 10f;
    //Vida Máxima
    protected float maxHealth1 = 15f;
    //Distancia a la que atacar
    protected float attackRange1 = 2f;
    //Velocidad de ataque
    protected float attackSpeed1 = 0.5f;
    //Money
    protected int money1 = 6;
    private void Start()
    {
        SetEnemy(movSpeed1, damage1, maxHealth1, attackRange1, attackSpeed1, money1);
        Init();
    }
}