using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SceneController : MonoBehaviour {

    public static string bulletTag = "Bullet";
    public static string enemyTag = "Enemy";
    public int startMoney = 100;
    public static int globalMoney;

    private void Start()
    {
        globalMoney = startMoney;
    }
    private void Update()
    {
        Debug.Log(globalMoney);
    }
}
