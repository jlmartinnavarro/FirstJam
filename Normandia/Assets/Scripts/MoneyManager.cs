using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public static int money;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        money = 0;
    }

    void Update()
    {
        text.text = "Money: " + money;
    }
}
