using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy2 : Enemy
{
    //SMALL
    [Header("Atributos Enemigo")]
    //Velocidad de Movimiento
    protected float movSpeed1 = 5f;
    //Daño
    protected float damage1 = 3f;
    //Vida Máxima
    protected float maxHealth1 = 5f;
    //Distancia a la que atacar
    protected float attackRange1 = 2f;
    //Velocidad de ataque
    protected float attackSpeed1 = 2f;
    //Money
    protected int money1 = 1;
    private void Start()
    {
        SetEnemy(movSpeed1, damage1, maxHealth1, attackRange1, attackSpeed1, money1);
        Init();
    }
}