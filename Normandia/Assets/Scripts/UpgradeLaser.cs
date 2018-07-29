using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeLaser : MonoBehaviour {
    public Laser laser;   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(laser.upgradeCost < SceneController.globalMoney)
        {
            //ocultar cuando no haya suficiente dinero
            
        }
		
	}

    private void OnMouseDown()
    {
        laser.Upgrade();
    }
}
