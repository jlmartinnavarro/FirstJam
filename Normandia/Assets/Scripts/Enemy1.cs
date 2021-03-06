﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Enemy1 : Enemy
{
    //NORMAL
    [Header("Atributos Enemigo")]
    //Velocidad de Movimiento
    protected float movSpeed1 = 3f;
    //Daño
    protected float damage1 = 20f;
    //Vida Máxima
    protected float maxHealth1 = 10f;
    //Distancia a la que atacar
    protected float attackRange1 = 2f;
    //Velocidad de ataque
    protected float attackSpeed1 = 1f;
    //Money
    protected int money1 = 3;
    private void Start()
    {
        SetEnemy(movSpeed1, damage1, maxHealth1, attackRange1, attackSpeed1, money1);
        Init();
    }
}