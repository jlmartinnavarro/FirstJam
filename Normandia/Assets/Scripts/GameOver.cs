using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    public GameObject gameOver;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == SceneController.enemyTag)
        {
            //Game OVer
            Debug.Log("GAME OVER");
            gameOver.SetActive(true);
        }
    }


}
