using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
    public GameObject gameOver;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == SceneController.enemyTag)
        {
            throwGameOver();   
        }
    }
    public void throwGameOver()
    {
        Debug.Log("GAME OVER");
        gameOver.SetActive(true);
        foreach (var e in GameObject.FindGameObjectsWithTag(SceneController.enemyTag))
        {
            Destroy(e);
        }
        SceneController.gameOver = true;
    }
}
