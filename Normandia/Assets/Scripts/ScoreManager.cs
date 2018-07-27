using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static int score;
    float timer = 0f;

    Text text;

	void Awake () {
        text = GetComponent<Text>();
        score = 0;
	}
	
    //Contador de tiempo + el dinero que produce cada enemigo = puntuación.
	void Update () {
        timer += Time.deltaTime;
        int seconds = (int) timer % 60;
        text.text = "Score: " + (score + seconds);
	}
}
