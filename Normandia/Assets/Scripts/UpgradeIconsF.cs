using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeIconsF : MonoBehaviour {

    public UpgradeLaser upLa;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(upLa.laser.upgradeCost > SceneController.globalMoney)
        {
            upLa.gameObject.SetActive(false);
        }
        else
        {
            upLa.gameObject.SetActive(true);
        }
	}
}
