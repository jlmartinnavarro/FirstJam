using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pruebaColision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Correcto");
    }

    // Update is called once per frame
    void Update () {
		
	}
}
