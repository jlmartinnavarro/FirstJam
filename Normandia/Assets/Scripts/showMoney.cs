using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class showMoney : MonoBehaviour {

    public float money = 0f;
    public Text myText;
	// Use this for initialization
	void Start () {
        myText.text = "" + money;
	}
	
	// Update is called once per frame
	void Update () {
        myText.text = "" + SceneController.globalMoney;
    }
}
